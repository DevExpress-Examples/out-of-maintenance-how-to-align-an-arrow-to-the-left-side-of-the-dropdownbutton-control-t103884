Namespace DropDownButton
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.flipBtn = New DevExpress.XtraEditors.SimpleButton()
			Me.comboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.customDropDownButton1 = New CustomDropDown.CustomDropDownButton()
			DirectCast(Me.comboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' flipBtn
			' 
			Me.flipBtn.Location = New System.Drawing.Point(200, 12)
			Me.flipBtn.Name = "flipBtn"
			Me.flipBtn.Size = New System.Drawing.Size(152, 46)
			Me.flipBtn.TabIndex = 1
			Me.flipBtn.Text = "Change Arrow Alignment"
'			Me.flipBtn.Click += New System.EventHandler(Me.simpleButton1_Click)
			' 
			' comboBoxEdit1
			' 
			Me.comboBoxEdit1.Location = New System.Drawing.Point(74, 38)
			Me.comboBoxEdit1.Name = "comboBoxEdit1"
			Me.comboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.comboBoxEdit1.Size = New System.Drawing.Size(120, 20)
			Me.comboBoxEdit1.TabIndex = 3
'			Me.comboBoxEdit1.SelectedIndexChanged += New System.EventHandler(Me.comboBoxEdit1_SelectedIndexChanged)
			' 
			' labelControl1
			' 
			Me.labelControl1.Location = New System.Drawing.Point(12, 41)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(56, 13)
			Me.labelControl1.TabIndex = 4
			Me.labelControl1.Text = "Arrow Style"
			' 
			' customDropDownButton1
			' 
			Me.customDropDownButton1.Appearance.Options.UseTextOptions = True
			Me.customDropDownButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
			Me.customDropDownButton1.ArrowAlignment = CustomDropDown.ArrowAlignment.Right
			Me.customDropDownButton1.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
			Me.customDropDownButton1.Location = New System.Drawing.Point(12, 12)
			Me.customDropDownButton1.Name = "customDropDownButton1"
			Me.customDropDownButton1.Size = New System.Drawing.Size(182, 23)
			Me.customDropDownButton1.TabIndex = 2
			Me.customDropDownButton1.Text = "СustomDropDownButton"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(366, 70)
			Me.Controls.Add(Me.labelControl1)
			Me.Controls.Add(Me.comboBoxEdit1)
			Me.Controls.Add(Me.customDropDownButton1)
			Me.Controls.Add(Me.flipBtn)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load)
			DirectCast(Me.comboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents flipBtn As DevExpress.XtraEditors.SimpleButton
		Private customDropDownButton1 As CustomDropDown.CustomDropDownButton
		Private WithEvents comboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
		Private labelControl1 As DevExpress.XtraEditors.LabelControl


	End Class
End Namespace

