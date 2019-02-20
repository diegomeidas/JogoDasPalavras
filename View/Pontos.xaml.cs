using JogoPalavras.Bll;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Lógica interna para Pontos.xaml
    /// </summary>
    public partial class Pontos : Window
    {
        public Pontos()
        {
            InitializeComponent();
        }
        ScoresInformation score = new ScoresInformation();
        ScoresDal scoreDal = new ScoresDal();
        UserDal userDal = new UserDal();
        FunctionBll bll = new FunctionBll();
       // static int idUser;

        //QUANDO ABRIR COMBOBOX
        private void comboBox_DropDownOpened(object sender, EventArgs e)
        {
            comboBox.Items.Clear();
            MySqlDataReader usuario = userDal.Select();
            while (usuario.Read())
            {
                comboBox.Items.Add(usuario["username"]);
            }
        }
        //QUANDO ESCOLHER OPÇÃO COMBOBOX
        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            //pega o nome selecionado
            string nome = comboBox.SelectedItem.ToString();
            MySqlDataReader usuario = userDal.Select();
            while (usuario.Read())
            {
                if((Convert.ToString(usuario["username"]) == nome))
                {
                    score.IdUser = Convert.ToInt32(usuario["idUser"]);

                    //image.Source = (BitmapImage)Application.Current.FindResource("fundo2.jpg");
                    //image.Source = (BitmapImage)Application.Current.Resources["C:/Users/House/Documents/Visual Studio 2015/Projects/JogoPalavras 3 -funcionando/View/fundo2.jpg"];
                    //image.Source = new BitmapImage(new Uri("pack://application:/Images/Tiles/fundo2.jpg"));

                    if (score.IdUser == 1)
                    {
                        var uri = new Uri("pack://application:,,,/Diego.jpg");
                        var bitmap = new BitmapImage(uri);
                        image.Source = bitmap;
                    }else if (score.IdUser == 2)
                    {
                        var uri = new Uri("pack://application:,,,/Renata.jpg");
                        var bitmap = new BitmapImage(uri);
                        image.Source = bitmap;
                    }else if(score.IdUser == 3)
                    {
                        var uri = new Uri("pack://application:,,,/Silvio.jpg");
                        var bitmap = new BitmapImage(uri);
                        image.Source = bitmap;
                    }else
                    {
                        var uri = new Uri("pack://application:,,,/interrogacao.jpg");
                        var bitmap = new BitmapImage(uri);
                        image.Source = bitmap;
                    }
                    
                }
            }
            /*
            MySqlDataReader ponto = scoreDal.Select(score);
            while (ponto.Read())
            {
                txtPontos.Text = Convert.ToString(ponto["score"]);
            }
            */
            int ponto = scoreDal.SelectPontos(score);
            txtPontos.Text = Convert.ToString(ponto);
        }

        

        private void btnRanking_Click(object sender, RoutedEventArgs e)
        {
            Ranking janela = new Ranking(score.IdUser);
            janela.Show();
        }
    }
}
