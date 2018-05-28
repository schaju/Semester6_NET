using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Model.Chat> ChatList
        {
            get { return (ObservableCollection<Model.Chat>) GetValue(ChatListProperty); }
            set { SetValue(ChatListProperty, value); }
        }
        public static readonly DependencyProperty ChatListProperty = DependencyProperty.Register(
            nameof(ChatList), typeof(IEnumerable<Model.Chat>), typeof(MainChatWindow), new PropertyMetadata(null));

        public ObservableCollection<UserAccount> Contacts
        {
            get { return (ObservableCollection<UserAccount>) GetValue(PropertyTypeProperty); }
            set { SetValue(PropertyTypeProperty, value); }
        }
        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            nameof(Contacts), typeof(ObservableCollection<UserAccount>), typeof(MainChatWindow), new PropertyMetadata(null));

        public MainChatWindow()
        {
            InitializeComponent();

            this.loggedInUserAccount = WebserviceAPI.LoggedInUserAccount;
            LoadContactList();
            LoadChats();

            DataContext = loggedInUserAccount;

            WebserviceAPI.ChatHub.On<int, ChatMessage>("addMessage", (chatId, message) =>
            {
                var chat = Dispatcher.Invoke(() => ListViewChats.SelectedItem) as Model.Chat;
                if (chat.Id == chatId)
                {
                    Dispatcher.Invoke(() =>
                        {
                            var messages = MainContent.ItemsSource as ObservableCollection<ChatMessage>;
                            messages.Add(message);
                        });
                }
                else
                {
                    chat = Dispatcher.Invoke(() => ChatList).FirstOrDefault(c => c.Id == chatId);
                }
                chat.ChatMessages.Add(message);
            });
        }

        private void LoadContactList()
        {
           Contacts = new ObservableCollection<UserAccount>(WebserviceAPI.LoadContactList());
        }

        private void LoadChats()
        {
            ChatList = new ObservableCollection<Model.Chat>(WebserviceAPI.LoadChatList());
            ListViewChats.SelectedItem = ChatList.FirstOrDefault();
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
            Model.Chat selectedChat = (Model.Chat)ListViewChats.SelectedItem;
            if (selectedChat != null)
            {
                WebserviceAPI.ChatHub.Invoke("Send", loggedInUserAccount, selectedChat.Id, TextBoxMessage.Text);
            }
            else
            {
                MessageBox.Show("Bitte Chatfenster auswählen.");
            }

            TextBoxMessage.Text = String.Empty;
        }

        private void ListViewChats_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chat = ListViewChats.SelectedItem as Model.Chat;
            MainContent.ItemsSource = new ObservableCollection<ChatMessage>(chat.ChatMessages);
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
