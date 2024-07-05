<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCompleto.aspx.cs" Inherits="TpFinalEquipo29.EditarCompleto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar Artículo</h2>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>

   
    <div class="form-group">
        <label>ID:</label>
        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <label>Código:</label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Categoría:</label>
        <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label>Precio:</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Marca:</label>
        <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label>Stock:</label>
        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Peso:</label>
        <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Ancho:</label>
        <asp:TextBox ID="txtAncho" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Alto:</label>
        <asp:TextBox ID="txtAlto" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Color:</label>
        <asp:TextBox ID="txtColor" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Modelo:</label>
        <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Origen:</label>
        <asp:TextBox ID="txtOrigen" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Garantía (Años):</label>
        <asp:TextBox ID="txtGarantiaAnios" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Garantía (Meses):</label>
        <asp:TextBox ID="txtGarantiaMeses" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    
    <asp:Label ID="lblNuevasImagenes" runat="server" Text="Nuevas imágenes:"></asp:Label>
    <asp:FileUpload ID="fuNuevasImagenes" runat="server" AllowMultiple="true" CssClass="form-control" />
    <br />
    
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" CssClass="btn btn-outline-success" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-info" />
</asp:Content>

