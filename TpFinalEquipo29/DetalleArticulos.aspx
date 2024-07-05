<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulos.aspx.cs" Inherits="TpFinalEquipo29.DetalleArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Detalles del Artículo</h2>
        <div class="row">
            <div class="col-md-6">
                <!-- Carrusel de Imágenes -->
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-indicators">
                        <asp:Literal ID="litCarouselIndicators" runat="server" />
                    </div>
                    <div class="carousel-inner">
                        <asp:Literal ID="litCarouselImages" runat="server" />
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            </div>
            <div class="col-md-6">
                <!-- Detalles del artículo -->
                <h3><asp:Literal ID="litNombre" runat="server" /></h3>
                <br />
                <p>Precio: <b>$<asp:Literal ID="litPrecio" runat="server" /></b></p>
                
                <p>Stock: <b><asp:Literal ID="litStock" runat="server" /></b></p>
                <asp:LinkButton ID="btnAgregarDetalle" runat="server" CssClass="btn btn-success" OnClick="btnAgregarDetalle_Click" CommandArgument='<%# Eval("Id") %>' Text="Agregar al carrito" />
            </div>
            
            <div class="col-md-9">
                <!-- Panel de Ficha Técnica -->
              <div id="panelFichaTecnica" runat="server" class="card p-3 mb-3">
                    <h4>Descripción :</h4>
                    <p><asp:Literal ID="litDescripcion" runat="server" /></p>
                    <h4>Ficha Técnica :</h4>
                    <table class="table table-striped">
                        <tr>
                            <td class="attrib">Categoría</td>
                            <td><asp:Literal ID="litCategoria" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="attrib">Marca</td>
                            <td><asp:Literal ID="litMarca" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="attrib">Alto</td>
                            <td><asp:Literal ID="LitAlto" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="attrib">Peso</td>
                            <td><asp:Literal ID="LitPeso" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="attrib">Ancho</td>
                            <td><asp:Literal ID="LitAncho" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="attrib">Color</td>
                            <td><asp:Literal ID="LitColor" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="attrib">Modelo</td>
                            <td><asp:Literal ID="LitModelo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="attrib">Origen</td>
                            <td><asp:Literal ID="LitOrigen" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="attrib">Meses de Garantía</td> 
                            <td><asp:Literal ID="LitGarantia" runat="server" /></td> 
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
