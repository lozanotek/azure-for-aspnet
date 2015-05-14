<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewVideo.aspx.cs" Inherits="Orwell.Manager.NewVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orwell Manager -- New Video</title>
</head>
<body>
    <h2>Orwell Data Manager</h2>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="OrwellSqlDataSource" runat="server"
            DeleteCommand="DELETE FROM Videos WHERE (Id = @id)"
            InsertCommand="INSERT INTO Videos(Title, [Key]) VALUES (@title, @key)">

            <InsertParameters>
                <asp:Parameter Name="title" />
                <asp:Parameter Name="key" />
            </InsertParameters>
        </asp:SqlDataSource>
        <div>
            <table>
                <tbody>
                    <tr>
                        <td><strong>Title</strong></td>
                        <td>
                            <asp:TextBox runat="server" ID="TitleTexBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Key</strong></td>
                        <td>
                            <asp:TextBox runat="server" ID="KeyTextBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button runat="server" ID="AddButton" OnClick="AddButton_OnClick" Text="Add" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
