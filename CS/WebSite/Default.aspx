﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnClick(s, e) {
            grid.PerformCallback();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="grid" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1" KeyFieldName="ProductID" OnCustomCallback="ASPxGridView1_CustomCallback">
                <Settings ShowFilterBar="Visible" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" />
                    <dx:GridViewDataTextColumn FieldName="ProductName" />
                    <dx:GridViewDataTextColumn FieldName="CategoryID" />
                    <dx:GridViewDataTextColumn FieldName="QuantityPerUnit" />
                    <dx:GridViewDataTextColumn FieldName="UnitPrice" />
                    <dx:GridViewDataTextColumn FieldName="UnitsInStock" />
                </Columns>
            </dx:ASPxGridView>
            <table>
                <tr>
                    <td>Filter by:
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String">
                            <Items>
                                <dx:ListEditItem Value="ProductID" />
                                <dx:ListEditItem Value="ProductName" />
                                <dx:ListEditItem Value="CategoryID" />
                                <dx:ListEditItem Value="QuantityPerUnit" />
                                <dx:ListEditItem Value="UnitPrice" />
                                <dx:ListEditItem Value="UnitsInStock" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px" />
                    </td>
                    <td>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Filter" AutoPostBack="false">
                            <ClientSideEvents Click="OnClick" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Categories + products.mdb" SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock] FROM [Products]"></asp:AccessDataSource>
        </div>
    </form>
</body>
</html>
