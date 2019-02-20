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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JogoPalavras.Bll;
using System.Windows.Threading;

namespace View
{
    public partial class Window1 : Window
    {
        Window2 janela2 = new Window2();
        Inicial janelaInicio = new Inicial();
        FunctionBll bll = new FunctionBll();
        static int count = 1;

        public Window1()
        {
            //InitializeComponent();
        }


        
        
        public void windowIni(object sender, EventArgs e)
        {
            //janelaInicio.Show();
            //WindowGame.Close();
            Contagem();
            Random();
        }

        char a1, a2, a3, a4, a5;
        int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0;
        int tamanhoPalavra = 0;

        public void Random()
        {
            
            string palavra = bll.SelectLetters(count);

            btn1.Content = palavra.Substring(0, 1);
            btn2.Content = palavra.Substring(1, 1);
            btn3.Content = palavra.Substring(2, 1);
            btn4.Content = palavra.Substring(3, 1);
            btn5.Content = palavra.Substring(4, 1);
            count++;

            //FUNÇÃO UTILIZANDO PALAVRAS
            /*
            string consoantes = "BCDFGHJKLMNPQRSTVZ";
            string vogais = "AEIOU";
            btn1.Content = vogais.Substring(random.Next(1, 5), 1);
            btn2.Content = consoantes.Substring(random.Next(1, 18), 1);
            btn3.Content = vogais.Substring(random.Next(1, 5), 1);
            btn4.Content = consoantes.Substring(random.Next(1, 18), 1);
            btn5.Content = vogais.Substring(random.Next(1, 5), 1);
           */
        }



        
        



        public void Contagem()
        {
            nuvem1.Visibility = Visibility.Collapsed;
            nuvem2.Visibility = Visibility.Collapsed;
            nuvem3.Visibility = Visibility.Collapsed;

            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 0, 1); //intervalo de tempo, hora, min, segundo
            //timer.Tick += new EventHandler(timer_Tick);

            int hora = 00;
            int min = 00;
            int sec = 49;

            //FUNÇÃO TICK DE 1 SEGUNDO
            timer.Tick += (s, a) =>
            {
                string tempo = Convert.ToString(hora) + ":" + Convert.ToString(min) + ":" + Convert.ToString(sec);

                //QUANDO TIMER ZERAR, FECHA TELA 1 E ABRE TELA 2
                if (txtTime.Text == "00:00")
                {
                    try
                    {
                        //abre proxima janela
                        janela2.Show();
                        //fecha janela principal
                        WindowGame.Close();
                    }
                    catch
                    {
                        //quando fechar a janela 2, inicializa janela principal
                        WindowGame.Initialized += WindowGame_Initialized;
                    }
                }
                else
                {
                    txtTime.Text = Convert.ToDateTime(tempo).ToString("mm:ss");
                }

                if (sec > 0)
                    sec--;
                else if (sec <= 0)
                {
                    min--;
                    sec = 59;

                }
            };
            timer.Start();
        }

        

        private void WindowGame_Initialized(object sender, EventArgs e)
        {
            Contagem();
            Random();
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;
        }

        
      


        private void btnAplicar_click(object sender, RoutedEventArgs e)
        {
            
            //VERIFICA SE A PALAVRA É >= 3 LETRAS
            if (tamanhoPalavra >= 3)
            {

                //VERIFICA SE PALAVRA EXISTE NO BANCO
                if (bll.comparaPalavra(lblResultado.Content.ToString()))
                {
                    //MOVIMENTAÇÃO DAS NUVENS
                    if (nuvem1.Visibility == Visibility.Collapsed)
                    {
                        nuvem1.Visibility = Visibility.Visible;
                        nuvem1.Content = lblResultado.Content;
                        if (nuvem3.Visibility == Visibility.Visible)
                            nuvem3.Visibility = Visibility.Collapsed;
                    }
                    else if (nuvem1.Visibility == Visibility.Visible && nuvem2.Visibility == Visibility.Collapsed)
                    {
                        nuvem2.Visibility = Visibility.Visible;
                        nuvem2.Content = lblResultado.Content;
                    }
                    else
                    {
                        nuvem3.Visibility = Visibility.Visible;
                        nuvem3.Content = lblResultado.Content;
                        nuvem1.Visibility = Visibility.Collapsed;
                        nuvem2.Visibility = Visibility.Collapsed;
                    }

                    btn1.IsEnabled = true;
                    btn2.IsEnabled = true;
                    btn3.IsEnabled = true;
                    btn4.IsEnabled = true;
                    btn5.IsEnabled = true;

                    int pontos = bll.AddPontos(tamanhoPalavra);
                    lblPontos.Content = pontos;

                    //limpa textBox Palavra
                    lblResultado.Content = "";
                    count1 = 0; count2 = 0; count3 = 0; count4 = 0; count5 = 0;
                    tamanhoPalavra = 0;
                }
                else
                {
                    MessageBox.Show("Palavra inexistente", null, MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }


            }
            else
            {
                MessageBox.Show("Mínimo 3 letras", null, MessageBoxButton.OK, MessageBoxImage.Information);
            }


            
        }

        private void LimparClick(object sender, RoutedEventArgs e)
        {
            lblResultado.Content = "";
            count1 = 0; count2 = 0; count3 = 0; count4 = 0; count5 = 0;
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;
        }


        private void btn1Click(object sender, RoutedEventArgs e)
        {
            if (count1 == 0)
            {
                
                a1 = Convert.ToChar(btn1.Content);
                lblResultado.Content += Convert.ToString(a1);
                count1 = 1;
                tamanhoPalavra++;

                btn1.IsEnabled = false;
                
                

                //btn1.Background = Brushes.Black;
            }
        }
        

        private void btn2Click(object sender, RoutedEventArgs e)
        {
            if (count2 == 0)
            {
                a2 = Convert.ToChar(btn2.Content);
                lblResultado.Content += Convert.ToString(a2);
                count2 = 1;
                tamanhoPalavra++;
                //btn2.Background = Brushes.Black;
                btn2.IsEnabled = false;
            }
        }

        private void btn3Click(object sender, RoutedEventArgs e)
        {
            if (count3 == 0)
            {
                a3 = Convert.ToChar(btn3.Content);
                lblResultado.Content += Convert.ToString(a3);
                count3 = 1;
                tamanhoPalavra++;
                //btn3.Background = Brushes.Black;
                btn3.IsEnabled = false;
            }
        }

        private void btn4Click(object sender, RoutedEventArgs e)
        {
            if (count4 == 0)
            {
                a4 = Convert.ToChar(btn4.Content);
                lblResultado.Content += Convert.ToString(a4);
                count4 = 1;
                tamanhoPalavra++;
                //btn4.Background = Brushes.Black;
                btn4.IsEnabled = false;
            }
        }

        private void btn5Click(object sender, RoutedEventArgs e)
        {
            if (count5 == 0)
            {
                a5 = Convert.ToChar(btn5.Content);
                lblResultado.Content += Convert.ToString(a5);
                count5 = 1;
                tamanhoPalavra++;
                //btn5.Background = Brushes.Black;
                btn5.IsEnabled = false;
            }
        }
    }
}

