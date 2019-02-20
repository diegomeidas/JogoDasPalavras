﻿using System;
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
using System.Windows.Threading;

namespace View
{
    /// <summary>
    /// Lógica interna para Aviso.xaml
    /// </summary>
    public partial class Aviso : Window
    {
        private string frase;
        public Aviso()
        {
            InitializeComponent();
        }
        public Aviso(string str)
        {
            this.frase = str;
            InitializeComponent();
            aviso();
        }

        public void aviso()
        {
            lblFrase.Content = this.frase;
            fechar();
        }

        public void fechar()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            int sec = 2;
            timer.Tick += (s, a) =>
            {
                if (sec > 0)
                    sec--;
                else
                {
                    timer.Stop();
                    this.Close();
                }

            };
            timer.Start();

        }
    }
}
