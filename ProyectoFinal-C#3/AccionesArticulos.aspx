<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="AccionesArticulos.aspx.cs" Inherits="ProyectoFinal_C_3.AccionesArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1> Cards Articulos </h1>
    </div>
    <asp:GridView runat="server" ID="dgvArticulos" CssClass="table table-bordered table-hover table-striped-columns table-dark" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="que dato quiero que muestre" DataField="Nombre de la propiedad del objeto que cargo" />
        </Columns>
    </asp:GridView>
</asp:Content>
