<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulos.aspx.cs" Inherits="TpFinalEquipo29.DetalleArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Detalles del Artículo</h2>
        <div class="row">
            <div class="col-md-6">
                <!-- Carrusel de Imágenes -->
                <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <asp:Literal ID="litCarouselIndicators" runat="server" />
                    </ol>
                    <div class="carousel-inner">
                        <asp:Literal ID="litCarouselImages" runat="server" />
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
            <div class="col-md-6">
                <!-- Detalles del artículo -->
                <h3><asp:Literal ID="litNombre" runat="server" /></h3>
                <p>Precio: <b>$<asp:Literal ID="litPrecio" runat="server" /></b></p>
                <asp:LinkButton ID="btnAgregarDetalle" runat="server" CssClass="btn btn-success" OnClick="btnAgregarDetalle_Click" CommandArgument='<%# Eval("Id") %>' Text="Agregar al carrito" />
            </div>
            <div class="col-md-12">
                <!-- Panel de Ficha Técnica -->
                <div id="panelFichaTecnica" runat="server" class="card p-4 mb-4">
                    <h4>Descripción</h4>
                    <p><asp:Literal ID="litDescripcion" runat="server" /></p>
                    <h4>Ficha Técnica:</h4>
                    <ul class="list-group">
                        <li class="list-group-item"><h4>Categoría:</h4> <p><asp:Literal ID="litCategoria" runat="server" /></p></li>
                        <li class="list-group-item"><h4>Marca:</h4> <p><asp:Literal ID="litMarca" runat="server" /></p></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
