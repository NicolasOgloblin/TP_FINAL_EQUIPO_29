<%@ Page Title="EditarDireccion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarDireccion.aspx.cs" Inherits="TpFinalEquipo29.EditarDireccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Editar una dirección</h2>
    <p>* Campos obligatorios</p>

    <div class="container">
        <div class="row">
            <div class="col-md-5 pr-md-1">
                <div class="form-group">
                    <label for="txtCalle">Calle:</label>
                    <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label for="txtNumero">Número:</label>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" />
                </div>
            
                <div class="form-group">
                    <label for="ddlProvincia">Provincia:</label>
                   <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="col-md-5 pl-md-1">
                <div class="form-group">
                    <label for="txtCiudad">Ciudad:</label>
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label for="txtCodigoPostal">Código Postal:</label>
                    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" />
                </div>
                
                <div class="form-group">
                    <label for="txtTelefono">Teléfono:</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                </div>
            
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Button ID="btnGuardarDireccion" runat="server" Text="GUARDAR DIRECCIÓN" CssClass="btn btn-primary" OnClick="btnGuardarDireccion_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
        </div>
        <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3" />
    </div>

</asp:Content>
