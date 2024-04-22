using System;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Notice;
using Org.BouncyCastle.Tls;

namespace StudyAppZK
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            menu.Height = 0;
            menu.Width = 0;
            menu.ItemSize = new Size(menu.Size.Width / menu.TabPages.Count - 1, menu.ItemSize.Height);
            panel2.Dock = DockStyle.Fill;
            Date.ReadOnly = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            profileImage.Image = Image.FromFile("C:\\Users\\elale\\Desktop\\курсовая\\StudyAppZK\\StudyAppZK\\profile.jpg");
            profileImage.SizeMode = PictureBoxSizeMode.StretchImage;

            memberschat.Alignment = TabAlignment.Left;

            root.Height = (int)(0.2 * panel18.Height);
            birthday.Height = (int)(0.2 * panel18.Height);
            email.Height = (int)(0.2 * panel18.Height);
            phoneNumber.Height = (int)(0.2 * panel18.Height);
            group.Height = (int)(0.2 * panel18.Height);

            textRoot.BorderStyle = BorderStyle.None;
            textGroup.BorderStyle = BorderStyle.None;
            textEmail.BorderStyle = BorderStyle.None;
            textPhoneNumber.BorderStyle = BorderStyle.None;
            textBirthday.BorderStyle = BorderStyle.None;
            FIO.BorderStyle = BorderStyle.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime _selectedDate = e.Start;
            string[] column_name = {"Номер занятия", "Начало", "Конец", "Название предмета", "Кабинет", "Место проведения"};
            tableLayoutPanel1.Controls.Clear();

            Date.Clear();
            Date.Text = _selectedDate.ToString("dd MMMM yyyy");

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("SELECT Time_start, Time_end, ID_Subject, ID_Room, Location FROM `timetable` WHERE Date = @date", db.getConnection());
            cmd.Parameters.Add("@date", MySqlDbType.Date).Value = _selectedDate.Date;

            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            for (int column = 0; column <= 5; column++)
            {
                Label headerLabel = new Label
                {
                    Text = column_name[column],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                tableLayoutPanel1.Controls.Add(headerLabel, column, 0);
            }

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                for (int column = -1; column < dataTable.Columns.Count; column++)
                {
                    if (column == -1)
                    {
                        Label dataLabel = new Label
                        {
                            Text = $"Занятие №{row+1}",
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        tableLayoutPanel1.Controls.Add(dataLabel, column + 1, row + 1);
                    }
                    if (column != 2 & column != 3 & column != -1)
                    {
                        Label dataLabel = new Label
                        {
                            Text = dataTable.Rows[row][column].ToString(),
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        tableLayoutPanel1.Controls.Add(dataLabel, column + 1, row + 1);
                        
                    }
                    if (column == 2)
                    {
                         string value = getDataSubject(dataTable.Rows[row][column].ToString());
                         Label dataLabel = new Label
                         {
                             Text = value,
                             Dock = DockStyle.Fill,
                             TextAlign = ContentAlignment.MiddleCenter
                         };
                         tableLayoutPanel1.Controls.Add(dataLabel, column + 1, row + 1);

                    }
                        
                    if (column == 3)
                    {
                          string value = getDataRoom(dataTable.Rows[row][column].ToString());
                          Label dataLabel = new Label
                          {
                               Text = value,
                               Dock = DockStyle.Fill,
                               TextAlign = ContentAlignment.MiddleCenter
                          };
                          tableLayoutPanel1.Controls.Add(dataLabel, column + 1, row + 1);
                           
                    }
                }
            }
        }

        string getDataSubject(string id)
        {
            string value = "";

            DB db = new DB();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT Subject_name FROM `Subject` WHERE ID_Subject = @sId", db.getConnection());
            cmd.Parameters.Add("@sId", MySqlDbType.Int64).Value = id;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return "1111";
            }


            foreach (DataRow row in dataTable.Rows)
            {
                value = row["Subject_name"].ToString();
            }

            return value;
        }

        string getDataRoom(string id)
        {
            string value = "";

            DB db = new DB();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT Room_number FROM `Room` WHERE ID_Room = @sId", db.getConnection());
            cmd.Parameters.Add("@sId", MySqlDbType.Int64).Value = id;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return "22222";
            }


            foreach (DataRow row in dataTable.Rows)
            {
                value = row["Room_number"].ToString();
            }

            return value;
        }

        private void Begin_task_Click(object sender, EventArgs e)
        {

        }

        private void End_task_Click(object sender, EventArgs e)
        {

        }

        private void Add_group_Click(object sender, EventArgs e)
        {
            string _name_group = Name_group.Text;

            if (_name_group == null)
            {
                return;
            }

            DB db = new DB();


            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `students_group`", db.getConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            cmd = new MySqlCommand("INSERT INTO `students_group` (`ID_Group`, `Name_group`) VALUES (@id, @gN)", db.getConnection());
            cmd.Parameters.Add("@id", MySqlDbType.Int64).Value = dataTable.Rows.Count + 1;
            cmd.Parameters.Add("@gN", MySqlDbType.VarChar).Value = _name_group;

            try
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Группа не создана!";
                    return;
                }

                db.closeConnection();
            }
            catch
            {

            }
        }

        private void Add_room_Click(object sender, EventArgs e)
        {
            string _room_number = room_number.Text;
            string _floor = floor.Text;

            if (_room_number == null | _floor == null)
            {
                return;
            }

            DB db = new DB();


            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `room`", db.getConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            cmd = new MySqlCommand("INSERT INTO `room` (`ID_Room`, `Room_number`, `Floor`, `Status`) VALUES (@id, @rN, @rF,'0')", db.getConnection());
            cmd.Parameters.Add("@id", MySqlDbType.Int64).Value = dataTable.Rows.Count + 1;
            cmd.Parameters.Add("@rN", MySqlDbType.Int64).Value = _room_number;
            cmd.Parameters.Add("@rF", MySqlDbType.Int64).Value = _floor;


            try
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Кабинет не создан!";
                    return;
                }

                db.closeConnection();
            }
            catch
            {
                
            }
        }

        private void Add_subject_Click(object sender, EventArgs e)
        {
            string _subject_number = s_name.Text;
            string _subject_user = s_user.Text;

            if (_subject_number == null | _subject_user == null)
            {
                return;
            }

            DB db = new DB();


            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `subject`", db.getConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            cmd = new MySqlCommand("INSERT INTO `subject` (`ID_Subject`, `Subject_name`, `ID_User`) VALUES (@sId, @sN, @uId)", db.getConnection());
            cmd.Parameters.Add("@sId", MySqlDbType.Int64).Value = dataTable.Rows.Count + 1;
            cmd.Parameters.Add("@sN", MySqlDbType.VarChar).Value = _subject_number;
            cmd.Parameters.Add("@uId", MySqlDbType.Int64).Value = _subject_user;

            try 
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Предмет не создан!";
                    return;
                }

                db.closeConnection();
            }
            catch
            { 
                
            }
        }

        private void User_Group_Click(object sender, EventArgs e)
        {
            string _group = groups.Text;
            string _user = users.Text;

            if (_group == null | _user == null)
            {
                return;
            }

            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `users_student_group` (`ID_User`,`ID_Group`) VALUES (@uId, @gId)", db.getConnection());;
            cmd.Parameters.Add("@uId", MySqlDbType.Int64).Value = _user;
            cmd.Parameters.Add("@gId", MySqlDbType.Int64).Value = _group;


            try
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Синхронизация не успешна";
                    return;
                }

                db.closeConnection();
            }
            catch
            { 
            }
        }

        private void Create_lesson_Click(object sender, EventArgs e)
        {
            DateTime _date_lesson = dateTimePicker1.Value;
            string _id_group = ID_Group.Text;
            string _id_room = ID_Room.Text;
            string _id_subject = ID_Subject.Text;
            string _time_start = time_start.Text;
            string _time_end = time_end.Text;
            string _location = Location.Text;

            TimeSpan _time_start_;
            TimeSpan _time_end_;

            TimeSpan.TryParse(_time_start, out _time_start_);
            TimeSpan.TryParse(_time_end, out _time_end_);

            if (_id_group == null | _id_room == null | _id_subject == null | _time_start_ == null | _time_end_ == null | _location == null)
            {
                return;
            }

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `timetable`", db.getConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            cmd = new MySqlCommand("INSERT INTO `timetable` (`ID_Timetable`, `ID_Group`, `ID_Room`, `Date`, `Time_start`, `Time_end`, `Location`, `ID_Subject`, `Cancel`) VALUES (@tId, @gId, @rId, @date, @ts, @te, @l, @sId, '0')", db.getConnection()); ;
            cmd.Parameters.Add("@tId", MySqlDbType.Int64).Value = dataTable.Rows.Count + 1;
            cmd.Parameters.Add("@gId", MySqlDbType.Int64).Value = _id_group;
            cmd.Parameters.Add("@rId", MySqlDbType.Int64).Value = _id_room;
            cmd.Parameters.Add("@date", MySqlDbType.Date).Value = _date_lesson.Date;
            cmd.Parameters.Add("@ts", MySqlDbType.Time).Value = _time_start_;
            cmd.Parameters.Add("@te", MySqlDbType.Time).Value = _time_end_;
            cmd.Parameters.Add("@l", MySqlDbType.VarChar).Value = _location;
            cmd.Parameters.Add("@sId", MySqlDbType.Int64).Value = _id_subject;


            try
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Синхронизация не успешна";
                    return;
                }

                db.closeConnection();
            }
            catch (Exception ex)
            {
                //label52.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _id_timetable = ID_Lesson_1.Text;
            DateTime dateTime = dateTimePicker3.Value;
            string _time_start = time_start_1.Text;
            string _time_end = time_end_1.Text;
            string _location = location_1.Text;
            string _id_room = ID_Room_1.Text;

            TimeSpan _time_start_;
            TimeSpan _time_end_;

            TimeSpan.TryParse(_time_start, out _time_start_);
            TimeSpan.TryParse(_time_end, out _time_end_);

            if (_id_timetable == null | _time_start_ == null | _time_end_ == null | _location == null | _id_room == null)
            {
                return;
            }

            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("UPDATE `timetable` SET ID_Room = @rId, Date = @date, Time_start = @ts, Time_end = @te, Location = @l, Cancel = '1' WHERE ID_Timetable = @tId", db.getConnection());
            cmd.Parameters.Add("@tId", MySqlDbType.Int64).Value = _id_timetable;
            cmd.Parameters.Add("@date", MySqlDbType.Date).Value = dateTime.Date;
            cmd.Parameters.Add("@rId", MySqlDbType.Int64).Value = _id_room;
            cmd.Parameters.Add("@ts", MySqlDbType.Int64).Value = _time_start_;
            cmd.Parameters.Add("@te", MySqlDbType.Int64).Value = _time_end_;
            cmd.Parameters.Add("@l", MySqlDbType.Int64).Value = _location;

            try
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Синхронизация не успешна";
                    return;
                }

                db.closeConnection();
            }
            catch
            {
            }
        }

        private void Delete_lesson_Click(object sender, EventArgs e)
        {
            string _id_timetable = ID_lesson.Text;

            if (_id_timetable == null)
            {
                return;
            }

            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM `timetable` WHERE ID_Timetable = @tId", db.getConnection()); ;
            cmd.Parameters.Add("@tId", MySqlDbType.Int64).Value = _id_timetable;


            try
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Синхронизация не успешна";
                    return;
                }

                db.closeConnection();
            }
            catch
            {
            }
        }

        private void Lessons_option_Enter(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT ID_Group FROM `students_group`", db.getConnection());

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_Group.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                ID_Group.Items.Add(row["ID_Group"].ToString());
            }

            //------------------------------------------------

            cmd = new MySqlCommand("SELECT ID_Room FROM `room`", db.getConnection());

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_Room.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ID_Room"].ToString() != "")
                {
                    ID_Room.Items.Add(row["ID_Room"].ToString());
                    ID_Room_1.Items.Add(row["ID_Room"].ToString());
                }
            }

            //------------------------------------------------

            cmd = new MySqlCommand("SELECT ID_Subject FROM `subject`", db.getConnection());

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_Subject.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ID_Subject"].ToString() != "")
                {
                    ID_Subject.Items.Add(row["ID_Subject"].ToString());
                }
            }

            //------------------------------------------------

            cmd = new MySqlCommand("SELECT ID_Subject FROM `room`", db.getConnection());

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_Room.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                ID_Room.Items.Add(row["ID_Room"].ToString());
            }
        }

        private void TabPage7_Enter(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT ID_User FROM `users`", db.getConnection());

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            users.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ID_User"].ToString() != "")
                {
                    users.Items.Add(row["ID_User"].ToString());
                    s_user.Items.Add(row["ID_User"].ToString());
                }
            }

            //--------------------------------------------------------------------------------------------

            cmd = new MySqlCommand("SELECT ID_Group FROM `students_group`", db.getConnection());

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            groups.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ID_Group"].ToString() != "")
                {
                    groups.Items.Add(row["ID_Group"].ToString());
                }
            }
        }

        private void Find_lesson_Click(object sender, EventArgs e)
        {
            DateTime _date_lesson = dateTimePicker2.Value;

            DB db = new DB();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT ID_Timetable FROM `timetable` WHERE Date = @dt", db.getConnection());
            cmd.Parameters.Add("@dt", MySqlDbType.Date).Value = _date_lesson.Date;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_lesson.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                ID_lesson.Items.Add(row["ID_Timetable"].ToString());
            }
        }

        private void find_lesson_1_Click(object sender, EventArgs e)
        {
            DateTime _date_lesson = dateTimePicker2.Value;

            DB db = new DB();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT ID_Timetable FROM `timetable` WHERE Date = @dt", db.getConnection());
            cmd.Parameters.Add("@dt", MySqlDbType.Date).Value = _date_lesson.Date;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_Lesson_1.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                ID_Lesson_1.Items.Add(row["ID_Timetable"].ToString());
            }
        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT ID_Room FROM `room`", db.getConnection());

            

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_Room_2.Items.Clear();
            ID_Room_10.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ID_Room"].ToString() != "")
                {
                    ID_Room_2.Items.Add(row["ID_Room"].ToString());
                    ID_Room_10.Items.Add(row["ID_Room"].ToString());
                }
            }

            cmd = new MySqlCommand("SELECT ID_Furniture FROM `furniture_accounting`", db.getConnection());

            

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_Furniture_1.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ID_Furniture"].ToString() != "")
                {
                    ID_Furniture_1.Items.Add(row["ID_Furniture"].ToString());
                }
            }
        }

        private void Create_furniture_Click(object sender, EventArgs e)
        {
            string _id_furniture = ID_Furniture.Text;
            string _furniture_name = Furniture_name.Text;
            string _id_room = ID_Room_2.Text;


            if (_id_furniture == null | _id_room == null | _furniture_name == null)
            {
                return;
            }

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();


            MySqlCommand cmd = new MySqlCommand("INSERT INTO `furniture_accounting` (`ID_Furniture`, `Furniture_name`, `ID_Room`, `Status`) VALUES (@fId, @fN, @rId, '0')", db.getConnection()); ;
            cmd.Parameters.Add("@fId", MySqlDbType.Int64).Value = _id_furniture;
            cmd.Parameters.Add("@fN", MySqlDbType.VarChar).Value = _furniture_name;
            cmd.Parameters.Add("@rId", MySqlDbType.Int64).Value = _id_room;


            try
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Синхронизация не успешна";
                    return;
                }

                db.closeConnection();
            }
            catch (Exception ex)
            {
                //label52.Text = ex.Message;
            }
        }

        private void edit_status_furniture_Click(object sender, EventArgs e)
        {
            string _id_furniture = ID_Furniture_1.Text;
            string _status = Furniture_status.Text;


            if (_id_furniture == null | _status == null)
            {
                return;
            }

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();


            MySqlCommand cmd = new MySqlCommand("UPDATE `furniture_accounting` SET Status = @s WHERE ID_Furniture = @fId;", db.getConnection()); ;
            cmd.Parameters.Add("@fId", MySqlDbType.Int64).Value = _id_furniture;
            cmd.Parameters.Add("@s", MySqlDbType.VarChar).Value = _status;


            try
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Синхронизация не успешна";
                    return;
                }

                db.closeConnection();
            }
            catch (Exception ex)
            {
                //label52.Text = ex.Message;
            }
        }

        private void Update_furniture_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("SELECT ID_Furniture FROM `furniture_accounting` WHERE Status != '0'", db.getConnection());

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_Furniture_11.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ID_Furniture"].ToString() != "")
                {
                    ID_Furniture_11.Items.Add(row["ID_Furniture"].ToString());
                }
            }
        }

        private void Update_room_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("SELECT ID_Room FROM `room` WHERE Status != '0'", db.getConnection());

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            ID_Room_11.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ID_Room"].ToString() != "")
                {
                    ID_Room_11.Items.Add(row["ID_Room"].ToString());
                }
            }
        }

        private void Edit_Room_Click(object sender, EventArgs e)
        {
            string _id_room = ID_Room_10.Text;
            string _status = Room_status.Text;


            if (_id_room == null | _status == null)
            {
                return;
            }

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();


            MySqlCommand cmd = new MySqlCommand("UPDATE `room` SET Status = @s WHERE ID_Room = @rId;", db.getConnection()); ;
            cmd.Parameters.Add("@rId", MySqlDbType.Int64).Value = _id_room;
            cmd.Parameters.Add("@s", MySqlDbType.VarChar).Value = _status;


            try
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    Warning_group.Text = "Синхронизация не успешна";
                    return;
                }

                db.closeConnection();
            }
            catch (Exception ex)
            {
                //label52.Text = ex.Message;
            }
        }

        private void ID_Furniture_11_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _id_furniture = ID_Furniture_11.Text;

            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("SELECT Status FROM `furniture_accounting` WHERE ID_Furniture = @fId", db.getConnection());
            cmd.Parameters.Add("@fId", MySqlDbType.Int64).Value = _id_furniture;

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            Furniture_status_1.Text = "";

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Status"].ToString() != "")
                {
                    Furniture_status_1.Text = row["Status"].ToString();
                }
            }
        }

        private void ID_Room_11_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _id_room = ID_Room_11.Text;

            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("SELECT Status FROM `room` WHERE ID_Room = @rId", db.getConnection());
            cmd.Parameters.Add("@rId", MySqlDbType.Int64).Value = _id_room;

            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return;
            }

            Room_status_1.Text = "";

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Status"].ToString() != "")
                {
                    Room_status_1.Text = row["Status"].ToString();
                }
            }
        }
    }
}
