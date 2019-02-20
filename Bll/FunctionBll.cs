using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using JogoPalavras.Dal;
using JogoPalavras.Model;

namespace JogoPalavras.Bll
{
    public class FunctionBll
    {
        //pega o usuario logado
        public static string usuario;
        public static int iduser = 0;

        public static string[] palavras = new string[30];
        static int indice;
        public static int count = 0;

        LettersDal letterDal = new LettersDal();
        WordsDal wordDal = new WordsDal();
        UserDal userDal = new UserDal();
        ScoresDal scoreDal = new ScoresDal();
        static int id;

        public string SelectLetters(int count)
        {
            string palavra ="";
            MySqlDataReader dados = letterDal.Select();
            //int count = 2;
            while (dados.Read())
            {
                if(Convert.ToInt32(dados["idletter"]) == count)
                {
                    id = Convert.ToInt32(dados["idletter"]);
                    palavra = dados["l1"].ToString() +
                            dados["l2"].ToString() +
                            dados["l3"].ToString() +
                            dados["l4"].ToString() +
                            dados["l5"].ToString();
                }
            }
            return palavra;
        }

        //VERIFICA SE PALAVRA EXISTE NO BANCO
        public bool comparaPalavraBanco(string palavra)
        {
            MySqlDataReader dados = wordDal.Select(id);
            bool res = false;
            while (dados.Read())
            {
                if (Convert.ToString(dados["word"]) == palavra)
                    res = true;
            }      
            return res;
        }

        //COMPARA PALAVRA STRING
        public bool comparaPalavraString(string palavra)
        {
            bool res = false;
            int cont = 0;
            
            //se for a 1ª vez
            if (indice == 0)
            {
                palavras[indice] = palavra;
                indice++;
                return true;
            }

            //senão
            int i = 0;
            while (i < indice)
            {                
                if (palavras[i] == palavra)
                {
                    return false; //se palavra ja existe
                }
                else
                {
                    cont = 1;
                    i++;
                }
            }
            if (cont == 1)
            {
                palavras[indice] = palavra;
                indice++;
                res = true; //palavra aceita
            }
            return res;
        }
               

        //PONTUAÇÃO
        int pontos = 0;
        public int AddPontos(int palavra)
        {
            
            if(palavra == 3)
            {
                pontos += 10;
            }else if(palavra == 4)
            {
                pontos += 20;
            }
            else if(palavra == 5)
            {
                pontos += 30;
            }
            return pontos;
        }

        //CONFIRMA SE LOGADO
        public int Logado(string user, string pass)
        {
            
            MySqlDataReader dados = userDal.Select();
            int count = 0;
            while (dados.Read())
            {
                if (Convert.ToString(dados["username"]) == user)                    
                {
                    //pega usuario logado
                    usuario = Convert.ToString(dados["username"]);
                    if (Convert.ToString(dados["password"]) == pass)
                    {
                        iduser = Convert.ToInt32(dados["iduser"]);
                        count = 1;
                    }
                }                
            }
            if (count == 0)
                MessageBox.Show("Usuário ou Senha não confere", null, MessageBoxButton.OK, MessageBoxImage.Information);

            return iduser;
        }

        //PEGA USUARIO LOGADO
        public string Username()
        {
            return usuario;
        }

        //INCLUIR CADASTRO DE JOGADOR        
        public bool Incluir(UserInformation user)
        {
            bool res =  userDal.Incluir(user);
            return res;            
        }

        //INCLUIR PONTOS JOGADORES
        public void InserirPontos(int pontos, int indice)
        {
            ScoresInformation score = new ScoresInformation();
            score.IdUser = iduser;
            score.Score = pontos;
            score.IdLetter = indice;
            scoreDal.Insert(score);
        }

        //CONSULTAR PONTOS JOGADORES
        public MySqlDataReader ConsultarPontos(ScoresInformation score)
        {
            //ScoresInformation score = new ScoresInformation();
            score.IdUser = iduser;
            MySqlDataReader dados = scoreDal.Select(score);
            return dados;
        }
    }
}
