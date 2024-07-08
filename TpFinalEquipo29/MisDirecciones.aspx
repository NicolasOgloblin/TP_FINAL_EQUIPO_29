<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisDirecciones.aspx.cs" Inherits="TpFinalEquipo29.MisDirecciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container mt-5">
        <h2 class="text-center">Mis direcciones</h2>
        <p class="text-center text-muted">Estas son tus direcciones almacenadas</p>
        
        <div class="mb-4">
            <h5>La siguiente es tu dirección de Residencia</h5>
            <div class="d-flex align-items-center border-bottom pb-3 mb-3">
                <div class="mr-3">
                    <i class="fas fa-map-marker-alt fa-2x"></i>
                </div>
                <div>
                    <p class="mb-1"><strong><asp:Label ID="lblResidenciaProvincia" runat="server" /></strong></p>
                    <p class="mb-1"><asp:Label ID="lblResidenciaLocalidad" runat="server" /></p>
                    <p class="mb-1"><asp:Label ID="lblResidenciaCalle" runat="server" /> <asp:Label ID="lblResidenciaAltura" runat="server" /></p>
                    <p class="mb-0"><asp:Label ID="lblResidenciaCodPostal" runat="server" /></p>
                    <p class="mb-0"><asp:Label ID="lblAltura" runat="server" /></p>
                </div>
                <div class="ml-auto">
                    <a href="EditarDireccion.aspx" class="btn btn-outline-primary mr-2">
                        <i class="fas fa-edit"></i> Cambiar
                        <a href="MetodoPago.aspx" class="btn btn-outline-primary mr-2">
                        <i class="fas fa-edit"></i> Confirmar
                    </a>
                </div>
            </div>
        </div>
        
       
        </div>
    



</asp:Content>
