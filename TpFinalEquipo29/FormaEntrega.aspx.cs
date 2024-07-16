using Business.Pedido;
using Domain.Entities;
using System;
using System.Web.UI.WebControls;

namespace TpFinalEquipo29
{
    public partial class FormaEntrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Login"] != null)
                {
                    

                    var usuario = (UsuarioEntity)Session["Login"];

                    

                    if (rbFormaEntrega.SelectedValue.Equals("domicilio"))
                    {
                        

                        Session["DireccionDomicilio"] = $"{usuario.Calle} {usuario.Altura}, {usuario.Localidad}";

                        foreach (ListItem item in rbFormaEntrega.Items)
                        {
                            if (item.Value == "domicilio")
                            {
                                item.Text = $"Envío a domicilio - <span class='direccion'>{usuario.Calle} {usuario.Altura}, {usuario.Localidad}</span> <span class='gratis'>Costo adicional ($3,500)</span>";
                                break;
                            }
                        }
                    }
                }
                else
                {
                    
                    Response.Redirect("Login.aspx");
                }

            }
        }

        protected void rbFormaEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pedidoBusiness = new PedidoBusiness();
            var pedido = new PedidoEntity();
            pedido.Id = (long)Session["PedidoEnCurso"];

            if (rbFormaEntrega.SelectedValue == "domicilio")
            {
                if (Session["Login"] != null)
                {
                    var usuario = (UsuarioEntity)Session["Login"];
                    
                    pedido.Envio = true;
                    try
                    {
                        pedidoBusiness.ModificarPedido(pedido);
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Algo salio mal: " + ex.Message);
                    }

                    Session["DireccionDomicilio"] = $"{usuario.Calle} {usuario.Altura}, {usuario.Localidad}";

                    Session["CostoEnvio"] = 3500m;

                    foreach (ListItem item in rbFormaEntrega.Items)
                    {
                        if (item.Value == "domicilio")
                        {
                            item.Text = $"Envío a domicilio - <span class='direccion'>{usuario.Calle} {usuario.Altura}, {usuario.Localidad}</span> <span class='gratis'>Costo adicional ($3,500)</span>";
                            break;
                        }
                    }
                }
                
            }
            else
            {
                pedido.Envio = false;
                try
                {
                    pedidoBusiness.ModificarPedido(pedido);
                }
                catch (Exception ex)
                {
                    throw new Exception("Algo salio mal: " + ex.Message);
                }

                Session.Remove("DireccionDomicilio");
                Session.Remove("CostoEnvio");

                foreach (ListItem item in rbFormaEntrega.Items)
                {
                    if (item.Value == "domicilio")
                    {
                        item.Text = "Envío a domicilio - <span class='direccion'></span> <span class='gratis'>Costo adicional ($3,500)</span>";
                        break;
                    }
                }
            }
            btnConfirmarEntrega.Enabled = rbFormaEntrega.SelectedValue != "";
        }

        protected void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            
                string formaEntrega = rbFormaEntrega.SelectedValue;

                Session["FormaEntrega"] = formaEntrega;

                Response.Redirect("MetodoPago.aspx");
            
                   
        }
    }
}