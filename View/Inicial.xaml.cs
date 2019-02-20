using JogoPalavras.Bll;
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
    /// Lógica interna para Inicial.xaml
    /// </summary>
    public partial class Inicial : Window
    {

        FunctionBll bll = new FunctionBll();

        public Inicial()
        {
            InitializeComponent();
            txtLogin.Focus();
        }


        public int Entrar()
        {
            string usuario = Convert.ToString(txtLogin.Text);
            string senha = Convert.ToString(txtPass.Password);
            int iduser = Convert.ToInt32(bll.Logado(usuario, senha));
            return iduser;
        }

        private void btnJogar_Click(object sender, RoutedEventArgs e)
        {
            if (Entrar() > 0)
            {
                //chamar pagina de jogo
                WindowGame janelaGame = new WindowGame();
                janelaGame.Show();
                Hide();
            }
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnComoJogar_Click(object sender, RoutedEventArgs e)
        {
            Regras janelaRegras = new Regras();
            janelaRegras.Show();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Cadastrar janelaCadastro = new Cadastrar();
            janelaCadastro.Show();
        }

        private void btnPontos_Click(object sender, RoutedEventArgs e)
        {
            RankGeral ranking = new RankGeral();
            ranking.Show();
        }
    }


}
