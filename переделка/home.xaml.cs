using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;

namespace переделка
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : Window
    {
        public string gay = "";
        public home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gay = Box.Text;
            switch (gay)
            {
                case "Готовые_решения":
                    {
                        try
                        {
                            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HJU270S\M1;Initial Catalog=OOO_STK_SAMARA;Integrated Security=True;TrustServerCertificate=True");
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            string Get_Data = "SELECT * FROM dbo.Готовые_решения";
                            SqlCommand cmd = new SqlCommand(Get_Data, conn);
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable("Готовые_решения");
                            sda.Fill(dt);
                            dataGrid.ItemsSource = dt.DefaultView;
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show("Database Error: " + ex.Message);
                        }

                    }
                    break;
                case "Проекты":
                    {
                        try
                        {
                            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HJU270S\M1;Initial Catalog=OOO_STK_SAMARA;Integrated Security=True;TrustServerCertificate=True");
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            string Get_Data = "SELECT * FROM dbo.проекты";
                            SqlCommand cmd = new SqlCommand(Get_Data, conn);
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable("проекты");
                            sda.Fill(dt);
                            dataGrid.ItemsSource = dt.DefaultView;
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show("Database Error: " + ex.Message);
                        }

                    }
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gay = Box.Text;
            switch (gay)
            {

                case "Готовые_решения":
                    {
                        try
                        {
                            string connectionString = @"Data Source=DESKTOP-HJU270S\M1;Initial Catalog=OOO_STK_SAMARA;Integrated Security=True;TrustServerCertificate=True";
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();

                            foreach (DataRowView row in dataGrid.SelectedItems)
                            {
                                string Номер = row.Row["Номер"].ToString();
                                string Готовые_решения = row.Row["Готовые_решения"].ToString();
                                string Потери = row.Row["Потери"].ToString();
                                string Прибыль = row.Row["Прибыль"].ToString();
                                string Дата_работы_проекта = row.Row["Дата_работы_проекта"].ToString();
                                string Денежные_потери = row.Row["Денежные_потери"].ToString();

                                // SQL INSERT QUERY
                                string insertQuery = $"INSERT INTO Готовые_решения (Номер, Готовые_решения, Потери, Прибыль, Дата_работы_проекта) VALUES ('{Номер}', '{Готовые_решения}', '{Потери}', '{Прибыль}', '{Дата_работы_проекта}')";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                                insertCommand.ExecuteNonQuery();
                            }

                            System.Windows.MessageBox.Show("Успех!");
                            connection.Close();
                            string Get_Data = "SELECT * FROM dbo.Готовые_решения";
                            SqlCommand cmd = new SqlCommand(Get_Data, connection);
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable("Готовые_решения");
                            sda.Fill(dt);
                            dataGrid.ItemsSource = dt.DefaultView;
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show("Database Error: " + ex.Message);
                        }
                    }

                    break;
                case "Проекты":
                    {
                        try
                        {
                            string connectionString = @"Data Source=DESKTOP-HJU270S\M1;Initial Catalog=OOO_STK_SAMARA;Integrated Security=True;TrustServerCertificate=True";
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();

                            foreach (DataRowView row in dataGrid.SelectedItems)
                            {
                                string Номер = row.Row["Номер"].ToString();
                                string Название_проект = row.Row["Название_проект"].ToString();
                                string Дата_создание = row.Row["Дата_создание"].ToString();
                                string Краткое_описание = row.Row["Краткое_описание"].ToString();
                                string Прибыль = row.Row["Прибыль"].ToString();
                                string Денежные_потери = row.Row["Денежные_потери"].ToString();

                                // SQL INSERT QUERY
                                string insertQuery = $"INSERT INTO Готовые_решения (Номер, Название_проект, Дата_создание, Краткое_описание, Прибыль,Денежные_потери ) VALUES ('{Номер}', '{Название_проект}', '{Дата_создание}', '{Краткое_описание}', '{Прибыль}','{Денежные_потери}')";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                                insertCommand.ExecuteNonQuery();
                            }

                            System.Windows.MessageBox.Show("Успех!");
                            connection.Close();
                            string Get_Data = "SELECT * FROM dbo.shoes";
                            SqlCommand cmd = new SqlCommand(Get_Data, connection);
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable("shoes");
                            sda.Fill(dt);
                            dataGrid.ItemsSource = dt.DefaultView;
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show("Database Error: " + ex.Message);
                        }
                    }

                    break;

            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Обратная связь с Администратором 79967302303." +
                " По вопросом ошибок прошу писать на почту wertz7190@gmail.com");
        }
    }
}
