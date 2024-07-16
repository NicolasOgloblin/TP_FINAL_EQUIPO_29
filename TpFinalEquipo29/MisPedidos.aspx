<%@ Page Title="MisPedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="TpFinalEquipo29.DatosTarjeta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Mis pedidos realizados</h2>
    <p>Este es el historial de pedidos realizados.</p>
    <asp:GridView ID="gvHistorialCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowDataBound="gvHistorialCompras_RowDataBound">
        
           <Columns>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:Repeater ID="rptArticulos" runat="server" DataSource='<%# Eval("Detalles") %>'>
                    <ItemTemplate>
                        <asp:Image runat="server" ID="imgArticulo" CssClass="img-small" ImageUrl='<%# ResolveUrl("~/Imagenes/" + Eval("Imagenes[0].UrlImagen")) %>' />
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descripción">
            <ItemTemplate>
                <asp:Repeater ID="rptArticulosNombre" runat="server" DataSource='<%# Eval("Detalles") %>'>
                    <ItemTemplate>
                        <div class="info-articulo">
                            <asp:Label ID="lblNombreArticulo" runat="server" Text='<%# Eval("Articulo.Nombre") %>' CssClass="d-block font-weight-bold"></asp:Label>
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
                        <div class="info-precio">
                            <asp:Label ID="lblPrecioUnitario" runat="server" Text='<%# Eval("PrecioUnitario", "{0:C}") %>' CssClass="d-block"></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <asp:Label 
                ID="lblEstado" runat="server" Text='<%# Eval("EstadoPedido") %>' >
                    </asp:Label >
            </ItemTemplate>
            </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Medio de Pago/Monto Total">
            <ItemTemplate>
                <asp:Label ID="lblMetodoPago" runat="server" Text='<%# Eval("MetodoPago.Nombre") %>' CssClass="d-block"></asp:Label>
                <asp:Label ID="lblMontoTotal" runat="server" 
                    Text='<%# Eval("MontoTotal", "{0:C}") %>' 
                    CssClass="d-block"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    
        </Columns>
    </asp:GridView>

    <style>

        .img-small {
            width: 65px; 
            height: auto;
        }
         .estado-verde {
        color: green;
        font-weight: bold;
    }
    .estado-rojo {
        color: red;
        font-weight: bold;
    }
    .estado-naranja-fuerte {
        color: darkorange;
        font-weight: bold;
    }
    
</style>

</asp:Content>
