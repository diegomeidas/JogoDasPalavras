using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoPalavras.Model;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace JogoPalavras.Dal
{
    public class UserDal
    {
        //private MySqlCommand command;

        public MySqlDataReader Select()
        {
            Conexao conn = new Conexao();
            MySqlCommand command = new MySqlCommand();
            String select = "SELECT * FROM tb_users";
            command = new MySqlCommand(select, conn.Conectar());
            MySqlDataReader dados = command.ExecuteReader();
            return dados;
        }

        public bool SelectUser(UserInformation user)
        {
            bool res = false;
            Conexao conn = new Conexao();
            MySqlCommand command = new MySqlCommand();
            String select = "SELECT username FROM tb_users";
            command = new MySqlCommand(select, conn.Conectar());
            MySqlDataReader dados = command.ExecuteReader();
            while (dados.Read())
            {
                if (Convert.ToString(dados["username"]) == user.Username)
                    res = true;
            }
            conn.Conectar().Close();
            
            return res;
        }

        //INCLUIR CADASTRO DE JOGADOR
        public bool Incluir(UserInformation user)
        {
            bool res = false;
            Conexao conn = new Conexao();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.Conectar();                
                cmd.CommandText = "INSERT INTO tb_users(username, password) VALUES(@usuario, @senha)";
                cmd.Parameters.AddWithValue("@usuario", user.Username);
                cmd.Parameters.AddWithValue("@senha", user.Password);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Cliente cadastrado com sucesso.", "Cadastro", MessageBoxButton.OK, MessageBoxImage.Information);
                res = true;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro no Servidor: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Conectar().Close();
            }
            return res;
        }



    }
}
