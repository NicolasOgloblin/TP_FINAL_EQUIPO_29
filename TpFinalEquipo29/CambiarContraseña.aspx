<%@ Page Title="CambiarContraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="TpFinalEquipo29.CambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
     <div class="container">
        <h2 class="text-center">CAMBIAR CONTRASEÑA</h2>
                
             <div class="form-group">
        <p class="text-center">Correo Electrónico: <asp:Label ID="lblEmail" runat="server" CssClass="font-weight-bold"></asp:Label></p>
                 </div>
            </div>
        
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card mb-3">
                    <div class="card-body">
                        <div class="form-group">
                            <label for="txtContraseniaActual">Contraseña actual:</label>
                            <input type="password" class="form-control" id="txtContraseniaActual" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvContraseniaActual" runat="server" ControlToValidate="txtContraseniaActual"
                                ErrorMessage="Contraseña actual requerida" ForeColor="Red" ValidationGroup="CambiarContraseña">*</asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label for="txtNuevaContrasenia">Nueva contraseña:</label>
                            <input type="password" class="form-control" id="txtNuevaContrasenia" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvNuevaContrasenia" runat="server" ControlToValidate="txtNuevaContrasenia"
                                ErrorMessage="Nueva contraseña requerida" ForeColor="Red" ValidationGroup="CambiarContraseña">*</asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label for="txtConfirmarContrasenia">Confirmar nueva contraseña:</label>
                            <input type="password" class="form-control" id="txtConfirmarContrasenia" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvConfirmarContrasenia" runat="server" ControlToValidate="txtConfirmarContrasenia"
                                ErrorMessage="Confirmar contraseña requerida" ForeColor="Red" ValidationGroup="CambiarContraseña">*</asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="btnCambiarContraseña" runat="server" Text="CAMBIAR CONTRASEÑA" CssClass="btn btn-primary" ValidationGroup="CambiarContraseña" OnClick="btnCambiarContraseña_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
                        </div>

                        <div>
                            <asp:Label ID="lblMensaje" runat="server" CssClass="alert" EnableViewState="false"></asp:Label>
                        </div>

                        <!-- Mostrar correo electrónico -->
                       
                </div>
            </div>
        </div>
    </div>

</asp:Content>
