using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoPalavras.Model;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace JogoPalavras.Dal
{
    public class LettersDal
    {
        private MySqlCommand command;

        public MySqlDataReader Select()
        {
            Conexao conn = new Conexao();
            
            //DataTable table = new DataTable();
            String select = "SELECT * FROM tb_letters";
            command = new MySqlCommand(select, conn.Conectar());

            //executa a leitura
            MySqlDataReader dados = command.ExecuteReader();
            conn.Conectar().Close();
            return dados;
        }
        /*

        public DataTable Listar()
        {
            Conexao conn = new Conexao();
            DataTable tabela = new DataTable();
            MySqlDataAdapter data = new MySqlDataAdapter("SELECT * FROM tb_letters", conn.Conectar());
            data.Fill(tabela);        
           
            return tabela;
        }

        */
        public void Incluir(LettersInformation letter){

            MySqlConnection conn = new MySqlConnection();
            try
            {                
                //conn.ConnectionString = Dados.StringDeConexao;

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                //select @@IDENTITY: retorna o id da inserção
                cmd.CommandText = "INSERT INTO tb_letters(l1, l2, l3, l4, l5) VALUES(@l1, @l2, @l3, @l4, @l5); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@l1", letter.L1);
                cmd.Parameters.AddWithValue("@l2", letter.L2);
                cmd.Parameters.AddWithValue("@l3", letter.L3);
                cmd.Parameters.AddWithValue("@l4", letter.L4);
                cmd.Parameters.AddWithValue("@l5", letter.L5);
                //conn.Open();
                //letter.IdLetter = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch(MySqlException ex)
            {
                throw new Exception("Erro no Servidor: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            

        }





    }
}
