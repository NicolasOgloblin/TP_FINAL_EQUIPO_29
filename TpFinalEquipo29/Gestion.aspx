<%@ Page Title="Gestión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gestion.aspx.cs" Inherits="TpFinalEquipo29.Gestión" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        
        <!-- Agregar botones o enlaces para acceder a las páginas de administración -->
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Gestión de Artículos</h5>
                        <p class="card-text">Administrar los artículos disponibles.</p>
                        <a href="Articulo.aspx" class="btn btn-success">Listar Articulos</a>
                        <a href="ArticuloAgregar.aspx" class="btn btn-success">Agregar Artículos</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Gestión de Categorías</h5>
                        <p class="card-text">Administrar las categorías de los artículos.</p>
                        <a href="Categoria.aspx" class="btn btn-success">Ir a Categorías</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Gestión de Marcas</h5>
                        <p class="card-text">Administrar las marcas de los artículos.</p>
                        <a href="Marca.aspx" class="btn btn-success">Ir a Marcas</a>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
