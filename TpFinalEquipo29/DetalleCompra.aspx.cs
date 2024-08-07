﻿using Business.Articulo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TpFinalEquipo29
{
    public partial class DetalleCompra : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                decimal montoTotal = ObtenerMontoTotal();

                lblMontoTotal.Text = $"${montoTotal.ToString("#,##0.00")}";
                MostrarDetallesCompra();
                MostrarArticulosSeleccionados();
            }
        }

        private void MostrarArticulosSeleccionados()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                gvArticulosSeleccionados.DataSource = carrito;
                gvArticulosSeleccionados.DataBind();
            }
        }


        private void MostrarDetallesCompra()
        {
            if (Session["FormaEntrega"] != null)
            {
                string formaEntrega = Session["FormaEntrega"].ToString();
                lblFormaEntrega.Text = ObtenerTextoFormaEntrega(formaEntrega);

                if (formaEntrega == "domicilio" && Session["Direccion"] != null)
                {
                    string direccion = Session["Direccion"].ToString();
                    lblDireccion.Text = direccion;
                    divDireccionDomicilio.Visible = true;
                }
                else
                {
                    divDireccionDomicilio.Visible = false;
                }
            }
            if (Session["MetodoPago"] != null)
            {
                string metodoPago = Session["MetodoPago"].ToString();
                lblMetodoPago.Text = metodoPago; 

            }
        }

        private string ObtenerTextoFormaEntrega(string formaEntrega)
        {
            switch (formaEntrega)
            {
                case "encuentro":
                    return "Punto de encuentro - Plaza de San Miguel (Gratis)";
                case "tienda":
                    return "Retiro en la tienda - Tribulato 905, San Miguel (Gratis)";
                case "domicilio":
                    if (Session["DireccionDomicilio"] != null)
                    {
                        string direccion = Session["DireccionDomicilio"].ToString(); 
                        return $"Envío a domicilio - {direccion} (Costo adicional $3,500)";
                    }
                    else
                    {
                        return "Envío a domicilio - Dirección no especificada (Costo adicional $3,500)";
                    }
                default:
                    return "";
            }
        }

        private decimal ObtenerMontoTotal()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                decimal montoTotal = carrito.Sum(a => a.Precio * a.Stock);
                

                if (Session["FormaEntrega"] != null && Session["FormaEntrega"].ToString() == "domicilio")
                {
                    montoTotal += 3500m;
                }

                return montoTotal;

            }
            return 0;
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("articulosSeleccionados");

                Response.Redirect("FinalizarCompra.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch(Exception ex)
            {
                throw new Exception("Algo salio mal: " + ex.Message);
            }
        }
    }
}
