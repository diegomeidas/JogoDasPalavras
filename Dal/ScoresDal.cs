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
    public class ScoresDal
    {
        private MySqlCommand command;

        //SELECT TOTAL
        public MySqlDataReader Select()
        {
            Conexao conn = new Conexao();
            String select = "SELECT * FROM tb_scores";
            command = new MySqlCommand(select, conn.Conectar());
            MySqlDataReader dados = command.ExecuteReader();
            conn.Conectar().Close();
            return dados;
        }

        //SELECT PELO USUARIO (TUDO)
        public MySqlDataReader Select(ScoresInformation score)
        {            
            Conexao conn = new Conexao();
            String select = "SELECT * FROM tb_scores WHERE iduser = " + score.IdUser;
            command = new MySqlCommand(select, conn.Conectar());
            MySqlDataReader dados = command.ExecuteReader();            
            conn.Conectar().Close();            
            return dados;
        }

        //------------------------------------------------------------------
        //SELECIONA TODOS OS PONTOD DO USUARIO (TODAS AS RODADAS)
        public int SelectPontos(ScoresInformation score)
        {
            Conexao conn = new Conexao();
            String select = "SELECT * FROM tb_scores";
            command = new MySqlCommand(select, conn.Conectar());
            MySqlDataReader dados = command.ExecuteReader();
            int pontos = 0, rodada=0;
            while (dados.Read())
            {
                if(Convert.ToInt32(dados["iduser"]) == Convert.ToInt32(score.IdUser))
                {
                    pontos += Convert.ToInt32(dados["score"]);
                    rodada++;
                }
            }
            conn.Conectar().Close();
            pontos = pontos / rodada;
            return pontos;
        }

        //------------------------------------------------------------------
        //SELECIONA TODOS OS PONTOS DO USUARIO (POR RODADA)
        public int SelectPontosRodada(ScoresInformation score)
        {
            Conexao conn = new Conexao();
            String select = "SELECT * FROM tb_scores";
            command = new MySqlCommand(select, conn.Conectar());
            MySqlDataReader dados = command.ExecuteReader();
            int pontos = 0;
            while (dados.Read())
            {
                if (Convert.ToInt32(dados["iduser"]) == Convert.ToInt32(score.IdUser))
                {
                    if(Convert.ToInt32(dados["idletter"]) == Convert.ToInt32(score.IdLetter))
                    {
                        pontos += Convert.ToInt32(dados["score"]);
                    }
                    
                }
            }
            conn.Conectar().Close();
            return pontos;
        }

        //------------------------------------------------------------------
        //SELECIONA OS PONTOS DA MEDIA (TODAS AS RODADAS)
        public int SelectPontosMedia(ScoresInformation score)
        {
            Conexao conn = new Conexao();
            String select = "SELECT * FROM tb_scores";
            command = new MySqlCommand(select, conn.Conectar());
            MySqlDataReader dados = command.ExecuteReader();
            int pontos = 0;
            while (dados.Read())
            {
                if (Convert.ToInt32(dados["iduser"]) != Convert.ToInt32(score.IdUser))
                {
                    pontos += Convert.ToInt32(dados["score"]);
                }
            }
            conn.Conectar().Close();
            return pontos;
        }

        //------------------------------------------------------------------
        //SELECIONA OS PONTOS DA MEDIA (POR RODADA)
        public int SelectPontosMediaRodada(ScoresInformation score)
        {
            Conexao conn = new Conexao();
            String select = "SELECT * FROM tb_scores";
            command = new MySqlCommand(select, conn.Conectar());
            MySqlDataReader dados = command.ExecuteReader();
            int pontos = 0, count =0;
            while (dados.Read())
            {
                if (Convert.ToInt32(dados["iduser"]) != Convert.ToInt32(score.IdUser))
                {
                    if(Convert.ToInt32(dados["idletter"]) == Convert.ToInt32(score.IdLetter))
                    {
                        pontos += Convert.ToInt32(dados["score"]);
                        count++;
                    }                    
                }
            }
            if (count == 0)
                count = 1;
            pontos = pontos / count;
            conn.Conectar().Close();
            return pontos;
        }

        //------------------------------------------------------------------
        //INSERIR PONTOS 
        public void Insert (ScoresInformation score)
        {
            Conexao conn = new Conexao();            
            try
            {
                //confere se usuario ja jogou antes
                //se sim, então deleta os pontos anteriores
                if (score.IdLetter == 1)
                {
                    MySqlDataReader dados = Select(score);
                    while (dados.Read())
                    {
                        if (Convert.ToInt32(dados["idLetter"]) == 1)
                        {
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn.Conectar();
                            cmd.CommandText = "DELETE FROM tb_scores WHERE idUser =" + score.IdUser;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                //realiza insesão
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn.Conectar();
                cmd2.CommandText = "INSERT INTO tb_scores(date,score,idUser,idLetter) VALUES(@data, @ponto, @usuario, @letter)";
                cmd2.Parameters.AddWithValue("@data", DateTime.Now);
                cmd2.Parameters.AddWithValue("@ponto", score.Score);
                cmd2.Parameters.AddWithValue("@usuario", score.IdUser);
                cmd2.Parameters.AddWithValue("@letter", score.IdLetter);
                cmd2.ExecuteNonQuery();                
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
        }
    }
}
