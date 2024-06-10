<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TpFinalEquipo29.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <h2>Registro de Usuario</h2>
            <div class="form-group">
                <label for="txtNombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtApellido">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese su apellido"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDNI">DNI</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese su DNI"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUsuario">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su nombre de usuario"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtContrasenia">Contraseña</label>
                <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese su contraseña"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingrese su email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtProvincia">Provincia</label>
                <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" placeholder="Ingrese Provincia"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtLocalidad">Localidad</label>
                <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" placeholder="Ingrese su Localidad"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCalle">Calle</label>
                <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="Ingrese su calle"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtAltura">Altura</label>
                <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control" placeholder="Ingrese la altura"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCodPostal">Codigo Postal</label>
                <asp:TextBox ID="txtCodPostal" runat="server" CssClass="form-control" placeholder="Ingrese Codigo Postal"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTelefono">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese su teléfono"></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnRegistrar_Click" />
            </div>
    </div>

</asp:Content>
