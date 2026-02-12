Option Infer On

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
	Protected Sub ModifyFilterExpression(ByVal FieldName As String, ByVal value As Object, ByVal targetGrid As ASPxGridView)
		Dim criteria = CriteriaColumnAffinityResolver.SplitByColumnNames(CriteriaOperator.Parse(targetGrid.FilterExpression)).Item2

		Dim co As CriteriaOperator = Nothing
		If FieldName = "ProductName" Then
			value &= "%"
			co = New FunctionOperator("Like", New OperandProperty(FieldName), New OperandValue(value))
		Else
			co = New BinaryOperator(FieldName, value, BinaryOperatorType.Equal)
		End If
		If Not criteria.Keys.Contains(FieldName) Then
			criteria.Add(FieldName, co)
		Else
			criteria(FieldName) = co
		End If
		targetGrid.FilterExpression = CriteriaOperator.ToString(GroupOperator.And(criteria.Values))
	End Sub

End Class
