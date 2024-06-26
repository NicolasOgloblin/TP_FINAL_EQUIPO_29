<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="TpFinalEquipo29.Articulo" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
   <h2>Lista de Artículos</h2>
     <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
    <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
    OnRowEditing="gvArticulos_RowEditing" OnRowUpdating="gvArticulos_RowUpdating"
    OnRowCancelingEdit="gvArticulos_RowCancelingEdit" OnRowDeleting="gvArticulos_RowDeleting"
    OnRowDataBound="gvArticulos_RowDataBound" CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
        <asp:TemplateField HeaderText="Código">
            <ItemTemplate>
                <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("CodArticulo") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCodigo" runat="server" Text='<%# Eval("CodArticulo") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtNombre" runat="server" Text='<%# Eval("Nombre") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descripción">
            <ItemTemplate>
                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Eval("Descripcion") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Categoría">
            <ItemTemplate>
                <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("Categoria.Nombre") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Marca">
            <ItemTemplate>
                <asp:Label ID="lblMarca" runat="server" Text='<%# Eval("Marca.Nombre") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-control"></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Precio">
            <ItemTemplate>
                <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("Precio") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Eval("Precio") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stock">
            <ItemTemplate>
                <asp:Label ID="lblStock" runat="server" Text='<%# Eval("Stock") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtStock" runat="server" Text='<%# Eval("Stock") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Peso (kg)">
            <ItemTemplate>
                <asp:Label ID="lblPeso" runat="server" Text='<%# Eval("Peso") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtPeso" runat="server" Text='<%# Eval("Peso") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Color">
            <ItemTemplate>
                <asp:Label ID="lblColor" runat="server" Text='<%# Eval("Color") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtColor" runat="server" Text='<%# Eval("Color") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Garantía (Años)">
            <ItemTemplate>
                <asp:Label ID="lblGarantiaAnios" runat="server" Text='<%# Eval("Garantia_Anios") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtGarantiaAnios" runat="server" Text='<%# Eval("Garantia_Anios") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Garantía (Meses)">
            <ItemTemplate>
                <asp:Label ID="lblGarantiaMeses" runat="server" Text='<%# Eval("Garantia_Meses") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtGarantiaMeses" runat="server" Text='<%# Eval("Garantia_Meses") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Ancho (cm)">
            <ItemTemplate>
                <asp:Label ID="lblAncho" runat="server" Text='<%# Eval("Ancho") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtAncho" runat="server" Text='<%# Eval("Ancho") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Alto (cm)">
            <ItemTemplate>
                <asp:Label ID="lblAlto" runat="server" Text='<%# Eval("Alto") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtAlto" runat="server" Text='<%# Eval("Alto") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Modelo">
            <ItemTemplate>
                <asp:Label ID="lblModelo" runat="server" Text='<%# Eval("Modelo") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtModelo" runat="server" Text='<%# Eval("Modelo") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Origen">
            <ItemTemplate>
                <asp:Label ID="lblOrigen" runat="server" Text='<%# Eval("Origen") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtOrigen" runat="server" Text='<%# Eval("Origen") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        
         <%--   <asp:TemplateField HeaderText="Imagen">
                <ItemTemplate>
                    <asp:Literal runat="server" Text='<%# Eval("Imagenes[0].UrlImagen") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>--%>

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-primary btn-sm"
                    CommandName="Edit" Text="Editar" CausesValidation="False"></asp:LinkButton>
                <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm"
                    CommandName="Delete" Text="Eliminar" CausesValidation="False"></asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="btnActualizar" runat="server" CssClass="btn btn-success btn-sm"
                    CommandName="Update" Text="Actualizar" CausesValidation="False"></asp:LinkButton>
                <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn btn-secondary btn-sm"
                    CommandName="Cancel" Text="Cancelar" CausesValidation="False"></asp:LinkButton>
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
