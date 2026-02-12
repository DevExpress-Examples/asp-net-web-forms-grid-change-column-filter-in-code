Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Data.Filtering
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		ModifyFilterExpression(ASPxComboBox1.Value.ToString(), ASPxTextBox1.Value, grid)
	End Sub
	Protected Sub ModifyFilterExpression(ByVal FieldName As String, ByVal value As Object, ByVal victim As ASPxGridView)
		Dim criterias = CriteriaColumnAffinityResolver.SplitByColumns(CriteriaOperator.Parse(victim.FilterExpression))

		Dim co As CriteriaOperator = Nothing
		If FieldName = "ProductName" Then
			value &= "%"
			co = New FunctionOperator("Like", New OperandProperty(FieldName), New OperandValue(value))
		Else
			co = New BinaryOperator(FieldName, value, BinaryOperatorType.Equal)
		End If
		If Not criterias.Keys.Contains(New OperandProperty(FieldName)) Then
			criterias.Add(New OperandProperty(FieldName), co)
		Else
			criterias(New OperandProperty(FieldName)) = co
		End If
		victim.FilterExpression = CriteriaOperator.ToString(GroupOperator.And(criterias.Values))
	End Sub

End Class