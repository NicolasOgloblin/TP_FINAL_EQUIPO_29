<%@ Page Title="Finalizar Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="TpFinalEquipo29.FinalizarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 text-center">
                <h2>Finalizar Compra</h2>
                <img src='<%= ResolveUrl("~/Imagenes/mercadopago.png") %>' alt="Mercado Pago" class="img-fluid my-4" />
                <div class="alert alert-info">
                    <h4 class="alert-heading">Alias de Transferencia</h4>
                    <p>Transferir al siguiente alias: <b>ALIAS.FICTICIO.MP</b> </p>
                    <asp:Label ID="lblAlias" runat="server" CssClass="h5"></asp:Label>

                    <p>
                        Enviar comprobante de pago a: 
                        <img src='<%= ResolveUrl("~/Imagenes/WhatsApp_icon.png") %>' alt="WhatsApp" style="width:24px; height:24px; vertical-align:middle; margin-right:5px;" />
                        <b>1144323565</b>
                    </p>

                </div>
                <asp:Button ID="btnMisPedidos" runat="server" CssClass="btn btn-success mt-4" Text="Ver Mis Pedidos" OnClick="btnMisPedidos_Click" />
            </div>
        </div>
    </div>
</asp:Content>

