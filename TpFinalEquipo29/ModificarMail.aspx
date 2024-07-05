<%@ Page Title="ModificarMail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarMail.aspx.cs" Inherits="TpFinalEquipo29.ModificarMail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div class="container mt-5">
        <h2>Modificar E-Mail</h2>
        <p>* Campos obligatorios</p>
        <hr />

        <div class="row g-3">
            <div class="col-12">
                <label for="txtEmailActual" class="form-label">Email actual:</label>
                <asp:TextBox ID="txtEmailActual" runat="server" CssClass="form-control" Text="maxivs_93@hotmail.com" ReadOnly="true" />
            </div>
        </div>

        <div class="row g-3 mt-3">
            <div class="col-12">
                <label for="txtNuevoEmail" class="form-label">Nueva Dirección de Email <span class="text-danger">*</span>:</label>
                <asp:TextBox ID="txtNuevoEmail" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvNuevoEmail" runat="server" ControlToValidate="txtNuevoEmail" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="ModificarEmail" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtNuevoEmail" ErrorMessage="Formato de Email no válido" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row g-3 mt-3">
            <div class="col-12">
                <label for="txtConfirmarEmail" class="form-label">Confirma tu nueva dirección de Email <span class="text-danger">*</span>:</label>
                <asp:TextBox ID="txtConfirmarEmail" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvConfirmarEmail" runat="server" ControlToValidate="txtConfirmarEmail" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="ModificarEmail" />
                <asp:CompareValidator ID="cvEmails" runat="server" ControlToCompare="txtNuevoEmail" ControlToValidate="txtConfirmarEmail" ErrorMessage="Los emails no coinciden." ForeColor="Red" ValidationGroup="ModificarEmail" />
                <asp:RegularExpressionValidator ID="revEmailConfirmar" runat="server" ControlToValidate="txtConfirmarEmail" ErrorMessage="Formato de Email no válido" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row g-3 mt-3">
            <div class="col-12">
                <asp:Button ID="btnGuardarCambios" runat="server" CssClass="btn btn-primary" Text="Guardar Cambios" OnClick="btnGuardarCambios_Click" ValidationGroup="ModificarEmail" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary ms-2" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-12">
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />
            </div>
        </div>
    </div>



</asp:Content>
