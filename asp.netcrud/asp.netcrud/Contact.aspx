<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="asp.netcrud.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfContactID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                    <tr>
                        <td></td>
                        <td colspan="2">
                            <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </tr>
            </table>
            <br />

            <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false">
                <Columns>

                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />


                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ContactID") %>'>View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>


<!-- 
    HiddenField 
     : 표시되지 않은 값을 저장하는데 사용되는 숨겨진 필드 

    colspan
     : 열 확장(합치기)

    BoundField
     : 데이터 바인딩 된 컨트롤에 텍스트로 표시되는 필드

    DataField
     : BoundField 개체에 바인딩할 데이터 필드의 이름을 가져오거나 설정

    HeaderText
     : 데이터 컨트롤의 머리글에 표시되는 텍스트를 가져오거나 설정

    TemplateField 
      : 데이터 바인딩 된 컨트롤에서 사용자 지정 콘텐츠를 표시하는 필드
                    
    ItemTemplate
      : 데이터 바인딩된 컨트롤에 항목을 표시하기 위한 템플릿을 가져오거나 설정

    AutoGenerateColumns
      : 데이터 소스의 각 필드에 대해 바인딩 된 필드가 자동으로 만들어지는지의 여부
-->
