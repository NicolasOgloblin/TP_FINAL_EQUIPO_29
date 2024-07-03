<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticuloAgregar.aspx.cs" Inherits="TpFinalEquipo29.ArticuloAgregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <h2>Agregar Nuevo Artículo</h2>
   <div class="row">
       <div class="col-md-6">
           <asp:Label ID="lblCodigoArticulo" runat="server" Text="Código del Artículo:"></asp:Label>
           <asp:TextBox ID="txtCodigoArticulo" runat="server" CssClass="form-control"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvCodigoArticulo" runat="server" ControlToValidate="txtCodigoArticulo"
               ErrorMessage="El código del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />

           <asp:Label ID="lblCategoria" runat="server" Text="Categoría del Artículo:"></asp:Label>
           <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control">
               <asp:ListItem Text="--Seleccione--" Value="0"></asp:ListItem>
             
           </asp:DropDownList>
           <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="ddlCategorias" InitialValue="0"
               ErrorMessage="Selecciona una categoría." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />

           <asp:Label ID="lblMarca" runat="server" Text="Marca del Artículo:"></asp:Label>
           <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-control">
               <asp:ListItem Text="--Seleccione--" Value="0"></asp:ListItem>
              
           </asp:DropDownList>
           <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="ddlMarcas"
               InitialValue="0" ErrorMessage="Selecciona una marca." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />

           <asp:Label ID="lblNombre" runat="server" Text="Nombre del Artículo:"></asp:Label>
           <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
               ErrorMessage="El nombre del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />

           <asp:Label ID="lblDescripcion" runat="server" Text="Descripción del Artículo:"></asp:Label>
           <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
           <br />

           <asp:Label ID="lblPrecio" runat="server" Text="Precio del Artículo:"></asp:Label>
           <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio" 
               ErrorMessage="El precio del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />
            <asp:Label ID="lblOrigen" runat="server" Text="Origen:"></asp:Label>
            <asp:TextBox ID="txtOrigen" runat="server" CssClass="form-control"></asp:TextBox>
           <br />
       </div>

       <div class="col-md-6">
           <asp:Label ID="lblStock" runat="server" Text="Stock del Artículo:"></asp:Label>
           <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvStock" runat="server" ControlToValidate="txtStock" 
               ErrorMessage="El stock del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />

           <asp:Label ID="lblPeso" runat="server" Text="Peso (kg):"></asp:Label>
           <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvPeso" runat="server" ControlToValidate="txtPeso" 
               ErrorMessage="El peso del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />

           <asp:Label ID="lblAncho" runat="server" Text="Ancho (cm):"></asp:Label>
           <asp:TextBox ID="txtAncho" runat="server" CssClass="form-control"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvAncho" runat="server" ControlToValidate="txtAncho" 
               ErrorMessage="El ancho del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />

           <asp:Label ID="lblAlto" runat="server" Text="Alto (cm):"></asp:Label>
           <asp:TextBox ID="txtAlto" runat="server" CssClass="form-control"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvAlto" runat="server" ControlToValidate="txtAlto" 
               ErrorMessage="El alto del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />

           <asp:Label ID="lblColor" runat="server" Text="Color:"></asp:Label>
           <asp:TextBox ID="txtColor" runat="server" CssClass="form-control"></asp:TextBox>
           <br />

           <asp:Label ID="lblModelo" runat="server" Text="Modelo:"></asp:Label>
           <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control"></asp:TextBox>
           <br />

           <asp:Label ID="lblUrlImagen" runat="server" Text="Imagenes:"></asp:Label>
           <asp:FileUpload ID="fuImagenes" runat="server" AllowMultiple="true" CssClass="form-control" />
           <br />
           
      </div>

           
           <div class="col-md-6">

           <asp:Label ID="lblGarantia" runat="server" Text="Garantía:"></asp:Label>
           <div class="input-group">
               <asp:TextBox ID="txtGarantiaAnios" runat="server" placeholder="Años" CssClass="form-control" Width="100"></asp:TextBox>
               
           </div>
           <asp:RequiredFieldValidator ID="rfvGarantiaAnios" runat="server" ControlToValidate="txtGarantiaAnios" 
               ErrorMessage="Los años de garantía son obligatorios." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>

           <div class="input-group mt-6">
               <asp:TextBox ID="txtGarantiaMeses" runat="server" placeholder="Meses" CssClass="form-control" Width="100"></asp:TextBox>
               
           </div>
           <asp:RequiredFieldValidator ID="rfvGarantiaMeses" runat="server" ControlToValidate="txtGarantiaMeses" 
               ErrorMessage="Los meses de garantía son obligatorios." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
           <br />
         </div>
        </div>

           <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>


   <asp:Button ID="btnAgregar" runat="server" Text="Agregar Artículo" OnClick="btnAgregar_Click" CssClass="btn btn-outline-success" ValidationGroup="AgregarArticulo" />
   
    <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn btn-info" />
   
    
</asp:Content>
