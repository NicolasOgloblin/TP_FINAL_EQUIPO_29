<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpFinalEquipo29._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
     #pagination a {
         color: black; 
         background-color: white; 
         border: 1px solid grey;
     }
     #pagination a:hover {
         background-color: white; 
     }
     #txtBuscar {
         width: 253.18px;
     }
     #imgArticulos {
    width: 100%;
    height: 250px; /* Ajusta la altura según tus necesidades */
    object-fit: cover; /* Ajusta la imagen para que se recorte en lugar de deformarse */
}
 </style>
  
 <div class="d-flex flex-column mb-3" style="width: 1000px;">

 <div class="input-group d-flex mb-3" style="width: 253.18px; height: 40px;"> 
     <asp:TextBox ID="txtBuscar" class="form-control me-2"  style="flex: 1;" runat="server" placeholder="Buscar..."></asp:TextBox><%= GetBuscarValue() %>
     <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-outline-info" OnClick="btnBuscar_Click" Text="Buscar" style="width: auto; height: 100%;"/>
 </div>

 <div class="d-flex">
     <asp:DropDownList ID="ddlFiltroPrecio" class="form-control me-2" style="width: 253.18px;" OnSelectedIndexChanged="ddlFiltroPrecio_Click" runat="server" AutoPostBack="true"></asp:DropDownList>
 </div>
 </div>

 
 <!-- Estas son las Tarjetas -->
 <div class="row row-cols-3 row-cols-md-4 g-4">
     <asp:ListView ID="dgvArticulos" runat="server" ItemPlaceholderID="itemPlaceholder">
         <LayoutTemplate>
             <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
         </LayoutTemplate>
         <ItemTemplate>
             <div class="col">
                 <div class="card">
                     <asp:Image runat="server" ID="imgArticulo" CssClass="card-img-top" />
                     <img ID="imgArticulos" src='<%# Eval("Imagenes[0].UrlImagen") %>' alt="Imagen del artículo">
                     <div class="card-body">
                         <h5 class="card-title"><%# Eval("Nombre") %></h5>
                         <p class="card-text">Precio: <b>$<%# Eval("Precio") %></b></p> 
                     <asp:LinkButton ID="btnAgregar" runat="server" CssClass="btn btn-success" OnClick="btnAgregar_Click" CommandArgument='<%# Eval("Id") %>' Text="Agregar" />   
                     <asp:LinkButton ID="btnDetalles" runat="server" CssClass="btn btn-outline-success" Onclick="btnDetalles_Click" CommandArgument='<%# Eval("Id") %>'  Text="Ver detalles" />   
                     </div>
                 </div>
             </div>
         </ItemTemplate>
     </asp:ListView>
 </div>

 <div class="d-flex justify-content-center mt-3">
     <ul class="pagination pagination-md" id="pagination" >  
         <asp:Literal ID="litPagination" runat="server"></asp:Literal>
     </ul>
 </div>


</asp:Content>
