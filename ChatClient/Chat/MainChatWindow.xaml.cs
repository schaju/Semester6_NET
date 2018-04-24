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
using ChatClient.Login;
using Model;

namespace ChatClient.Chat
{
    /// <summary>
    /// Interaction logic for MainChatWindow.xaml
    /// </summary>
    public partial class MainChatWindow : Window
    {
        private UserAccount loggedInUserAccount;

        public MainChatWindow()
        {
            InitializeComponent();

            this.loggedInUserAccount = WebserviceAPI.LoggedInUserAccount;
            LoadContactList();

            DataContext = loggedInUserAccount;
        }

        private void LoadContactList()
        {
            WebserviceAPI.LoadContactList();
        }

        private void MainChatWindow_OnClosed(object sender, EventArgs e)
        {
            WebserviceAPI.Logout();
        }

        private void Btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                WebserviceAPI.Logout();

                LoginUI loginUI = new LoginUI();
                loginUI.Show();
                this.Close();
            }));
        }
    }
}
