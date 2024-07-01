<%@ Page Title="MiCuenta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="miCuenta.aspx.cs" Inherits="TpFinalEquipo29.miCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="container">
        <h2 class="text-center">MI CUENTA</h2>
        
        <div class="row justify-content-center">
            <div class="col-md-6">
                <p class="text-center">Correo Electrónico: <asp:Label ID="lblEmail" runat="server" CssClass="font-weight-bold"></asp:Label></p>
            </div>
        </div>
        
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card mb-3">
                    <div class="card-body">
                        <h5 class="card-title">MIS DATOS PERSONALES</h5>
                        <a href="DatosPersonales.aspx" class="btn btn-primary">Visualizar y Editar</a>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card mb-3">
                    <div class="card-body">
                        <h5 class="card-title">MIS DIRECCIONES</h5>
                        <a href="Direccion.aspx" class="btn btn-primary">Crear y Editar</a>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card mb-3">
                    <div class="card-body">
                        <h5 class="card-title">CAMBIAR CONTRASEÑA</h5>
                        <a href="CambiarContraseña.aspx" class="btn btn-primary">Modificar</a>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
      
</asp:Content>