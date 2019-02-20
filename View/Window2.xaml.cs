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
    /// <summary>
    /// Lógica interna para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private string usuario;
        private int rodada;

        public Window2()
        {
            InitializeComponent();
        }

        public Window2(string usuario, int rodada)
        {
            this.usuario = usuario;
            this.rodada = rodada;
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
                    score.IdLetter = rodada;
                }
            }
            //busca ponto pelo id
            int ponto = scoreDal.SelectPontosRodada(score);
            //busca ponto da média
            int pontoMedia = scoreDal.SelectPontosMediaRodada(score);

            //tamanho da progressbar dinammico
            if (pontoMedia >= ponto)
            {
                pbMedia.Maximum = pontoMedia * 1.30;
                pbUsuario.Maximum = pontoMedia * 1.30;
            }else
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

        private void btnContinuar_click(object sender, RoutedEventArgs e)
        {
            WindowGame janela = new WindowGame();
            janela.Show();
            WindowGame2.Close();

        }

        private void btnParar_click(object sender, RoutedEventArgs e)
        {
            Inicial janelaInicio = new Inicial();
            janelaInicio.Show();
            WindowGame2.Close();
        }

        private void btnRanking_click(object sender, RoutedEventArgs e)
        {
            RankGeral janelaRanking = new RankGeral(usuario);
            janelaRanking.Show();

        }
    }
}
