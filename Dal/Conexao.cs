using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JogoPalavras.Dal
{
    class Conexao
    {
        private MySqlConnection conn;
        //private MySqlCommand command;

        public MySqlConnection Conectar()
        {
            
            //Define string de conexão
            conn = new MySqlConnection("Persist Security Info=True;Server=localhost;Database=db_palavras;Uid=root;Pwd=''");
            
            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("Impossível estabelecer conexão", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            return conn;
            
        }
    }
}
