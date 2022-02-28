<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WfmVehiculos.aspx.cs" Inherits="Presentacion.WebForms.Administracion.Vehiculos.WfmVehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div align="center">
        <h1>
            <asp:Label runat="server" Text="Vehiculos"/>
        </h1>
        <br/>

        <asp:GridView ID="gdvVehiculos" runat="server" CellPadding="5" Height="118px" Width="427px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

       <br/>

    </div>

</asp:Content>
