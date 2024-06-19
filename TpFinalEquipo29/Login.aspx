<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpFinalEquipo29.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center align-items-center min-vh-100">
    <div class="row w-100">
        <div class="col-md-6 col-lg-4 mx-auto">
            <div class="card shadow">
                <div class="card-body">
                    <h2 class="text-center mb-4">Login</h2>
                    <div class="mb-3">
                        <label class="form-label">Usuario</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" />
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="El campo Usuario es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Contraseña</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtContrasenia" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="El campo Contraseña es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="d-grid">
                        <asp:LinkButton Text="Ingresar" CssClass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
                    </div>
                    <div class="text-center mt-3">
                        <a href="Registro.aspx">¿No tienes cuenta? Regístrate</a>
                    </div>
                    <div class="text-center mt-2">
                        <a href="">¿Olvidaste tu contraseña?</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
