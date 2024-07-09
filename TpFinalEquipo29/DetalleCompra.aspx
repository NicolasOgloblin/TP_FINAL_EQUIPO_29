<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCompra.aspx.cs" Inherits="TpFinalEquipo29.DetalleCompra" %>

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
        .detalle {
            margin-bottom: 20px;
            border-bottom: 1px solid #ddd;
            padding-bottom: 10px;
        }
        .detalle label {
            font-weight: bold;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .btn-modificar {
            background-color: #007bff;
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
        .btn-modificar:hover {
            background-color: #0056b3;
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
        .total-label, .total-price {
            font-weight: bold;
            font-size: 1.2em;
        }
    </style>

    <div class="custom-container">
        <h2>Detalle de la Compra</h2>

        

        <div class="detalle">
            <label>Forma de Entrega:</label>
            <asp:Label ID="lblFormaEntrega" runat="server" Text="Punto de Encuentro"></asp:Label>
            
        </div>

        <div class="detalle">
            <label>Método de Pago:</label>
            <asp:Label ID="lblMetodoPago" runat="server" Text="Tarjeta de Crédito"></asp:Label>
            
        </div>

         <div id="divDireccionDomicilio" runat="server" visible="false" class="detalle">
            <label>Dirección de Envío:</label>
            <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label>
        </div>

        <div class="mt-4">
            <h3>Su compra:</h3>
            <asp:GridView ID="gvArticulosSeleccionados" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Stock" HeaderText="Cantidad" />
                </Columns>
            </asp:GridView>
        </div>


        <div class="total-container">
        <span class="total-label">Monto Total:</span>
        <asp:Label ID="lblMontoTotal" runat="server" Text="" CssClass="total-price"></asp:Label>
    </div>
        <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar Compra" CssClass="btn-confirmar" OnClick="btnConfirmarCompra_Click" />
    </div>

    


</asp:Content>

