using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
namespace FormLab1
{
    public class ClientForm : Form
    {
        private ClientManager clientManager;
        private TextBox nameTextBox;
        private TextBox emailTextBox;
        private TextBox phoneTextBox;
        private TextBox addressTextBox;
        private Button addClientButton;
        private Button removeClientButton;
        private TextBox searchTextBox;
        private Button searchButton;
        private ListBox clientsListBox;




        public ClientForm()
        {
            this.Text = "Управление клиентами";
            this.Width = 500;
            this.Height = 400;
            nameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Width = 150,
                Text = "Имя"
            };
            emailTextBox = new TextBox
            {
                Location = new System.Drawing.Point(170, 10),
                Width = 150,
                Text = "Email"
            };
            phoneTextBox = new TextBox
            {
                Location = new System.Drawing.Point(330, 10),
                Width = 100,
                Text = "Телефон"
            };
            addressTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 40),
                Width = 450,
                Multiline = true,
                Text = "Адрес"
            };
            addClientButton = new Button
            {
                Location = new System.Drawing.Point(10, 80),
                Text = "Добавить",
                Width = 100
            };
            addClientButton.Click += AddClientButton_Click;
            removeClientButton = new Button
            {
                Location = new System.Drawing.Point(120, 80),
                Text = "Удалить",
                Width = 100
            };
            removeClientButton.Click += RemoveClientButton_Click;
            searchTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 110),
                Width = 200,
                Text = "Поиск"
            };
            searchButton = new Button
            {
                Location = new System.Drawing.Point(220, 110),
                Text = "Искать",
                Width = 80
            };
            searchButton.Click += SearchButton_Click;
            clientsListBox = new ListBox
            {
                Location = new System.Drawing.Point(10, 140),
                Width = 450,
                Height = 200
            };
            this.Controls.Add(nameTextBox);
            this.Controls.Add(emailTextBox);
            this.Controls.Add(phoneTextBox);
            this.Controls.Add(addressTextBox);
            this.Controls.Add(addClientButton);
            this.Controls.Add(removeClientButton);
            this.Controls.Add(searchTextBox);
            this.Controls.Add(searchButton);
            this.Controls.Add(clientsListBox);
            clientManager = new ClientManager();
            UpdateClientsList();
        }
        private void UpdateClientsList()
        {
            clientsListBox.Items.Clear();
            foreach (var client in clientManager.Clients)
            {
                clientsListBox.Items.Add($"{client.Name} - {client.Email} ({client.Phone})");
            }
        }
        private void AddClientButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(emailTextBox.Text)
            || string.IsNullOrEmpty(phoneTextBox.Text) || string.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            Client newClient = new Client(nameTextBox.Text, emailTextBox.Text,
            phoneTextBox.Text, addressTextBox.Text);
            try
            {
                clientManager.AddClient(newClient);
                nameTextBox.Clear();
                emailTextBox.Clear();
                phoneTextBox.Clear();
                addressTextBox.Clear();
                UpdateClientsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RemoveClientButton_Click(object sender, EventArgs e)
        {
            if (clientsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите клиента для удаления!");
                return;
            }
            string selectedItem = clientsListBox.SelectedItem.ToString();
            string[] parts = selectedItem.Split(new[] { '-' }, StringSplitOptions.None);
            if (parts.Length >= 2)
            {
                string name = parts[0].Trim();
                string email = parts[1].Trim();
                var clientToRemove = clientManager.Clients.Find(c => c.Name == name && c.Email
                == email);
                if (clientToRemove != null)
                {
                    try
                    {
                        clientManager.RemoveClient(clientToRemove);
                        UpdateClientsList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                UpdateClientsList();
                return;
            }
            var searchResults = clientManager.SearchClients(searchTextBox.Text);
            clientsListBox.Items.Clear();
            foreach (var client in searchResults)
            {
                clientsListBox.Items.Add($"{client.Name} - {client.Email} ({client.Phone})");
            }
        }

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private TextBox textBox5;
        private Button button3;
        private ListBox listBox1;
    }

}
