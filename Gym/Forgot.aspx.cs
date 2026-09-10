using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Gym
{
    public partial class Forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            lblEmailErro.Visible = false;
            lblSucesso.Visible = false;
            hl_Login.Visible = false;

            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            string email = bd_email.Text.Trim();
            string novaSenha = bd_novasenha.Text;
            string novaSenhaEncriptada = EncryptString(novaSenha);

            string connectionString =
                ConfigurationManager.ConnectionStrings["GymConnectionString"].ConnectionString;

            using (SqlConnection myconn = new SqlConnection(connectionString))
            {
                myconn.Open();
                string sql = "SELECT COUNT(*) FROM Funcionarios WHERE Email = @Email";

                using (SqlCommand verificarEmail = new SqlCommand(sql, myconn))
                {
                    verificarEmail.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;

                    int quantidade = (int)verificarEmail.ExecuteScalar();

                    if (quantidade == 0)
                    {
                        lblEmailErro.Text = "O email indicado não está vinculado a nenhum colaborador.";
                        lblEmailErro.Visible = true;

                        return;
                    }
                }

                using (SqlCommand alterarSenha = new SqlCommand(
                    "sp_AlterarSenhaFuncionario", myconn))
                {
                    alterarSenha.CommandType = CommandType.StoredProcedure;

                    alterarSenha.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;
                    alterarSenha.Parameters.Add("@NovaSenha", SqlDbType.NVarChar, 255).Value = novaSenhaEncriptada;

                    alterarSenha.ExecuteNonQuery();
                }

                lblSucesso.Text = "Palavra-passe alterada com sucesso!";
                lblSucesso.Visible = true;
                hl_Login.Visible = true;
            }
        }

        protected void hl_Voltar_Click(object sender, EventArgs e)
        {

        }

        public static string EncryptString(string Message)
        {
            string Passphrase = "Gym";
            byte[] Results;

            System.Text.UTF8Encoding UTF8 =
                new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider =
                new MD5CryptoServiceProvider();

            byte[] TDESKey =
                HashProvider.ComputeHash(
                    UTF8.GetBytes(Passphrase)
                );

            TripleDESCryptoServiceProvider TDESAlgorithm =
                new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DatatoEncrypt = UTF8.GetBytes(Message);

            try
            {
                ICryptoTransform Encryptor =
                    TDESAlgorithm.CreateEncryptor();

                Results = Encryptor.TransformFinalBlock(
                    DatatoEncrypt,
                    0,
                    DatatoEncrypt.Length
                );
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