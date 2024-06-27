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
  
 
     <div class="d-flex flex-column mb-3" style="width: 1000px;">

 <div class="input-group d-flex mb-3" style="width: 253.18px; height: 40px;"> 
     <asp:TextBox ID="txtBuscar" class="form-control me-2"  style="flex: 1;" runat="server" placeholder="Buscar..."></asp:TextBox><%= GetBuscarValue() %>
     <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-outline-info" OnClick="btnBuscar_Click" Text="Buscar" style="width: auto; height: 100%;"/>
 </div>
    
 <div class="d-flex">
     <asp:DropDownList ID="ddlFiltroPrecio" class="form-control me-2" style="width: 253.18px;" OnSelectedIndexChanged="ddlFiltroPrecio_Click" runat="server" AutoPostBack="true"></asp:DropDownList>
 </div>
 </div>

    <div class="sobre-nosotros">
    <h2>Sobre nosotros:</h2>
    <p>
        En <strong>GreenTech</strong>, nos dedicamos a la revitalización de la tecnología mediante el reciclaje y la reventa de productos tecnológicos. Nuestro compromiso se centra en reducir el impacto ambiental asociado con la electrónica, al mismo tiempo que promovemos prácticas sostenibles y la economía circular. Creemos firmemente en contribuir activamente a los objetivos de desarrollo sostenible establecidos en la Agenda 2030 de las Naciones Unidas.
    </p>
    <p>
        Desde nuestro inicio, hemos trabajado para ofrecer soluciones innovadoras que no solo beneficien a nuestros clientes, sino también al medio ambiente. Cada acción que tomamos está guiada por nuestro compromiso con la excelencia, la integridad y la responsabilidad social corporativa.
    </p>
    <p>
        Únete a nosotros en nuestro viaje hacia un futuro más sostenible y responsable con <strong>GreenTech</strong>.
    </p>
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
