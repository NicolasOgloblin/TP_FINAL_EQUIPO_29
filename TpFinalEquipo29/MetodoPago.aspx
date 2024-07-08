<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MetodoPago.aspx.cs" Inherits="TpFinalEquipo29.MetodoPago" %>

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
        .forma-pago {
            font-size: 16px;
            margin-bottom: 10px;
        }
        .total-container {
            border: 1px solid #ccc;
            padding: 10px;
            border-radius: 5px;
            display: inline-block;
            margin-top: 20px;
        }
        .total-label, .total-price {
            font-weight: bold;
            font-size: 1.2em;
        }
    </style>

    <div class="custom-container">
        <h2>Elije tu método de pago</h2>
        <div class="radio-list">
            <asp:RadioButtonList ID="rbMetodoPago" runat="server">
                <asp:ListItem Value="efectivo">Pagar en efectivo</asp:ListItem>
                <asp:ListItem Value="debito/transferencia">Pagar con débito</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Button ID="btnConfirmarPago" runat="server" Text="Confirmar" CssClass="btn-confirmar" OnClick="btnConfirmarPago_Click" />
        <p class="note">Selecciona tu método de pago preferido.</p>

        <div class="total-container">
            <span class="total-label">Monto Total:</span>
            <asp:Label ID="lblMontoTotal" runat="server" Text="" CssClass="total-price"></asp:Label>
        </div>
    </div>

</asp:Content>
