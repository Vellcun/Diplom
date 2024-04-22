using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace StudyAppZK
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            PasswordUser.Multiline = false;
            LoginUser.Multiline = false;
            PasswordUser.UseSystemPasswordChar = true;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            String LoginUserDB = LoginUser.Text;
            String PasswordUserDB = PasswordUser.Text;

            DB db = new DB();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            if (LoginUserDB == "" | PasswordUserDB == "")
            {
                Warning.Text = "Введите логин или пароль!";
                return;
            }

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE login = @uL AND password = @uP", db.getConnection());
            cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginUserDB;
            cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = PasswordUserDB;

            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count == 0) 
            {
                Warning.Text = "Неверный логин или пароль!";
                return;
            }

            this.Hide();
            MainMenu form = new MainMenu();
            form.Show();
        }

        private void Reg_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
