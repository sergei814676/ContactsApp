using System;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class MainForm : Form
    {

        private Project Contacts = new Project();
        private Project BdataContacts = new Project();

        public MainForm()
        {
            InitializeComponent();
            Contacts = Projectmanager.Deserialization();
            Contacts.СontactsList = Contacts.SortingContacts();
            KeyDown += new KeyEventHandler(PressDeleteButton);
            label1.Text = "Дни рождения: ";
            foreach (var contact in Contacts.СontactsList)
            {
                ContactslistBox.Items.Add(contact.Surname);
            }

            BdataContacts.СontactsList = Contacts.BdataContacts();
            if (BdataContacts.СontactsList.Count != 0)
            {

                foreach (var contact in BdataContacts.СontactsList)
                {
                    label1.Text = label1.Text + contact.Surname;
                }
            }
            else
            {
                panel1.Visible = false;
            }

        }



        private void PressDeleteButton(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            { DeleteContact(); }
        }

        private void EditButton_Click(object sender, EventArgs e) ///редактирование контакта
        {
            EditContact();
        }


        private void DeleteButton_Click(object sender, EventArgs e) ///удаление
        {

            DeleteContact();

        }


        private void AddButton_Click(object sender, EventArgs e) ///добавление нового контакта
        {
            AddContact();

        }


        ///<summary>
        ///метод для редактирование контакта 
        ///</summary>
        private void EditContact() ///метод для редактирование контакта
        {
            var sIndex = ContactslistBox.SelectedIndex;
            var inner = new ContactForm();
            if (sIndex == -1)
            {
                return;
            }
            else
            {
                inner.Contact = Contacts.SortingContacts(FindTextBox2.Text)[sIndex];
                var result = inner.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var upCont = inner.Contact;

                    Contacts.СontactsList.RemoveAt(sIndex);
                    Contacts.СontactsList.Add(upCont);
                    Contacts.СontactsList = Contacts.SortingContacts();
                    LookContacts();
                    Projectmanager.Serialization(Contacts);
                }
            }
        }


        ///<summary>
        ///метод для создания нового контакта 
        ///</summary>
        private void AddContact()///метод для создание нового контакта
        {
            var sIndex = ContactslistBox.SelectedIndex;// вытащили ндекс выбранного элемента
            var addater = new ContactForm();//создали переменную с типом данных окна, котоорый откроется при нажатии
            addater.Contact = null; // передали класс типа Сontact, пустой(так как новый контакт)
            var result = addater.ShowDialog(this);//вызвали это окно
            if (result == DialogResult.OK)// если нажато ок в окне, то сработает это условие
            {
                var upCont = addater.Contact; //создали новый класс, с одним кантактом, и записали в него то что заполнили в окне


                Contacts.СontactsList.Add(upCont);//добавили в массив контактов, наш новвосозданный контакт
                Contacts.СontactsList = Contacts.SortingContacts();
                LookContacts();
                Projectmanager.Serialization(Contacts);//сохранили в файл новый массив, с новым контактом
            }

        }


        ///<summary>
        ///метод для удаления контакта 
        ///</summary>
        private void DeleteContact() ///метод для удаление контакта
        {
            if (MessageBox.Show(
                    "Do you really want to remove this contacts: " +
                    Contacts.SortingContacts(FindTextBox2.Text)[ContactslistBox.SelectedIndex].Surname,
                    "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var selectedIndex = ContactslistBox.SelectedIndex; // вытащили ндекс выбранного элемента
                if (FindTextBox2.Text == "")
                {
                    Contacts.СontactsList.RemoveAt(selectedIndex);
                }
                else
                {
                   Contacts.СontactsList.RemoveAt(Contacts.СontactsList.IndexOf(Contacts.SortingContacts(FindTextBox2.Text)[ContactslistBox.SelectedIndex]));
               
                }
                     
                     // Contacts.СontactsList.RemoveAt(selectedIndex);
                  Projectmanager.Serialization(Contacts);
                LookContacts();
            }
        }


        private void AboutToolStripMenu(object sender, EventArgs e) //вывод окна информации
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
        }


        private void AddContactToolStripMenu(object sender, EventArgs e) //создание контакта, через верхнее еню
        {
            AddContact();
        }


        private void EditContactToolStripMenu(object sender, EventArgs e)// редактирование контакта, через верхнее меню
        {
            EditContact();
        }


        private void RemoveContactToolStripMenu(object sender, EventArgs e)//удаление контакта, через верхнее меню
        {
            DeleteContact();
        }


        private void listBoxContacts(object sender, EventArgs e)
        {

            if (ContactslistBox.SelectedIndex != -1)
            {
                if (FindTextBox2.Text == "")
                {
                    SurnameTextBox.Text = Contacts.СontactsList[ContactslistBox.SelectedIndex].Surname;
                    NameTextBox.Text = Contacts.СontactsList[ContactslistBox.SelectedIndex].Name;
                    BdateDateTime.Value = Contacts.СontactsList[ContactslistBox.SelectedIndex].Bdate;
                    NumberTextBox.Text = Contacts.СontactsList[ContactslistBox.SelectedIndex].Number.Number.ToString();
                    MailTextBox.Text = Contacts.СontactsList[ContactslistBox.SelectedIndex].Mail;
                    IDVKextBox.Text = Contacts.СontactsList[ContactslistBox.SelectedIndex].IDVK;
                }

                else
                {
                    SurnameTextBox.Text = Contacts.SortingContacts(FindTextBox2.Text)[ContactslistBox.SelectedIndex]
                        .Surname;
                    NameTextBox.Text = Contacts.SortingContacts(FindTextBox2.Text)[ContactslistBox.SelectedIndex].Name;
                    BdateDateTime.Value =
                        Contacts.SortingContacts(FindTextBox2.Text)[ContactslistBox.SelectedIndex].Bdate;
                    NumberTextBox.Text = Contacts.SortingContacts(FindTextBox2.Text)[ContactslistBox.SelectedIndex]
                        .Number.Number.ToString();
                    MailTextBox.Text = Contacts.SortingContacts(FindTextBox2.Text)[ContactslistBox.SelectedIndex].Mail;
                    IDVKextBox.Text = Contacts.SortingContacts(FindTextBox2.Text)[ContactslistBox.SelectedIndex].IDVK;
                }
            }
        }


        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void LookContacts()
        {

            if (FindTextBox2.Text == "")
            {
                ContactslistBox.Items.Clear();
                foreach (var contact in Contacts.СontactsList)
                {

                    ContactslistBox.Items.Add(contact.Surname);
                }
            }
            else
            {
                ContactslistBox.Items.Clear();
                foreach (var contact in Contacts.SortingContacts(FindTextBox2.Text))
                {
                    ContactslistBox.Items.Add(contact.Surname);
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            LookContacts();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}




