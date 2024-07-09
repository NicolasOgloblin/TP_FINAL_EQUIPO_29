<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormaEntrega.aspx.cs" Inherits="TpFinalEquipo29.FormaEntrega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .custom-container {
            max-width: 600px;
            margin: 50px auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        .radio-list {
            margin-bottom: 20px;
        }
        .btn-confirmar {
            background-color: #4caf50; 
            color: #ffffff;
            border: none;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            border-radius: 4px;
            cursor: pointer;
        }
        .btn-confirmar:hover {
            background-color: #45a049;
        }
        .note {
            font-size: 14px;
            color: #666;
            margin-top: 10px;
        }
        .gratis {
            color: #4caf50; 
            font-weight: bold;
            font-size: 14px;
            margin-right: 10px;
        }
        .direccion {
            font-size: 14px;
            color: #000000; 
        }
    </style>

   <div class="custom-container">
        <h2>Elije tu forma de entrega</h2>
        <div class="radio-list">
            <asp:RadioButtonList ID="rbFormaEntrega" runat="server" OnSelectedIndexChanged="rbFormaEntrega_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="encuentro">Punto de encuentro - <span class="direccion">Plaza de San Miguel</span> <span class="gratis">Gratis</span></asp:ListItem>
                <asp:ListItem Value="tienda">Retiro en la tienda - <span class="direccion">Tribulato 905, San Miguel</span> <span class="gratis">Gratis</span></asp:ListItem>
                <asp:ListItem Value="domicilio">Envío a domicilio - <span class="direccion"></span> <span class="gratis">Costo adicional ($3,500)</span></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Button ID="btnConfirmarEntrega" runat="server" Text="Confirmar" CssClass="btn-confirmar" OnClick="btnConfirmarEntrega_Click" />
       
    </div>

</asp:Content>



