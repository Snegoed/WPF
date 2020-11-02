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
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using zadanWPF.Classes;

namespace zadanWPF.Classes
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class addBlilling : Window
    {
        public addBlilling()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DbClass.openConnection();

            DbClass.sql = "use billing_simple; insert into billing(payer_email,recipient_email,sum,currency,billing_date,comment) values ('" + (payerEmail).Text + "','" + recipientEmail.Text + "','" + sum.Text + "','" + currency.Text + "','" + billingDate.Text + "','" + comment.Text + "');";
            DbClass.cmd.CommandType = CommandType.Text;
            DbClass.cmd.CommandText = DbClass.sql;

            int LCount = DbClass.cmd.ExecuteNonQuery();

            if (LCount > 0) MessageBox.Show("Данные успешно добавлены!\nЗатронуто строк:" + LCount.ToString());

            DbClass.closeConnection();
        }
    }
}
