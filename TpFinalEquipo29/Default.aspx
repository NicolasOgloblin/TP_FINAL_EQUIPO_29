<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpFinalEquipo29._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
     body {
        background-color: #a5d6a7;
        padding: 20px; 
     }
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
        height: 250px; 
        object-fit: cover; 
     }
     .sobre-nosotros {
        border: 1px solid #ccc; 
        padding: 20px;
        margin-bottom: 20px; 
        background-color: #5c9b5e;
        border-radius: 5px;
     }
 </style>
  
<div class="container">
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="input-group">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control me-2" placeholder="Buscar..."></asp:TextBox>
                <%= GetBuscarValue() %>
                <div class="input-group-append">
                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-info" OnClick="btnBuscar_Click" Text="Buscar" />
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <asp:DropDownList ID="ddlFiltroPrecio" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlFiltroPrecio_Click"
                AutoPostBack="true">
            </asp:DropDownList>
        </div>
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
                     <asp:Image runat="server" ID="Image1" CssClass="card-img-top" ImageUrl='<%# ResolveUrl("~/Imagenes/" + Eval("Imagenes[0].UrlImagen")) %>' />
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
