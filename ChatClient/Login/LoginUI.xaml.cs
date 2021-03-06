﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using ChatClient.Chat;
using Model;
using RestSharp;

namespace ChatClient.Login
{
    /// <summary>
    /// Interaction logic for LoginUI.xaml
    /// </summary>
    public partial class LoginUI : Window
    {
        public LoginUI()
        {
            InitializeComponent();
            UserNameInput.Text = "florian";
            PasswordInput.Password = "pwd";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_Login_Click(sender, e);
            }
        }

        private async void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await WebserviceAPI.LoginAsync(UserNameInput.Text, PasswordInput.Password);
                await this.Dispatcher.Invoke(async () =>
                {
                    MainChatWindow mainChatWindow = new MainChatWindow();
                    mainChatWindow.Show();
                    this.Close();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void Registration_OnClick(object sender, RoutedEventArgs e)
        {

            RegistrationUI registrationWindow = new RegistrationUI();
            registrationWindow.Show();
            this.Close();
        }
    }
}