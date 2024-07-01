<%@ Page Title="DatosPersonales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="TpFinalEquipo29.DatosPersonales" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="container mt-5">
        <h2>Mis datos personales</h2>
        <div class="row g-3">
            <div class="col-md-6">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                <span class="text-danger">*</span>
            </div>
            <div class="col-md-6">
                <label for="txtApellido" class="form-label">Apellido:</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                <span class="text-danger">*</span>
            </div>
            <div class="col-12">
                <label for="txtDNI" class="form-label">DNI:</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" />
                <span class="text-danger">*</span>
            </div>
            <%--<div class="col-12">
                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento:</label>
                <!-- Comentado por ahora, no implementado en la base de datos
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" />
                -->
                <input type="text" class="form-control" placeholder="dd/mm/aaaa" disabled />
                <span class="text-muted">No implementado aún</span>
            </div>--%>
            <div class="col-12">
                <label for="txtTelefono" class="form-label">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                <span class="text-danger">*</span>
            </div>
            <div class="col-12">
                <asp:Button ID="btnGuardarCambios" runat="server" CssClass="btn btn-primary" Text="Guardar Cambios" OnClick="btnGuardarCambios_Click" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary ms-2" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
            </div>
            <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3" />
        </div>
    </div>

</asp:Content>
