using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoPalavras.Model;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Markup;

namespace JogoPalavras.Dal
{
    public class WordsDal
    {

        //private MySqlCommand command;

        public MySqlDataReader Select(int id)
        {
            Conexao conn = new Conexao();
            String select = "SELECT * FROM tb_words WHERE idletter = "+id;
            MySqlCommand command = new MySqlCommand(select, conn.Conectar());
            MySqlDataReader dados = command.ExecuteReader();
            conn.Conectar().Close();
            return dados;
        }










        /*
        public DataTable Listar()
        {
            
            DataTable tabela = new DataTable();
            
            MySqlDataAdapter data = new MySqlDataAdapter("SELECT * FROM tb_words", Dados.StringDeConexao);
            data.Fill(tabela);
            
            return tabela;
            
        }
        */

    }
}
