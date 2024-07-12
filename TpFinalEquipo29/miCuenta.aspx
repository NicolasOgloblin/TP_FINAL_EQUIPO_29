<%@ Page Title="MiCuenta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="miCuenta.aspx.cs" Inherits="TpFinalEquipo29.miCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container my-5">
        <h2 class="text-center mb-4">MI CUENTA</h2>
        
        <div class="row justify-content-center mb-3">
            <div class="col-md-6 text-center">
                <p class="font-weight-bold">Correo Electrónico: <asp:Label ID="lblEmail" runat="server" CssClass="font-weight-bold"></asp:Label></p>
            </div>
        </div>
        
        <div class="row">
           <div class="col-md-6 mb-3">
              <div class="card shadow-sm">
                  <div class="card-body text-center">
                        <h5 class="card-title">MIS DATOS PERSONALES</h5>
                    <a href="DatosPersonales.aspx" class="btn btn-outline-success"><i class="fas fa-user-edit"></i> Ver y Cambiar</a>
              </div>
                </div>
            </div>
            
         <div class="col-md-6 mb-3">
             <div class="card shadow-sm">
                    <div class="card-body text-center">
                   <h5 class="card-title">MIS DIRECCIONES</h5>
                        <a href="EditarDireccion.aspx" class="btn btn-outline-success"><i class="fas fa-map-marker-alt"></i> Cambiar Dirección</a>
              </div>
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-6 mb-3">
                <div class="card shadow-sm">
                    <div class="card-body text-center">
                        <h5 class="card-title">CAMBIAR CONTRASEÑA</h5>
                        <a href="CambiarContraseña.aspx" class="btn btn-outline-success"><i class="fas fa-key"></i> Modificar</a>
                    </div>
                </div>
            </div>
            

            <div class="col-md-6 mb-3">
             <div class="card shadow-sm">
                    <div class="card-body text-center">
                  <h5 class="card-title">CAMBIAR EMAIL</h5>
                        <a href="ModificarMail.aspx" class="btn btn-outline-success"><i class="fas fa-envelope"></i> Modificar Email</a>
                </div>
               </div>
          </div>
        </div>
        
        <div class="row">
            <div class="col-md-6 mb-3">
            <div class="card shadow-sm">
               <div class="card-body text-center">
                 <h5 class="card-title">Mis Compras</h5>
                        <a href="MisPedidos.aspx" class="btn btn-outline-success"><i class="fas fa-shopping-cart"></i> Ver Mas</a>
             </div>
          </div>
            </div>
        </div>
    </div>
     <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet"> 
</asp:Content>