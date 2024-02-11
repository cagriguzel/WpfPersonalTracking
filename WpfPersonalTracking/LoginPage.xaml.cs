using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfPersonalTracking.DB;

namespace WpfPersonalTracking
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        DataContext db = new DataContext();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserNo.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                MessageBox.Show("Please fill the Userno and password area");
            else
            {
                Employee employee = db.Employees.FirstOrDefault(x => x.UserNo == Convert.ToInt32(txtUserNo.Text) &&
                  x.Password.Equals(txtPassword.Text));
                if (employee != null && employee.Id != 0)
                {
                    this.Visibility = Visibility.Collapsed;
                    MainWindow main = new MainWindow();
                    UserStatic.EmployeeId = employee.Id;
                    UserStatic.isAdmin = (bool)employee.IsAdmin;
                    UserStatic.Name = employee.Name;
                    UserStatic.Surname = employee.Surname;
                    UserStatic.UserNo = employee.UserNo;
                    main.ShowDialog();
                    
                }
                else
                    MessageBox.Show("Please make sure that your passwrod and userno is true");
            }


        }

        private void txtUserNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
