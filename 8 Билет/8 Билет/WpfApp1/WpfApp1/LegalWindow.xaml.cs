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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для LegalWindow.xaml
    /// </summary>
    public partial class LegalWindow : Window
    {
        RepairMMEntities db;
        public LegalWindow()
        {
            InitializeComponent();
            db = new RepairMMEntities();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string companyName = textBoxCompanyName.Text;
            string companyNumber = textBoxCompanyNumber.Text;

            var newLegal = new Legal
            {
                Legal_Name = companyName,
                Legal_Number = companyNumber
            };

            db.Legal.Add(newLegal);
            db.SaveChanges();

            this.Close();
        }
    }
}
