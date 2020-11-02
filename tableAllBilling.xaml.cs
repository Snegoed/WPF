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
//
using System.Data;
using System.Data.SqlClient;
using zadanWPF.Classes;

namespace zadanWPF
{
    /// <summary>
    /// Логика взаимодействия для ConnectToSQLServerWindow.xaml
    /// </summary>
    public partial class tableAllBilling : Window
    {
        public tableAllBilling()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DbClass.openConnection();

            DbClass.sql = "SELECT [payer_email], [recipient_email], [sum], [currency], [billing_date], [comment] FROM billing";
            DbClass.cmd.CommandType = CommandType.Text;
            DbClass.cmd.CommandText = DbClass.sql;

            DbClass.da = new SqlDataAdapter(DbClass.cmd);
            DbClass.dt = new DataTable();
            DbClass.da.Fill(DbClass.dt);

            myDataGrid.ItemsSource = DbClass.dt.DefaultView;

            DbClass.closeConnection();
        }
    }
}
