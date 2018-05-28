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
using ChatClient.Contact;
using ChatClient.Login;
using Microsoft.AspNet.SignalR.Client;
using Model;

namespace ChatClient.Chat
{
    /// <summary>
    /// Interaction logic for MainChatWindow.xaml
    /// </summary>
    public partial class MainChatWindow : Window
    {
        private UserAccount loggedInUserAccount;

        public static readonly DependencyProperty ChatListProp = DependencyProperty.Register(
            nameof(ChatList), typeof(IEnumerable<Model.Chat>), typeof(MainChatWindow), new PropertyMetadata(null));

        public IEnumerable<Model.Chat> ChatList
        {
            get { return (IEnumerable<Model.Chat>) GetValue(ChatListProp); }
            set { SetValue(ChatListProp, value); }
        }

        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            nameof(Contacts), typeof(IEnumerable<UserAccount>), typeof(MainChatWindow), new PropertyMetadata(null));

        public IEnumerable<UserAccount> Contacts
        {
            get { return (IEnumerable<UserAccount>) GetValue(PropertyTypeProperty); }
            set { SetValue(PropertyTypeProperty, value); }
        }

        public MainChatWindow()
        {
            InitializeComponent();

            this.loggedInUserAccount = WebserviceAPI.LoggedInUserAccount;
            LoadContactList();
            LoadChats();

            DataContext = loggedInUserAccount;

            WebserviceAPI.ChatHub.On<string, string>("addMessage", (name, message) =>
                {
                    Console.WriteLine(name);
                    Console.WriteLine(message);
                });
        }

        private void LoadContactList()
        {
           Contacts = WebserviceAPI.LoadContactList();
        }

        private void LoadChats()
        {
            ChatList = WebserviceAPI.LoadChatList();
        }

        private void MainChatWindow_OnClosed(object sender, EventArgs e)
        {
            WebserviceAPI.Logout();
        }

        private void Btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            WebserviceAPI.Logout();

            LoginUI loginUI = new LoginUI();
            loginUI.Show();
            this.Close();
        }

        private void Btn_Send_Click(object sender, RoutedEventArgs e)
        {
            WebserviceAPI.ChatHub.Invoke<string, string>("Send", Console.WriteLine, "name", "message");
        }

        private void ListViewChats_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chat = ListViewChats.SelectedItem as Model.Chat;
            MainContent.ItemsSource = chat.ChatMessages;
        }

        private void Btn_Edit_Profile(object sender, RoutedEventArgs e)
        {
            EditProfileUI editProfileUI = new EditProfileUI();
            editProfileUI.ShowDialog();

            loggedInUserAccount = WebserviceAPI.LoggedInUserAccount;
            DataContext = loggedInUserAccount;
        }

        private void NewContactBtn(object sender, RoutedEventArgs e)
        {
            AddContactUI addContactUI = new AddContactUI(Contacts);
            addContactUI.ShowDialog();

            LoadContactList();
        }
    }
}
