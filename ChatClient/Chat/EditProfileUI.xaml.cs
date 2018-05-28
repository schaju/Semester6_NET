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

namespace ChatClient.Chat
{
    /// <summary>
    /// Interaction logic for EditProfileUI.xaml
    /// </summary>
    public partial class EditProfileUI : Window
    {
        public EditProfileUI()
        {
            InitializeComponent();
            FirstNameInput.Text = WebserviceAPI.LoggedInUserAccount.FirstName;
            LastNameInput.Text = WebserviceAPI.LoggedInUserAccount.LastName;
            UsernameInput.Text = WebserviceAPI.LoggedInUserAccount.UserName;
            PasswordInput.Password = WebserviceAPI.LoggedInUserAccount.Password;
            StatusMessageInput.Text = WebserviceAPI.LoggedInUserAccount.StatusMessage;
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                WebserviceAPI.LoggedInUserAccount.FirstName = FirstNameInput.Text;
                WebserviceAPI.LoggedInUserAccount.LastName = LastNameInput.Text;
                WebserviceAPI.LoggedInUserAccount.UserName = UsernameInput.Text;
                WebserviceAPI.LoggedInUserAccount.Password = PasswordInput.Password;
                WebserviceAPI.LoggedInUserAccount.StatusMessage = StatusMessageInput.Text;
                WebserviceAPI.ChangeUserAccount();
                this.Close();
            }));
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                this.Close();
            }));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_Save_Click(sender, e);
            }
        }
    }
}
