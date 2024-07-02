<%@ Page Title="Direccion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Direccion.aspx.cs" Inherits="TpFinalEquipo29.Direccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
 <!-- Contenido de las direcciones existentes -->

    <h2>Mis direcciones</h2>
    <p>Estas son tus direcciones almacenadas:</p>

    <!-- Dirección de Residencia -->
    <div>
        <h3>Dirección de Residencia</h3>
        <p>
            BELEN DE ESCOBAR, ESCOBAR<br />
            COMPLETAR DIRECCIÓN<br />
            Argentina (1625)<br />
            <a href="#" onclick="mostrarFormularioEdicion();">Editar</a> | <a href="#">Eliminar</a>
        </p>
    </div>

    <!-- Direcciones de Entrega/Facturación -->
    <div>
        <h3>Direcciones de Entrega/Facturación</h3>
        <p>
            Depto<br />
            BELEN DE ESCOBAR, ESCOBAR<br />
            MORENO, 832, Buenos Aires<br />
            Argentina (1625)<br />
            <a href="#" onclick="mostrarFormularioEdicion();">Editar</a> | <a href="#">Eliminar</a>
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


<%--<script>
    function mostrarFormularioEdicion() {
        document.getElementById("editForm").style.display = "block";
        // Aquí puedes agregar lógica adicional si es necesario
    }
</script>--%>

</asp:Content>
