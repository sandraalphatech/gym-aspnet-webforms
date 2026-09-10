using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Gym
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceder_Click(object sender, EventArgs e)
        {
            string email = bd_email.Text.Trim();
            string senha = bd_senha.Text;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(senha))
            {
                lbl_msgm.Text = "Preencha o email e a palavra-passe.";
                lbl_msgm.Visible = true;
                return;
            }

            string senhaEncriptada = EncryptString(senha);
            string connectionString = ConfigurationManager.ConnectionStrings["GymConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_LoginFuncionario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Email",SqlDbType.NVarChar,150).Value = email;
                        cmd.Parameters.Add("@Senha",SqlDbType.NVarChar,255).Value = senhaEncriptada;

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Session["ID"] = reader["ID"];
                                Session["Nome"] = reader["Nome"].ToString();
                                Session["Email"] = reader["Email"].ToString();
                                Session["Funcao"] = reader["Funcao"].ToString();
                                
                                Response.Redirect("Registo_form.aspx");
                            }
                            else
                            {
                                lbl_msgm.Text =
                                    "Email ou palavra-passe incorretos.";
                                lbl_msgm.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_msgm.Text =
                    "Ocorreu um erro ao efetuar o login: "
                    + ex.Message;
                lbl_msgm.Visible = true;
            }
        }

        public static string EncryptString(string Message)
        {
            string Passphrase = "Gym";
            byte[] Results;

            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DatatoEncrypt = UTF8.GetBytes(Message);

            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();

                Results = Encryptor.TransformFinalBlock( DatatoEncrypt, 0, DatatoEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            string enc = Convert.ToBase64String(Results);

            enc = enc.Replace("+", "KKK");
            enc = enc.Replace("/", "JJJ");
            enc = enc.Replace("=", "III");

            return enc;
        }
    }
}