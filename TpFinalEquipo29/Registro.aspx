<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TpFinalEquipo29.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-6">
        <h2>Registro de Usuario</h2>
        <div class="row"> 
            <div class="col-md-6">
                <div class="form-group">
                <label for="txtNombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El campo Nombre es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre debe tener un minimo de 3 y maximo 70 caracteres" ValidationExpression="^.{3,70}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">
            <label for="txtApellido">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese su apellido"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="El campo Apellido es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido debe tener un minimo de 3 y maximo 70 caracteres" ValidationExpression="^.{3,70}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            </div>
        </div>
        
            <div class="row">
            <div class="col-md-6">
            <div class="form-group">
                <label for="txtDNI">DNI</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese su DNI"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="El campo DNI es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="Solo numeros Maximo:9" ValidationExpression="^\d{7,9}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
                </div>
            <div class="col-md-6">
            <div class="form-group">
            <label for="txtContrasenia">Contraseña</label>
            <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese su contraseña"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="El campo Contraseña es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revContrasenia" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="La contraseña debe tener al menos 8 caracteres" ValidationExpression="^.{8,30}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
            </div>
                </div>


        <div class="row">
            <div class="col-md-6">
            <div class="form-group">
                <label for="txtUsuario">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su nombre de usuario"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="El campo Usuario es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="El usuario debe tener un minimo de 5 y maximo 30 caracteres" ValidationExpression="^.{5,30}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">
                <label for="txtConfirmarContrasenia">Confirmar Contraseña</label>
                <asp:TextBox ID="txtConfirmarContrasenia" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirme su contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfirmarContrasenia" runat="server" ControlToValidate="txtConfirmarContrasenia" ErrorMessage="El campo Confirmar Contraseña es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvContrasenia" runat="server" ControlToValidate="txtConfirmarContrasenia" ControlToCompare="txtContrasenia" ErrorMessage="Las contraseñas no coinciden" CssClass="text-danger" Display="Dynamic"></asp:CompareValidator>
            </div>
            </div>
            </div>

            <div class="row">
            <div class="col-md-6">
            <div class="form-group">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingrese su email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="El campo Email es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Formato de Email no válido" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
                </div>
            <div class="col-md-6">
            <div class="form-group">
                <label for="txtProvincia">Provincia</label>
                <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" placeholder="Ingrese Provincia"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="txtProvincia" ErrorMessage="El campo Provincia es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revProvincia" runat="server" ControlToValidate="txtProvincia" ErrorMessage="La provincia debe tener un minimo de 5 y maximo 80 caracteres" ValidationExpression="^.{5,80}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            </div>
            </div>

            <div class="row">
            <div class="col-md-6">
            <div class="form-group">
                <label for="txtLocalidad">Localidad</label>
                <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" placeholder="Ingrese su Localidad"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="txtLocalidad" ErrorMessage="El campo Localidad es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revLocalidad" runat="server" ControlToValidate="txtLocalidad" ErrorMessage="La localidad debe tener un minimo de 5 y maximo 80 caracteres" ValidationExpression="^.{5,80}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">
                <label for="txtCalle">Calle</label>
                <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="Ingrese su calle"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCalle" runat="server" ControlToValidate="txtCalle" ErrorMessage="El campo Calle es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCalle" runat="server" ControlToValidate="txtCalle" ErrorMessage="La calle debe tener un minimo de 3 y maximo 80 caracteres" ValidationExpression="^.{3,80}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            </div>
            </div>

            <div class="row">
            <div class="col-md-6">
            <div class="form-group">
                <label for="txtAltura">Altura</label>
                <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control" placeholder="Ingrese la altura"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAltura" runat="server" ControlToValidate="txtAltura" ErrorMessage="El campo Altura es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revAltura" runat="server" ControlToValidate="txtAltura" ErrorMessage="Solo numeros Maximo:20" ValidationExpression="^\d{1,9}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">
                <label for="txtCodPostal">Codigo Postal</label>
                <asp:TextBox ID="txtCodPostal" runat="server" CssClass="form-control" placeholder="Ingrese Codigo Postal"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCodPostal" runat="server" ControlToValidate="txtCodPostal" ErrorMessage="El campo Codigo Postal es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCodPostal" runat="server" ControlToValidate="txtCodPostal" ErrorMessage="Solo numeros" ValidationExpression="^\d{4,5}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            </div>
            </div>

            <div class="form-group">
                <label for="txtTelefono">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese su teléfono"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El campo Teléfono es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Solo se permiten números en el teléfono" ValidationExpression="^\d{8,10}$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group mt-3">
                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnRegistrar_Click" />
            </div>
    </div>

</asp:Content>


