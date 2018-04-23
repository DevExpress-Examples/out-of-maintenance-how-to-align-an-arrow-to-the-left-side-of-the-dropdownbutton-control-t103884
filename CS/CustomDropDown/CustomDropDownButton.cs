using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System.ComponentModel;
using System.Drawing;

namespace CustomDropDown {
    [ToolboxItem(true)]
    public class CustomDropDownButton : DropDownButton {
        // Fields...
        private ArrowAlignment _ArrowAlignment;
        public ArrowAlignment ArrowAlignment {
            get { return _ArrowAlignment; }
            set { _ArrowAlignment = value; }
        }
        public CustomDropDownButton()
            : base() {
            ArrowAlignment = ArrowAlignment.Right;
        }
        protected override BaseStyleControlViewInfo CreateViewInfo() {
            return new CustomDropDownButtonViewInfo(this);
        }
    }
    public class CustomDropDownButtonViewInfo : DropDownButtonViewInfo {

        public CustomDropDownButton OwnerButton {
            get {
                return base.Owner as CustomDropDownButton;
            }
        }
        public CustomDropDownButtonViewInfo(DropDownButton owner)
            : base(owner) {
        }
        protected override void CalcRects() {
            base.CalcRects();
            if (OwnerButton.ArrowAlignment == ArrowAlignment.Left && (OwnerButton.DropDownArrowStyle == DropDownArrowStyle.Default | OwnerButton.DropDownArrowStyle == DropDownArrowStyle.SplitButton)) {
                this.ButtonInfo.ArrowButtonInfo.Bounds = new Rectangle(this.ButtonInfo.BaseButtonInfo.Bounds.X, this.ButtonInfo.ArrowButtonInfo.Bounds.Y, this.ButtonInfo.ArrowButtonInfo.Bounds.Width, this.ButtonInfo.ArrowButtonInfo.Bounds.Height);
                this.ButtonInfo.BaseButtonInfo.Bounds = new Rectangle(this.ButtonInfo.BaseButtonInfo.Bounds.X + this.ButtonInfo.ArrowButtonInfo.Bounds.Width, this.ButtonInfo.BaseButtonInfo.Bounds.Y, this.ButtonInfo.BaseButtonInfo.Bounds.Width, this.ButtonInfo.BaseButtonInfo.Bounds.Height);
            }
        }
        protected override EditorButtonPainter GetButtonPainter() {
            if (OwnerButton.ArrowAlignment == ArrowAlignment.Left && this.OwnerButton.DropDownArrowStyle != DropDownArrowStyle.Hide)
                return GetCustomButtonPainter();
            return base.GetButtonPainter();
        }
        private EditorButtonPainter GetCustomButtonPainter() {
            if (this.OwnerButton.DropDownArrowStyle != DropDownArrowStyle.Default && this.OwnerButton.DropDownArrowStyle != DropDownArrowStyle.SplitButton) {
                return new CustomSkinEditorButtonPainter(this.LookAndFeel);
            }
            if (OwnerButton.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Skin && OwnerButton.ButtonStyle == BorderStyles.Default) {
                return new DropDownButtonPainter(new CustomSkinDropDownButtonPainter(OwnerButton.LookAndFeel));
            }
            return new DropDownButtonPainter(EditorButtonHelper.GetPainter(OwnerButton.ButtonStyle, OwnerButton.LookAndFeel));
        }

    }

    public class CustomSkinEditorButtonPainter : SkinEditorButtonPainter {
        public CustomSkinEditorButtonPainter(ISkinProvider provider)
            : base(provider) {
        }
        protected override void DrawDropDownArrow(EditorButtonObjectInfoArgs ee, Rectangle dropDownArrowRect) {
            dropDownArrowRect = new Rectangle(GetObjectClientRectangle(ee).Left + 1, dropDownArrowRect.Y, dropDownArrowRect.Width, dropDownArrowRect.Height);
            base.DrawDropDownArrow(ee, dropDownArrowRect);
        }
        bool lockDrawCaption;
        protected override bool CanDrawCaption(EditorButtonObjectInfoArgs e) {
            if (lockDrawCaption)
                return false;
            else
                return base.CanDrawCaption(e);
        }
        protected override void DrawContent(ObjectInfoArgs e) {
            DropDownButtonObjectInfoArgs args = e as DevExpress.XtraEditors.ViewInfo.DropDownButtonObjectInfoArgs;
            if (args != null) {
                if (args.Appearance.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near) {
                    lockDrawCaption = true;
                    base.DrawContent(e);
                    EditorButtonObjectInfoArgs ee = e as EditorButtonObjectInfoArgs;
                    Brush brush = GetForeBrush(ee);
                    Rectangle captionRect = this.GetObjectClientRectangle(e);
                    if (captionRect != Rectangle.Empty) {
                        captionRect.X += CalcDropDownArrowSize(ee).Width + args.BaseButtonInfo.Indent.Width + 4;
                        captionRect.Width -= CalcDropDownArrowSize(ee).Width;
                        StringFormat strFormat = ee.Appearance.GetStringFormat();
                        ButtonPainter.DrawCaption(args, args.Button.Caption, args.Appearance.Font, brush, captionRect, strFormat);
                    }
                    lockDrawCaption = false;
                }
                else
                    base.DrawContent(e);
            }
            else
                base.DrawContent(e);
        }
    }
    public class CustomSkinDropDownButtonPainter : SkinDropDownButtonPainter {
        public CustomSkinDropDownButtonPainter(ISkinProvider provider)
            : base(provider) {
        }
        protected override void DrawButton(ObjectInfoArgs e) {
            new RotateObjectPaintHelper().DrawRotated(e.Cache, GetButtonInfoArgs(e), ButtonPainter, RotateFlipType.RotateNoneFlipX);
        }
    }
    public enum ArrowAlignment { Left, Right };
}
