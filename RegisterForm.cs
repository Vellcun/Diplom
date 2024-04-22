using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace StudyAppZK
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            LoginUser.Text = "Введите логин";
            PasswordUser.Text = "Введите пароль";
            passwordUser1.Text = "Повторите пароль";
            LoginUser.Multiline = false;
            PasswordUser.Multiline = false;
            passwordUser1.Multiline = false;
        }

        private void Reg_Click(object sender, EventArgs e)
        {
            String _LoginUserDB = LoginUser.Text;
            String _PasswordUserDB = PasswordUser.Text;
            String _PasswordUser1DB = passwordUser1.Text;

            if (_LoginUserDB == "Введите логин")
            {
                Warning.Text = "Введите логин!";
                return;
            }
            if (_PasswordUserDB == "Введите пароль")
            {
                Warning.Text = "Введите пароль!";
                return;
            }

            DB db = new DB();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE login = @uL", db.getConnection());
            cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = _LoginUserDB;

            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                Warning.Text = "Данный логин уже существует!";
                return;
            }

            if (_PasswordUserDB != _PasswordUser1DB)
            {
                Warning.Text = "Пароли не совпадают!";
                return;
            }

            cmd = new MySqlCommand("SELECT * FROM `users`", db.getConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            cmd = new MySqlCommand("INSERT INTO `users` (`ID_User`, `Login`, `Password`, `Root`) VALUES (@id, @uL, @uP, '0')", db.getConnection());
            cmd.Parameters.Add("id", MySqlDbType.Int64).Value = dataTable.Rows.Count + 1;
            cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = _LoginUserDB;
            cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = _PasswordUserDB;

            db.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                
            }
            else
            {
                Warning.Text = "Аккаунт не зарегестрирован!";
                return;
            }

            db.closeConnection();

            this.Hide();
            LoginForm _form = new LoginForm();
            _form.Show();
        }

        private void LoginUser_Enter(object sender, EventArgs e)
        {
            if (LoginUser.Text == "Введите логин")
            {
                LoginUser.Text = "";
            }
        }

        private void PasswordUser_Enter(object sender, EventArgs e)
        {
            if (PasswordUser.Text == "Введите пароль")
            {
                PasswordUser.Text = "";
                PasswordUser.UseSystemPasswordChar = true;
            }
            
        }

        private void passwordUser1_Enter(object sender, EventArgs e)
        {
            if (passwordUser1.Text == "Повторите пароль")
            {
                passwordUser1.Text = "";
                passwordUser1.UseSystemPasswordChar = true;
            }
            
        }

        private void LoginUser_Leave(object sender, EventArgs e)
        {
            if (LoginUser.Text == "")
            {
                LoginUser.Text = "Введите логин";
            }
        }

        private void PasswordUser_Leave(object sender, EventArgs e)
        {
            if (PasswordUser.Text == "")
            {
                PasswordUser.Text = "Введите пароль";
                PasswordUser.UseSystemPasswordChar = false;
            }
            
        }

        private void passwordUser1_Leave(object sender, EventArgs e)
        {
            if (passwordUser1.Text == "")
            {
                passwordUser1.Text = "Повторите пароль";
                passwordUser1.UseSystemPasswordChar = false;
            }
            
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
