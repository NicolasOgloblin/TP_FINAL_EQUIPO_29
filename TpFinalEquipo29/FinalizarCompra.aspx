<%@ Page Title="Finalizar Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="TpFinalEquipo29.FinalizarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 text-center">
                <h2>Finalizar Compra</h2>
                <img src='<%= ResolveUrl("~/Imagenes/mercadopago.png") %>' alt="Mercado Pago" class="img-fluid my-4" />
                <div class="alert alert-info">
                    <h4 class="alert-heading">Alias de Transferencia</h4>
                    <p>Transferir al siguiente alias:</p>
                    <asp:Label ID="lblAlias" runat="server" CssClass="h5"></asp:Label>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
