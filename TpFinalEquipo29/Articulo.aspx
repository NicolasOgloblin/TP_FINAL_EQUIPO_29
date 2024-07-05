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

        
        <asp:TemplateField HeaderText="Stock">
            <ItemTemplate>
                <asp:Label ID="lblStock" runat="server" Text='<%# Eval("Stock") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtStock" runat="server" Text='<%# Eval("Stock") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
        <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-outline-info btn-sm"
            CommandName="Edit" Text="Editar" CausesValidation="False"
            PostBackUrl='<%# Eval("Id", "~/EditarCompleto.aspx?id={0}") %>'></asp:LinkButton>
        <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-outline-danger btn-sm"
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

    <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn btn-info" />

</asp:Content>
