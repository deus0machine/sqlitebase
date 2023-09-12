using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace sqlite
{
    public partial class Form1 : Form
    {
        private sqliteclass mydb = null; //таблица базы данных
        private string sCurDir = string.Empty;
        private string sPath = string.Empty;//путь и имя базы данных
        private string sSql = string.Empty; //запрос

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sPath = Path.Combine(Application.StartupPath, "mybd.db");
            Text = sPath; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mydb = new sqliteclass();
            sSql = @"CREATE TABLE if not exists [hotels]([id] INTEGER PRIMARY KEY AUTOINCREMENT,[name] TEXT NOT NULL,[owner] TEXT NOT NULL,[rating] INTEGER NOT NULL,[adressh] TEXT NOT NULL);";
            //Пыьаемся создать таблицу
            mydb.iExecuteNonQuery(sPath, sSql, 0);
            sSql = @"insert into hotels (name,owner,rating,adressh) values('Белый орёл','Александр Сергеевич Пушкин',7,'ул. Ленина, д.2');";
            //Проверка работы
            if (mydb.iExecuteNonQuery(sPath, sSql, 1) == 0)
            {
                Text = "Ошибка проверки таблицы на запись, таблица или не создана или не прошла запись тестовой строки!";
                mydb = null;
                return;
            }
            sSql = "select * from hotels";
            DataRow[] datarows = mydb.drExecute(sPath, sSql);
            if (datarows == null)
            {
                Text = "Ошибка проверки таблицы на чтение!";
                mydb = null;
                return;
            }
            Text = "";
            foreach (DataRow dr in datarows)
            {
                Text += dr["id"].ToString().Trim() + dr["name"].ToString().Trim() + dr["owner"].ToString().Trim() + dr["rating"].ToString().Trim() + dr["adressh"].ToString().Trim() + " ";
            }

            sSql = "delete from hotels";
            if (mydb.iExecuteNonQuery(sPath, sSql, 1) == 0)
            {
                Text = "Ошибка проверки таблицы на удаление записи!";
                mydb = null;
                return;
            }

            Text = "Таблица создана!";
            mydb = null;
            return;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            mydb = new sqliteclass();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            string name = f2.name;
            string owner = f2.owner;
            int rating = f2.rating;
            string adressh = f2.adress;
            sSql = $@"insert into hotels (name,owner,rating,adressh) values('{name}','{owner}',{rating},{adressh});";
            //Проверка работы
            try
            {
                if (mydb.iExecuteNonQuery(sPath, sSql, 1) == 0)
                {
                    Text = "Ошибка записи!";
                }
                mydb = null;
                Text = "Запись 1 добавлена!";
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Ошибка! Форма заполнена некорректно");
            }
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mydb = new sqliteclass();
            //Ошибка в дате намеренная
            sSql = @"insert into hotels (FIO,bdate,gretinyear) values('Толстой Лев Николаевич','1928-08-28',0);";
            //Проверка работы
            if (mydb.iExecuteNonQuery(sPath, sSql, 1) == 0)
            {
                Text = "Ошибка записи!";
            }
            mydb = null;
            Text = "Запись 2 добавлена!";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            mydb = new sqliteclass();
            sSql = "select * from  hotels";
            DataRow[] datarows = mydb.drExecute(sPath, sSql);
            
            if (datarows == null)
            {
                Text = "Ошибка чтения!";
                mydb = null;
                return;
            }
            Text = "";

            dataGridView1.Rows.Clear();

            foreach (DataRow dr in datarows)
            {
                
                dataGridView1.Rows.Add(dr["id"], dr["FIO"]);
            }
                foreach (DataRow dr in datarows)
            {
                
                Text += dr["id"].ToString().Trim() + "  " + dr["FIO"].ToString().Trim() + "  " + dr["bdate"].ToString().Trim() + " ";
                textBox1.Text= dr["id"].ToString().Trim() + "  " + dr["FIO"].ToString().Trim() + "  " + dr["bdate"].ToString().Trim() + " ";
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mydb = new sqliteclass();
            sSql = "delete from hotels";
            if (mydb.iExecuteNonQuery(sPath, sSql, 1) == 0)
            {
                Text = "Ошибка удаления записи!";
                mydb = null;
                return;
            }
            mydb = null;
            Text = "Записи удалены из БД!";
            return;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mydb = new sqliteclass();
            sSql = @"Update birthday set bdate='1828-08-28' where FIO like('%Толстой%');";
            //Проверка работы
            if (mydb.iExecuteNonQuery(sPath, sSql, 1) == 0)
            {
                Text = "Ошибка обновления записи!";
                mydb = null;
                return;
            }
            mydb = null;
            Text = "Запись 2 исправлена!";
        }
      
    }
}
