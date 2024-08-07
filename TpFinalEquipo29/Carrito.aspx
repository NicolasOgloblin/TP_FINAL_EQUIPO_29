﻿<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TpFinalEquipo29.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    

 <div class="container">
     <h2 class="mt-4">Carrito de Compras</h2>
     <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="Id">
         <Columns>


      <asp:TemplateField HeaderText="">
              <ItemTemplate>


          <asp:Image ID="ImgArticulo" runat="server" CssClass="img-small" ImageUrl='<%# ResolveUrl("~/Imagenes/" + Eval("Imagenes[0].UrlImagen")) %>' />
               </ItemTemplate>
       </asp:TemplateField>

             <asp:BoundField DataField="Nombre" HeaderText="Productos" />
             <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
             <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
             <asp:TemplateField HeaderText="Cantidad">
                 <ItemTemplate>
                     <div class="input-group">
                         <asp:LinkButton ID="btnDecrementar" runat="server" CommandArgument='<%# Eval("Id") %>' Text="-" CssClass="btn btn-outline-secondary" OnClick="btnDecrementar_Click" style="width: -5px;" />
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("Stock") %>' CssClass="form-control text-center" style="width: -5px;" />
            <div class="input-group-append">
                <asp:LinkButton ID="btnIncrementar" runat="server" CommandArgument='<%# Eval("Id") %>' Text="+" CssClass="btn btn-outline-secondary" OnClick="btnIncrementar_Click" style="width: 30px;" />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("Id") %>' Text="Eliminar" />
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>
     <div class="mt-3">
        <asp:Button ID="btnFinalizarCompra" runat="server" Text="Continuar con la Compra" CssClass="btn btn-success" OnClick="btnFinalizarCompra_Click" />
    </div>
     <div class="mt-3">
         <asp:Label ID="lblTotal" runat="server" CssClass="h4"></asp:Label>
     </div>
 </div>


    <style>

    .img-small {
        width: 50px; /*ancho de la foto */
        height: auto; 
        object-fit: cover;
    }
</style>

  
</asp:Content>
