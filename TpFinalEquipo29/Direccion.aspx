<%@ Page Title="Direccion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Direccion.aspx.cs" Inherits="TpFinalEquipo29.Direccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
 <!-- Contenido de las direcciones existentes -->

    <h2>Mis direcciones</h2>
    
    <!-- Dirección de Residencia -->
    <div>
        <h3>Dirección de Residencia</h3>
        <p>
            
              <a href="EditarDireccion.aspx">Editar</a> | <a href="#">Eliminar</a>
        </p>
    </div>

    <!-- Formulario de Edición -->

    <div id="editForm" style="display: none;">
        <h3>Editar una dirección</h3>
        <p>* Campos obligatorios</p>
        <div>
            <label>Calle:</label>
            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" /><br />
            
          
            
            <asp:Button ID="btnGuardarDireccion" runat="server" Text="GUARDAR DIRECCIÓN" CssClass="btn btn-primary" OnClick="btnGuardarDireccion_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
        </div>
    </div>

   
    <div class="mt-3">
        <asp:Button ID="btnAgregarDireccion" runat="server" Text="AGREGAR UNA NUEVA DIRECCIÓN" CssClass="btn btn-success" OnClick="btnAgregarDireccion_Click" />
    </div>



</asp:Content>
