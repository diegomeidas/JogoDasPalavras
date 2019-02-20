using JogoPalavras.Dal;
using JogoPalavras.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{

    public partial class RankGeral : Window
    {
        private string usuario;

        public RankGeral()
        {
            InitializeComponent();
        }

        public RankGeral(string usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            pontuacao();
        }

        public void pontuacao()
        {
            UserDal userDal = new UserDal();
            ScoresDal scoreDal = new ScoresDal();
            ScoresInformation score = new ScoresInformation();
            //busca usuário pelo nome
            MySqlDataReader usuario = userDal.Select();
            while (usuario.Read())
            {
                if ((Convert.ToString(usuario["username"]) == this.usuario))
                {
                    score.IdUser = Convert.ToInt32(usuario["idUser"]);
                }
            }
            //busca ponto pelo id
            int ponto = scoreDal.SelectPontos(score);
            //busca ponto da média
            int pontoMedia = scoreDal.SelectPontosMedia(score);

            //tamanho da progressbar dinammico
            if (pontoMedia >= ponto)
            {
                pbMedia.Maximum = pontoMedia * 1.30;
                pbUsuario.Maximum = pontoMedia * 1.30;
            }
            else
            {
                pbMedia.Maximum = ponto * 1.30;
                pbUsuario.Maximum = ponto * 1.30;
            }


            //animação da progressbar
            txtPontoUsuario.Text = Convert.ToString(ponto);
            txtUsuario.Text = this.usuario;
            Duration dur = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation ani = new DoubleAnimation(ponto, dur);
            pbUsuario.BeginAnimation(ProgressBar.ValueProperty, ani);

            //animação da progressbar
            txtPontoMedia.Text = Convert.ToString(pontoMedia);
            Duration durMedia = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation aniMedia = new DoubleAnimation(pontoMedia, durMedia);
            pbMedia.BeginAnimation(ProgressBar.ValueProperty, aniMedia);
        }

        /*
        //PEGA A PONTUAÇÃO DO USUARIO E COMPARA 
        //COM A MÉDIA GERAL DOS OUTROS JOGADORES
        private void loadProgressbar()
        {
            ScoresInformation user = new ScoresInformation();
            //user.IdUser = idUser;
            ScoresDal scoreDal = new ScoresDal();
            /*
            MySqlDataReader pontos = score.Select();
            
            int i = 0;
            int[] valor = new int[3];
            while (pontos.Read())
            {
                valor[i] = Convert.ToInt32(pontos["score"]);
                i++;
            }
            
            int i = 0;
            int[] valor = new int[3];
            for (i = 0; i < 3; i++)
            {
                user.IdUser = i + 1;
                valor[i] = scoreDal.SelectPontos(user);
            }




            Duration dur = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation ani = new DoubleAnimation(valor[0], dur);
            pbMedia.BeginAnimation(ProgressBar.ValueProperty, ani);

            Duration dur2 = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation ani2 = new DoubleAnimation(valor[1], dur2);
            pbUsuario.BeginAnimation(ProgressBar.ValueProperty, ani2);



            //lbl1.Content = valor[0];
            //lbl2.Content = valor[1];
            //lbl3.Content = valor[2];


        }
        */
        private void btnSair_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
