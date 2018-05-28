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
using Model;

namespace ChatClient.Contact
{
    /// <summary>
    /// Interaction logic for AddContactUI.xaml
    /// </summary>
    public partial class AddContactUI : Window
    {
        private List<UserAccount> Contacts;
        public AddContactUI(IEnumerable<UserAccount> Contacts)
        {
            InitializeComponent();
            this.Contacts = Contacts.ToList();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                this.Close();
            }));
        }

        private void Btn_AddContact_Click(object sender, RoutedEventArgs e)
        {
            //TODO@Jus
            throw new Exception("Method is not implemented, sorry ;-).");
        }

        private void AddContactUI_OnKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                Btn_AddContact_Click(sender, e);
            }
        }
    }
}
