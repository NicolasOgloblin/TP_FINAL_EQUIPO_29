<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProcesandoPedido.aspx.cs" Inherits="TpFinalEquipo29.ProcesandoPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet">
    <style>
        body {
            background-color: #e8f5e9; 
            font-family: 'Roboto', sans-serif; 
            text-align: center;
            color: #2e7d32; 
            margin: 0;
            padding: 0;
        }
        .container {
            margin-top: 100px;
        }
        .message {
            font-size: 24px;
            font-weight: bold;
        }
        .sub-message {
            font-size: 18px;
            margin-top: 20px;
        }
        .impact-message {
            margin-top: 30px;
            font-size: 16px;
            color: #388e3c;
        }
        .img-container {
            margin-top: 40px;
        }
        .img-container img {
            max-width: 25%;
            height: auto;
        }
    </style>

    <div class="container">
        <h1 class="message">Aguarda unos segundos, estamos procesando tu pedido...</h1>
        <p class="sub-message">Con esta compra, estás ayudando a reducir el impacto al medioambiente.</p>
        <div class="impact-message">
            Gracias a tu compra, ayudamos a reducir el impacto ambiental en un 0.4%. ¡Gracias por apoyar la economía circular!
        </div>
       <div class="img-container">
            
            <img src="../Imagenes/CatThanks.jpg" alt="Gracias por tu compra">
        </div>
    </div>

    <script>
        
        setTimeout(function () {
            window.location.href = "FormaEntrega.aspx";
        }, 3000);
    </script>
</asp:Content>

