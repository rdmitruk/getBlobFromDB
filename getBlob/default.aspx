<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="getBlob._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="btnGetFile" Text="Get File" OnClick="btnGetFile_Click" />
        <br />
        <br />
        <br />
        <asp:Label runat="server" ID="lblTitle" />
    </div>
    </form>
</body>
</html>
