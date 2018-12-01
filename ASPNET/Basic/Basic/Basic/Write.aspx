<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Write.aspx.cs" Inherits="Basic.Basic.Write" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>기본형 게시판 글쓰기</h2>

    <asp:HyperLink ID="lnkList" runat="server"
        CssClass="btn btn-primary"
        NavigateUrl="List.aspx">
        리스트
    </asp:HyperLink>
</asp:Content>
