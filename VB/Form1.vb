Imports CustomDropDown
Imports System

Namespace DropDownButton
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Me.comboBoxEdit1.Properties.Items.AddRange(System.Enum.GetValues(GetType(DevExpress.XtraEditors.DropDownArrowStyle)))
			Me.comboBoxEdit1.SelectedIndex = 0
		End Sub
		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles flipBtn.Click
			Me.customDropDownButton1.ArrowAlignment = If(Me.customDropDownButton1.ArrowAlignment = ArrowAlignment.Right, ArrowAlignment.Left, ArrowAlignment.Right)
			Me.customDropDownButton1.Refresh()
		End Sub
		Private Sub comboBoxEdit1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxEdit1.SelectedIndexChanged
			Me.customDropDownButton1.DropDownArrowStyle = DirectCast(Me.comboBoxEdit1.SelectedItem, DevExpress.XtraEditors.DropDownArrowStyle)
			Me.customDropDownButton1.Refresh()
		End Sub
	End Class
End Namespace
