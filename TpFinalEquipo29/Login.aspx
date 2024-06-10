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
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Password</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
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
