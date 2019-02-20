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
    /// Lógica interna para Ranking.xaml
    /// </summary>
    public partial class Ranking : Window
    {
        private int idUser;
        
        public Ranking()
        {
            InitializeComponent();
            loadProgressbar();
        }

        public Ranking(int idUser)
        {
            this.idUser = idUser;
            InitializeComponent();
            loadProgressbar();
        }

       

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
            */
            int i = 0;
            int[] valor = new int[3];
            for(i=0; i<3; i++)
            {
                user.IdUser = i+1;
                valor[i] = scoreDal.SelectPontos(user);
            }
            



            Duration dur = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation ani = new DoubleAnimation(valor[0], dur);
            pb1.BeginAnimation(ProgressBar.ValueProperty, ani);

            Duration dur2 = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation ani2 = new DoubleAnimation(valor[1], dur2);
            pb2.BeginAnimation(ProgressBar.ValueProperty, ani2);

            Duration dur3 = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation ani3 = new DoubleAnimation(valor[2], dur3);
            pb3.BeginAnimation(ProgressBar.ValueProperty, ani3);

            lbl1.Content = valor[0];
            lbl2.Content = valor[1];
            lbl3.Content = valor[2];

            //IMAGENS
            var uri = new Uri("pack://application:,,,/Diego.jpg");
            var bitmap = new BitmapImage(uri);
            image1.Source = bitmap;

            var uri2 = new Uri("pack://application:,,,/Silvio.jpg");
            var bitmap2 = new BitmapImage(uri2);
            image2.Source = bitmap2;

            var uri3 = new Uri("pack://application:,,,/Renata.jpg");
            var bitmap3 = new BitmapImage(uri3);
            image3.Source = bitmap3;

        }

        private void Window_Initialized(object sender, EventArgs e)
        {

        }
    }
}
