using Domain.Entities;
using System;
using System.Web.UI;

namespace TpFinalEquipo29
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["Login"] != null)
                {
                    
                    var username = (UsuarioEntity)Session["Login"];

                    
                    if (!string.IsNullOrEmpty(username.Usuario))
                    {
                        lblUsername.Text = username.Usuario;
                        lblUsername.Visible = true;
                        btnLogout.Visible = true;
                        liLogin.Visible = false;
                    }
                    else
                    {
                        lblUsername.Text = "";
                        lblUsername.Visible = false;
                        btnLogout.Visible = false;
                        liLogin.Visible = true;
                    }
                }
                else
                {
                    
                    lblUsername.Text = "";
                    lblUsername.Visible = false;
                    btnLogout.Visible = false;
                    liLogin.Visible = true;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            Session.Remove("Login");

            
            Response.Redirect("~/Login.aspx");
        }
    }
}
