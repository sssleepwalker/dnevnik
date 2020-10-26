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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace ddnevnik1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tabl();
        }

        public void Tabl() // Функция вывода информации из БД в приложение
        {
            FIO.Clear(); Group.Clear(); Datar.Clear();
            IDS.Clear(); DataS.Clear(); ZadS.Clear(); OtsenkaS.Clear();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            string ssql1 = $"SELECT TOP (1000) [name],[groupp],[data] FROM [dnevnik].[dbo].[student]"; //Зaпрос таблицы Student

            SqlCommand command = new SqlCommand(ssql1, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выполнение запроса вывод информации

            while (reader.Read()) //В цикле вывести всю информацию из таблици
            {
                FIO.Text += (reader[0].ToString() + "\n");
                Group.Text += (reader[1].ToString() + "\n");
                Datar.Text += (reader[2].ToString() + "\n");

            }
            reader.Close(); // Закрываем "чтение" первой таблицы

            string sql2 = $"SELECT TOP (1000) [id],[data],[zadanie],[otsenka] FROM [dnevnik].[dbo].[dnevnik]"; // Запрос таблицы Dnevnik
            SqlCommand command2 = new SqlCommand(sql2, conn);
            SqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                IDS.Text += (reader2[0].ToString() + "\n");
                DataS.Text += (reader2[1].ToString() + "\n");
                ZadS.Text += (reader2[2].ToString() + "\n");
                OtsenkaS.Text += (reader2[3].ToString() + "\n");
            }

            reader2.Close(); // Закрываем чтение второй таблицы
        }

        private void IFIOB_Click(object sender, RoutedEventArgs e) // Изменение ФИО
        {
            string fio1 = IFIO.Text;
            string fio2 = IFIO2.Text;

            string ssql = $"UPDATE Student SET name = '{fio2}' WHERE name = '{fio1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            IFIO.Clear(); IFIO2.Clear();
        }

        private void IGroupB_Click(object sender, RoutedEventArgs e) // Изменение группы
        {
            string group1 = IGroup.Text;
            string group2 = IGroup2.Text;

            string ssql = $"UPDATE Student SET groupp = '{group2}' WHERE groupp = '{group1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            IGroup.Clear(); IGroup2.Clear();
        }

        private void IDatarB_Click(object sender, RoutedEventArgs e) // Изменение даты рождения
        {
            string datar1 = IDatar.Text;
            string datar2 = IDatar2.Text;

            string ssql = $"UPDATE Student SET data = '{datar2}' WHERE data = '{datar1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            IDatar.Clear(); IDatar2.Clear();
        }

        private void IIDSB_Click(object sender, RoutedEventArgs e) // Изменение айди во второй таблице
        {
            string id1 = IIDS.Text;
            string id2 = IIDS2.Text;

            string ssql = $"UPDATE Dnevnik SET id = '{id2}' WHERE id = '{id1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            IIDS.Clear(); IIDS2.Clear();
        }

        private void IDataSB_Click(object sender, RoutedEventArgs e) // Изменение даты оценки
        {
            string data1 = IDataS.Text;
            string data2 = IDataS2.Text;

            string ssql = $"UPDATE Dnevnik SET data = '{data2}' WHERE data = '{data1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            IDataS.Clear(); IDataS2.Clear();
        }

        private void IZadSB_Click(object sender, RoutedEventArgs e) // Изменение задания/темы за которую получена оценку
        {
            string zadanie1 = IZadS.Text;
            string zadanie2 = IZadS2.Text;

            string ssql = $"UPDATE Dnevnik SET zadanie = '{zadanie2}' WHERE zadanie = '{zadanie1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            IZadS.Clear(); IZadS2.Clear();
        }

        private void IOTSENKASB_Click(object sender, RoutedEventArgs e) // Изменение оценки
        {
            string otsenka1 = IOtsenkaS.Text;
            string otsenka2 = IOtsenkaS2.Text;

            string ssql = $"UPDATE Dnevnik SET otsenka = '{otsenka2}' WHERE otsenka = '{otsenka1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            IOtsenkaS.Clear(); IOtsenkaS2.Clear();
        }

        private void DELETEFIOB_Click(object sender, RoutedEventArgs e)
        {
            string fio = DELETEfio.Text;

            string ssql = $"DELETE  FROM Student  WHERE name = '{fio}'"; //ЗАпрос удалить поле 

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nУдалено объектов: " + number);

            DELETEfio.Clear();
        }

        private void DELETEIDB_Click(object sender, RoutedEventArgs e)
        {
            string id2 = DELETEid.Text;

            string ssql = $"DELETE  FROM Dnevnik  WHERE id = '{id2}'"; //ЗАпрос удалить поле 

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nУдалено объектов: " + number);

            DELETEid.Clear();
        }
        private void DOBAVITSB_Click(object sender, RoutedEventArgs e)
        {
            string fio = DFIO.Text;
            string group = DGroup.Text;
            string datar = DDatar.Text;

            var ssql = $"INSERT INTO Student (name,groupp,data) VALUES ('{fio}', '{group}','{datar}')"; //ЗАпрос вставить данные в таблицу 

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nВставлено объектов: " + number);

            DFIO.Clear(); DGroup.Clear(); DDatar.Clear();
        }

        private void DOBAVITOTSB1_Click(object sender, RoutedEventArgs e)
        {
            int id2 = Convert.ToInt32(DIDS.Text);
            string data = DDataS.Text;
            string zadanie = DZadS.Text;
            string otsenka = DOtsenkaS.Text;

            string ssql = $"INSERT INTO Dnevnik (id,data,zadanie,otsenka) VALUES ('{id2}', '{data}','{zadanie}', '{otsenka}')"; //ЗАпрос вставить данные в таблицу

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nВставлено объектов: " + number);

            DIDS.Clear(); DDataS.Clear(); DZadS.Clear(); DOtsenkaS.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FIO.Clear(); Group.Clear(); Datar.Clear();
            IDS.Clear(); DataS.Clear(); ZadS.Clear(); OtsenkaS.Clear();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            string ssql1 = $"SELECT TOP (1000) [name],[groupp],[data] FROM [dnevnik].[dbo].[student]"; //Зaпрос таблицы Student

            SqlCommand command = new SqlCommand(ssql1, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выполнение запроса вывод информации

            while (reader.Read()) //В цикле вывести всю информацию из таблици
            {

                FIO.Text += (reader[0].ToString() + "\n");
                Group.Text += (reader[1].ToString() + "\n");
                Datar.Text += (reader[2].ToString() + "\n");

            }
            reader.Close(); // Закрываем "чтение" первой таблицы

            string sql2 = $"SELECT TOP (1000) [id],[data],[zadanie],[otsenka]FROM[dnevnik].[dbo].[dnevnik]"; // Запрос таблицы Dnevnik
            SqlCommand command2 = new SqlCommand(sql2, conn);
            SqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                IDS.Text += (reader2[0].ToString() + "\n");
                DataS.Text += (reader2[1].ToString() + "\n");
                ZadS.Text += (reader2[2].ToString() + "\n");
                OtsenkaS.Text += (reader2[3].ToString() + "\n");
            }

            reader2.Close(); // Закрываем чтение второй таблицы
        }
    }
}
   