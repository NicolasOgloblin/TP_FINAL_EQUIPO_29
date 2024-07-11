using Business.Pedido;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class DatosTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (!UsuarioEstaConectado())
                {
                    
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    
                    long usuarioId = ObtenerUsuarioPorId();
                    List<PedidoEntity> historialCompras = ObtenerHistorialCompras(usuarioId);
                    gvHistorialCompras.DataSource = historialCompras;
                    gvHistorialCompras.DataBind();
                }
            }
        }

        private bool UsuarioEstaConectado()
        {
            
            return Session["Login"] != null && Session["Login"] is UsuarioEntity;
        }

        private List<PedidoEntity> ObtenerHistorialCompras(long usuarioId)
        {
            try
            {
                PedidoBusiness pedidoBusiness = new PedidoBusiness();


                PedidoBusiness pedidoBusiness1 = pedidoBusiness;
                return pedidoBusiness1.ObtenerHistorialCompras(usuarioId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el historial de compras desde PedidoBusiness", ex);
            }

        }


        private long ObtenerUsuarioPorId()
        {
            var usuarioLogueado = (UsuarioEntity)Session["Login"];
            if (usuarioLogueado == null)
            {
                throw new Exception("Usuario no logueado.");
            }
            return usuarioLogueado.Id;
        }
    }

}