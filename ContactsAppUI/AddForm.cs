using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsApp
{
   
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }


public Contact _сontact;

            

public Contact Contact
        {
            get
            {
                return _сontact;
            }
            set
            {
                _сontact = value;
                if (_сontact !=null )
                {
                    
                    SurnameTextBox.Text = _сontact.Surname;
                    NameTextBox.Text = _сontact.Name;
                    MailTextBox.Text = _сontact.Mail;
                    IDVKTextBox11.Text = _сontact.IDVK;
                    BdateDateTime.Value = _сontact.Bdate;
                    PhoneNumberTextBox.Text = _сontact.Number.Number.ToString();
                }
                else
                {
                    
                    SurnameTextBox.Text = "";
                    NameTextBox.Text = "";
                    MailTextBox.Text = "";
                    IDVKTextBox11.Text = "";
                    BdateDateTime.Value =DateTime.Today;
                    PhoneNumberTextBox.Text = "";
                }



            }
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            _сontact = new Contact();
           
              
            try
            {
                _сontact.Number.Number = Convert.ToInt64(PhoneNumberTextBox.Text);

  _сontact.Surname = SurnameTextBox.Text;

            _сontact.Mail = MailTextBox.Text;
            _сontact.IDVK = IDVKTextBox11.Text;
            _сontact.Bdate = BdateDateTime.Value;
                _сontact.Name = NameTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
 
        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PhoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number)&& e.KeyChar!=(char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
