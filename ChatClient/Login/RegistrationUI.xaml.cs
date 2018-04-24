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
using ChatClient.Chat;

namespace ChatClient.Login
{
    /// <summary>
    /// Interaction logic for RegistrationUI.xaml
    /// </summary>
    public partial class RegistrationUI : Window
    {
        public RegistrationUI()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_Registration_Click(sender, e);
            }
        }

        private void Btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                try
                {
                    WebserviceAPI.Registrate(FirstNameInput.Text, LastNameInput.Text, UsernameInput.Text, PasswordInput.Password, StatusMessageInput.Text);

                    MainChatWindow mainChatWindow = new MainChatWindow();
                    mainChatWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }));

        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                LoginUI loginWindow = new LoginUI();
                loginWindow.Show();
                this.Close();
            }));
        }
    }
}
