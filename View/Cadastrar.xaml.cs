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
using JogoPalavras.Bll;
using JogoPalavras.Dal;
using JogoPalavras.Model;

namespace View
{
    
    public partial class Cadastrar : Window
    {
        FunctionBll bll = new FunctionBll();
        UserInformation userModel = new UserInformation();

        public Cadastrar()
        {
            InitializeComponent();
            
        }

        public int Entrar()
        {
            string usuario = Convert.ToString(txtLogin.Text);
            string senha = Convert.ToString(txtSenha.Text);
            int iduser = Convert.ToInt32(bll.Logado(usuario, senha));
            return iduser;
        }

        private void btnCadastrar_click(object sender, RoutedEventArgs e)
        {
            if(txtLogin.Text != "" && txtSenha.Text != "")
            {
                if (txtSenha.Text == txtConfirma.Text)
                {
                    userModel.Username = Convert.ToString(txtLogin.Text);
                    userModel.Password = Convert.ToString(txtSenha.Text);
                    bool res;
                    res = bll.Incluir(userModel);
                    Aviso aviso = new Aviso("Usuário cadstrado!");
                    aviso.Show();

                    if(Entrar() > 0){
                        WindowGame janelaJogo = new WindowGame();
                        janelaJogo.Show();
                    }
                    this.Close();
                    

                }
                else
                {
                    Aviso aviso = new Aviso("Senhas diferentes!");
                    aviso.Show();
                    txtSenha.Text = "";
                    txtConfirma.Text = "";
                }
            }
            else
            {
                Aviso aviso = new Aviso("Preencher campos obrigatórios!");
                aviso.Show();
            }
            
        }

        private void txtLogin_PerdeFoco(object sender, RoutedEventArgs e)
        {
            
            if(txtLogin.Text == "")
            {
                retLogin.Fill = Brushes.Red;
            }
            else
            {
                userModel.Username = txtLogin.Text;
                UserDal userDal = new UserDal();
                bool res;
                //select por codigo
                res = userDal.SelectUser(userModel);
                if (res)
                {
                    Aviso aviso = new Aviso("Usuário já cadastrado!");
                    aviso.Show();
                    
                    txtLogin_RecebeFoco(sender, e);

                }
               

            
            }
        }

        private void txtLogin_RecebeFoco(object sender, RoutedEventArgs e)
        {
           
            txtLogin.Text = "";
            retLogin.Fill = Brushes.White;
        }
    }
}
