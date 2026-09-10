using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gym
{
    public partial class Registo_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_list_Click(object sender, EventArgs e) {
            lista_clientes.Visible = true;
            GridView1.DataBind();
            lbl_msgm.Visible = false;
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["GymConnectionString"].ConnectionString);
            SqlCommand mycommand = new SqlCommand();

            mycommand.Parameters.AddWithValue("@Nome", tb_nome.Text);
            mycommand.Parameters.AddWithValue("@DataNascimento", tb_nascimento.Text);
            mycommand.Parameters.AddWithValue("@Email", tb_email.Text);
            mycommand.Parameters.AddWithValue("@Contacto", tb_contacto.Text);
            mycommand.Parameters.AddWithValue("@Peso", Convert.ToDecimal (tb_peso.Text));
            mycommand.Parameters.AddWithValue("@Altura", Convert.ToInt32 (tb_altura.Text));
            mycommand.Parameters.AddWithValue("@Objetivo", ddl_objetivo.SelectedItem.Text);

            mycommand.CommandText = @"INSERT INTO dbo.Clientes (Nome, DataNascimento, Email, Contacto, Peso, Altura, Objetivo)
            VALUES (@Nome, @DataNascimento, @Email, @Contacto, @Peso, @Altura, @Objetivo)";

            mycommand.Connection = myconn;

            myconn.Open();
            mycommand.ExecuteNonQuery();
            myconn.Close();

            lbl_msgm.Visible = true;
            tb_nome.Text = "";
            tb_nascimento.Text = "";
            tb_email.Text = "";
            tb_contacto.Text = "";
            tb_peso.Text = "";
            tb_altura.Text = "";

            ddl_objetivo.SelectedIndex = 0;

            ClientScript.RegisterStartupScript(
                this.GetType(),
                "esconderMensagem",
                "setTimeout(function() { document.getElementById('" + lbl_msgm.ClientID + "').style.display = 'none'; }, 5000);",
                true
            );

        }

        protected void btn_insertSP_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["GymConnectionString"].ConnectionString
            );

            SqlCommand mycommand = new SqlCommand();

            mycommand.Parameters.AddWithValue("@Nome", tb_nome.Text);
            mycommand.Parameters.AddWithValue("@DataNascimento", tb_nascimento.Text);
            mycommand.Parameters.AddWithValue("@Email", tb_email.Text);
            mycommand.Parameters.AddWithValue("@Contacto", tb_contacto.Text);
            mycommand.Parameters.AddWithValue("@Peso", Convert.ToDecimal(tb_peso.Text));
            mycommand.Parameters.AddWithValue("@Altura", Convert.ToInt32(tb_altura.Text));
            mycommand.Parameters.AddWithValue("@Objetivo", ddl_objetivo.SelectedItem.Text);

            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            mycommand.Parameters.Add(retorno);

            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.CommandText = "registar_cliente_semDuplicacao";

            mycommand.Connection = myconn;

            try
            {
                myconn.Open();
                mycommand.ExecuteNonQuery();
                int resultado = Convert.ToInt32(retorno.Value);

                if (resultado == 1)
                {

                    lbl_msgm.Text = "Cliente registado com sucesso.";
                    lbl_msgm.Visible = true;
                    lbl_msgm.ForeColor = System.Drawing.Color.Green;

                    tb_nome.Text = "";
                    tb_nascimento.Text = "";
                    tb_email.Text = "";
                    tb_contacto.Text = "";
                    tb_peso.Text = "";
                    tb_altura.Text = "";

                    ddl_objetivo.SelectedIndex = 0;

                    ClientScript.RegisterStartupScript(
                        this.GetType(),
                        "esconderMensagem",
                        "setTimeout(function() { " +
                        "document.getElementById('" + lbl_msgm.ClientID + "').style.display = 'none';" +
                        "}, 5000);",
                        true
                    );
                }
                else
                {
                    lbl_msgm.Text =
                        "Já existe um cliente com este email e data de nascimento.";

                    lbl_msgm.Visible = true;
                    lbl_msgm.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {

                lbl_msgm.Text =
                    "Ocorreu um erro: " + ex.Message;

                lbl_msgm.Visible = true;
                lbl_msgm.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                myconn.Close();
            }
        }

    }
}