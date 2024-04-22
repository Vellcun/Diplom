using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAppZK
{
    internal class User
    {

        public string Name;
        public string Surname;
        public DateTime Birthday;
        public int Root;
        public string PhoneNumber = "не указано";
        public string Email = "не указано";
        public byte Image;

        public void GetInfo(int id)
        {
            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("SELECT root, name, surname, birthday, phone_number, email, image FROM `users` WHERE id = @id", db.getConnection());
            cmd.Parameters.Add("@id", MySqlDbType.Int64).Value = id;

            db.openConnection();

            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Root = Convert.ToInt16(row["root"]);
                Name = row["name"].ToString();
                Surname = row["surname"].ToString();
                Birthday = Convert.ToDateTime(row["birthday"]);
                PhoneNumber = row["phone_number"].ToString();
                Email = row["email"].ToString();
                Image = Convert.ToByte(row["image"].ToString());
            }

            db.closeConnection();
        }
    }
}
