﻿using System;
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
    //TODO: переименовать в ContactForm!
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }


public Contact Cont;

            

public Contact Contact
        {
            get
            {
                return Cont;
            }
            set
            {
                Cont = value;
                if (Cont !=null )
                {
                    
                    SurnameTextBox.Text = Cont.Surname;
                    NameTextBox.Text = Cont.Name;
                    MailTextBox.Text = Cont.Mail;
                    IDVKTextBox11.Text = Cont.IDVK;
                    BdateDateTime.Value = Cont.Bdate;
                    PhoneNumberTextBox.Text = Cont.Number.Number.ToString();
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
            Cont = new Contact();
           
                Cont.Surname = SurnameTextBox.Text;
            try
            {
                Cont.Number.Number = Convert.ToInt64(PhoneNumberTextBox.Text);



            Cont.Mail = MailTextBox.Text;
            Cont.IDVK = IDVKTextBox11.Text;
            Cont.Bdate = BdateDateTime.Value;
                Cont.Name = NameTextBox.Text;
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
