<%@ Page Title="MisPedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="TpFinalEquipo29.DatosTarjeta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Mis pedidos realizados</h2>
    <p>Este es el historial de pedidos asociados a tu cuenta.</p>
    <asp:GridView ID="gvHistorialCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
        <Columns>
            <asp:TemplateField HeaderText="Foto">
                <ItemTemplate>
                    <asp:Repeater ID="rptArticulos" runat="server" DataSource='<%# Eval("Detalles") %>'>
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgArticulo" CssClass="img-small" ImageUrl='<%# ResolveUrl("~/Imagenes/" + Eval("Imagenes[0].UrlImagen")) %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre y Unidades">
                <ItemTemplate>
                    <asp:Repeater ID="rptArticulosNombre" runat="server" DataSource='<%# Eval("Detalles") %>'>
                        <ItemTemplate>
                            <div class="info-articulo">
                                <asp:Label ID="lblNombreArticulo" runat="server" Text='<%# Eval("NombreArticulo") %>' CssClass="d-block font-weight-bold"></asp:Label>
                                <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label> unidad(es)
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Precio">
                <ItemTemplate>
                    <asp:Repeater ID="rptArticulosPrecio" runat="server" DataSource='<%# Eval("Detalles") %>'>
                        <ItemTemplate>
                            <asp:Label ID="lblPrecioUnitario" runat="server" Text='<%# Eval("PrecioUnitario", "{0:C}") %>' CssClass="d-block"></asp:Label>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("Envio")) ? "Pedido Entregado" : "En Proceso" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ver">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkVerDetalle" runat="server" Text="Ver +" NavigateUrl='<%# "~/DetalleCompra.aspx?PedidoId=" + Eval("Id") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <style>
    .img-small {
        width: 65px; /* para ajustar el tamaño de la foto */
        height: auto;
    }
</style>

</asp:Content>
