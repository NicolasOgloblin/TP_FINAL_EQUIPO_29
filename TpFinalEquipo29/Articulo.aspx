<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="TpFinalEquipo29.Articulo" %>
   

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Agregar Nuevo Artículo</h2>
    <asp:Label ID="lblCodigoArticulo" runat="server" Text="Código del Artículo:"></asp:Label>
    <asp:TextBox ID="txtCodigoArticulo" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCodigoArticulo" runat="server" ControlToValidate="txtCodigoArticulo" ErrorMessage="El código del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
    <br /><br />
    
    <asp:Label ID="lblNombre" runat="server" Text="Nombre del Artículo:"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
    <br /><br />
    
    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción del Artículo:"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
    <br /><br />
    
    <asp:Label ID="lblCategoria" runat="server" Text="Categoría del Artículo:"></asp:Label>
    <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="ddlCategorias" InitialValue="0" ErrorMessage="Selecciona una categoría." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
    <br /><br />
    
    <asp:Label ID="lblMarca" runat="server" Text="Marca del Artículo:"></asp:Label>
    <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-control"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="ddlMarcas" InitialValue="0" ErrorMessage="Selecciona una marca." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
    <br /><br />
    
    <asp:Label ID="lblPrecio" runat="server" Text="Precio del Artículo:"></asp:Label>
    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="El precio del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
    <br /><br />
    
    <asp:Label ID="lblStock" runat="server" Text="Stock del Artículo:"></asp:Label>
    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvStock" runat="server" ControlToValidate="txtStock" ErrorMessage="El stock del artículo es obligatorio." ForeColor="Red" ValidationGroup="AgregarArticulo"></asp:RequiredFieldValidator>
    <br /><br />

    <asp:Label ID="lblUrlImagen" runat="server" Text="URL de la Imagen:"></asp:Label>
    <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Button ID="btnAgregarImagen" runat="server" Text="Agregar Imagen" OnClick="btnAgregarImagen_Click" CssClass="btn btn-secondary" />
    <br /><br />
    
    <!-- Mostrar lista de URLs de imágenes agregadas -->
    <asp:Repeater ID="rptImagenes" runat="server">
        <HeaderTemplate>
            <h3>Imágenes Agregadas</h3>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><%# Container.DataItem %></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <br /><br />
    
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Artículo" OnClick="btnAgregar_Click" CssClass="btn btn-primary" ValidationGroup="AgregarArticulo" />
    <br /><br />
    
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>

    <h2>Lista de Artículos</h2>
    <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        OnRowEditing="gvArticulos_RowEditing" OnRowUpdating="gvArticulos_RowUpdating"
        OnRowCancelingEdit="gvArticulos_RowCancelingEdit" OnRowDeleting="gvArticulos_RowDeleting"
        CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="CodArticulo" HeaderText="Código" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Categoria.Nombre" HeaderText="Categoría" />
            <asp:BoundField DataField="Marca.Nombre" HeaderText="Marca" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:TemplateField HeaderText="Imagen">
                <ItemTemplate>
                    <asp:Literal runat="server" Text='<%# Eval("Imagenes[0].UrlImagen") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-primary btn-sm" CommandName="Edit" Text="Editar" CausesValidation="False"></asp:LinkButton>
                    <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm" CommandName="Delete" Text="Eliminar" CausesValidation="False"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btnActualizar" runat="server" CssClass="btn btn-success btn-sm" CommandName="Update" Text="OK" CausesValidation="False"></asp:LinkButton>
                    <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn btn-secondary btn-sm" CommandName="Cancel" Text="Cancelar" CausesValidation="False"></asp:LinkButton>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
