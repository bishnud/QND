<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookupField.aspx.cs" Inherits="SharePoint.CSOM.Pages.LookupField" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .result-grid { border-collapse: collapse; font-family: sans-serif; font-size: 15px; border: 1px solid #d3d3d3; }
        .result-grid tr, .result-grid tr th, .result-grid tr td { border: 1px solid #d3d3d3; padding: 2px 16px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="contentPanel" runat="server"></asp:Panel>
    </form>
</body>
</html>
