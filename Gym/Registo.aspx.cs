using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Gym
{
    public partial class Registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistar_Click(object sender, EventArgs e)
        {
            string nome = bd_nome.Text.Trim();
            string email = bd_email.Text.Trim();
            string funcao = bd_funcao.Text.Trim();
            string senha = bd_senha.Text;
            string confirmarSenha = bd_repetirsenha.Text;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MostrarMensagem("Introduza o nome do colaborador.", false);
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MostrarMensagem("Introduza o e-mail do colaborador.", false);
                return;
            }

            if (string.IsNullOrWhiteSpace(funcao))
            {
                MostrarMensagem("Introduza o cargo do colaborador.", false);
                return;
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                MostrarMensagem("Introduza uma palavra-passe.", false);
                return;
            }

            if (senha != confirmarSenha)
            {
                MostrarMensagem("Atenção: As palavras-passe não coincidem.", false);
                return;
            }

            string senhaEncriptada = EncryptString(senha);

            string connectionString = ConfigurationManager.ConnectionStrings["GymConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistarFuncionario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 150).Value = nome;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;
                        cmd.Parameters.Add("@Funcao", SqlDbType.NVarChar, 150).Value = funcao;
                        cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 255).Value = senhaEncriptada;

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int resultado = Convert.ToInt32(reader["Resultado"]);
                                string mensagem = reader["Mensagem"].ToString();

                                if (resultado == 1)
                                {
                                    MostrarMensagem(mensagem, true);
                                    bd_nome.Text = "";
                                    bd_email.Text = "";
                                    bd_funcao.Text = "";
                                    bd_senha.Text = "";
                                    bd_repetirsenha.Text = "";
                                }
                                else
                                {
                                    MostrarMensagem(mensagem, false);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensagem(
                    "Ocorreu um erro ao efetuar o registo: " + ex.Message,
                    false
                );
            }
        }


        // ENCRIPTAÇÃO

        public static string EncryptString(string Message)
        {
            string Passphrase = "Gym";
            byte[] Results;

            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            byte[] TDESKey =
                HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DatatoEncrypt = UTF8.GetBytes(Message);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DatatoEncrypt, 0, DatatoEncrypt.Length);
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


        private void MostrarMensagem(string mensagem, bool sucesso)
        {
            lbl_msgm.Text = mensagem;
            lbl_msgm.Visible = true;

            if (sucesso)
            {
                lbl_msgm.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lbl_msgm.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}