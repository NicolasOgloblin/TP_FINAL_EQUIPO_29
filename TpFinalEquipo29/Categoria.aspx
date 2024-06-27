<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="TpFinalEquipo29.Categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Agregar Nueva Categoría</h2>
    <asp:Label ID="lblNombre" runat="server" Text="Nombre de la Categoría:"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio." ForeColor="Red" ValidationGroup="AgregarCategoria"></asp:RequiredFieldValidator>
    <br /><br />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Categoría" OnClick="btnAgregar_Click" CssClass="btn btn-outline-primary" ValidationGroup="AgregarCategoria" />
    <br /><br />
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>

    <h2>Lista de Categorías</h2>
    <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowEditing="gvCategorias_RowEditing" OnRowUpdating="gvCategorias_RowUpdating" OnRowCancelingEdit="gvCategorias_RowCancelingEdit" OnRowDeleting="gvCategorias_RowDeleting" CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:TemplateField HeaderText="Nombre">
                <ItemTemplate>
                    <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNombreEdit" runat="server" Text='<%# Eval("Nombre") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-outline-success btn-sm" CommandName="Edit" Text="Editar" CausesValidation="False"></asp:LinkButton>
                    <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-outline-danger btn-sm" CommandName="Delete" Text="Eliminar" CausesValidation="False"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btnActualizar" runat="server" CssClass="btn btn-success btn-sm" CommandName="Update" Text="OK" CausesValidation="False"></asp:LinkButton>
                    <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn btn-secondary btn-sm" CommandName="Cancel" Text="Cancelar" CausesValidation="False"></asp:LinkButton>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn btn-info" />

</asp:Content>