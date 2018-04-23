Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports System.ComponentModel
Imports System.Drawing

Namespace CustomDropDown
	<ToolboxItem(True)>
	Public Class CustomDropDownButton
		Inherits DropDownButton

		' Fields...
		Private _ArrowAlignment As ArrowAlignment
		Public Property ArrowAlignment() As ArrowAlignment
			Get
				Return _ArrowAlignment
			End Get
			Set(ByVal value As ArrowAlignment)
				_ArrowAlignment = value
			End Set
		End Property
		Public Sub New()
			MyBase.New()
			ArrowAlignment = ArrowAlignment.Right
		End Sub
		Protected Overrides Function CreateViewInfo() As BaseStyleControlViewInfo
			Return New CustomDropDownButtonViewInfo(Me)
		End Function
	End Class
	Public Class CustomDropDownButtonViewInfo
		Inherits DropDownButtonViewInfo

		Public ReadOnly Property OwnerButton() As CustomDropDownButton
			Get
				Return TryCast(MyBase.Owner, CustomDropDownButton)
			End Get
		End Property
		Public Sub New(ByVal owner As DropDownButton)
			MyBase.New(owner)
		End Sub
		Protected Overrides Sub CalcRects()
			MyBase.CalcRects()
			If OwnerButton.ArrowAlignment = ArrowAlignment.Left AndAlso (OwnerButton.DropDownArrowStyle = DropDownArrowStyle.Default Or OwnerButton.DropDownArrowStyle = DropDownArrowStyle.SplitButton) Then
				Me.ButtonInfo.ArrowButtonInfo.Bounds = New Rectangle(Me.ButtonInfo.BaseButtonInfo.Bounds.X, Me.ButtonInfo.ArrowButtonInfo.Bounds.Y, Me.ButtonInfo.ArrowButtonInfo.Bounds.Width, Me.ButtonInfo.ArrowButtonInfo.Bounds.Height)
				Me.ButtonInfo.BaseButtonInfo.Bounds = New Rectangle(Me.ButtonInfo.BaseButtonInfo.Bounds.X + Me.ButtonInfo.ArrowButtonInfo.Bounds.Width, Me.ButtonInfo.BaseButtonInfo.Bounds.Y, Me.ButtonInfo.BaseButtonInfo.Bounds.Width, Me.ButtonInfo.BaseButtonInfo.Bounds.Height)
			End If
		End Sub
		Protected Overrides Function GetButtonPainter() As EditorButtonPainter
			If OwnerButton.ArrowAlignment = ArrowAlignment.Left AndAlso Me.OwnerButton.DropDownArrowStyle <> DropDownArrowStyle.Hide Then
				Return GetCustomButtonPainter()
			End If
			Return MyBase.GetButtonPainter()
		End Function
		Private Function GetCustomButtonPainter() As EditorButtonPainter
			If Me.OwnerButton.DropDownArrowStyle <> DropDownArrowStyle.Default AndAlso Me.OwnerButton.DropDownArrowStyle <> DropDownArrowStyle.SplitButton Then
				Return New CustomSkinEditorButtonPainter(Me.LookAndFeel)
			End If
			If OwnerButton.LookAndFeel.ActiveStyle = ActiveLookAndFeelStyle.Skin AndAlso OwnerButton.ButtonStyle = BorderStyles.Default Then
				Return New DropDownButtonPainter(New CustomSkinDropDownButtonPainter(OwnerButton.LookAndFeel))
			End If
			Return New DropDownButtonPainter(EditorButtonHelper.GetPainter(OwnerButton.ButtonStyle, OwnerButton.LookAndFeel))
		End Function

	End Class

	Public Class CustomSkinEditorButtonPainter
		Inherits SkinEditorButtonPainter

		Public Sub New(ByVal provider As ISkinProvider)
			MyBase.New(provider)
		End Sub
		Protected Overrides Sub DrawDropDownArrow(ByVal ee As EditorButtonObjectInfoArgs, ByVal dropDownArrowRect As Rectangle)
			dropDownArrowRect = New Rectangle(GetObjectClientRectangle(ee).Left + 1, dropDownArrowRect.Y, dropDownArrowRect.Width, dropDownArrowRect.Height)
			MyBase.DrawDropDownArrow(ee, dropDownArrowRect)
		End Sub
		Private lockDrawCaption As Boolean
		Protected Overrides Function CanDrawCaption(ByVal e As EditorButtonObjectInfoArgs) As Boolean
			If lockDrawCaption Then
				Return False
			Else
				Return MyBase.CanDrawCaption(e)
			End If
		End Function
		Protected Overrides Sub DrawContent(ByVal e As ObjectInfoArgs)
			Dim args As DropDownButtonObjectInfoArgs = TryCast(e, DevExpress.XtraEditors.ViewInfo.DropDownButtonObjectInfoArgs)
			If args IsNot Nothing Then
				If args.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near Then
					lockDrawCaption = True
					MyBase.DrawContent(e)
					Dim ee As EditorButtonObjectInfoArgs = TryCast(e, EditorButtonObjectInfoArgs)
					Dim brush As Brush = GetForeBrush(ee)
					Dim captionRect As Rectangle = Me.GetObjectClientRectangle(e)
					If captionRect <> Rectangle.Empty Then
						captionRect.X += CalcDropDownArrowSize(ee).Width + args.BaseButtonInfo.Indent.Width + 4
						captionRect.Width -= CalcDropDownArrowSize(ee).Width
						Dim strFormat As StringFormat = ee.Appearance.GetStringFormat()
						ButtonPainter.DrawCaption(args, args.Button.Caption, args.Appearance.Font, brush, captionRect, strFormat)
					End If
					lockDrawCaption = False
				Else
					MyBase.DrawContent(e)
				End If
			Else
				MyBase.DrawContent(e)
			End If
		End Sub
	End Class
	Public Class CustomSkinDropDownButtonPainter
		Inherits SkinDropDownButtonPainter

		Public Sub New(ByVal provider As ISkinProvider)
			MyBase.New(provider)
		End Sub
		Protected Overrides Sub DrawButton(ByVal e As ObjectInfoArgs)
			CType(New RotateObjectPaintHelper(), RotateObjectPaintHelper).DrawRotated(e.Cache, GetButtonInfoArgs(e), ButtonPainter, RotateFlipType.RotateNoneFlipX)
		End Sub
	End Class
	Public Enum ArrowAlignment
		Left
		Right
	End Enum
End Namespace
