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
    /// Логика взаимодействия для IndividualWindow.xaml
    /// </summary>
    public partial class IndividualWindow : Window
    {
        RepairMMEntities db;
        public IndividualWindow()
        {
            InitializeComponent();
            db = new RepairMMEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newInd = new Individual
            {
                Individual_FIO = TbFIO.Text,
                Individual_Address = TbAdr.Text,
                Individual_Number = TbNumb.Text
            };

            db.Individual.Add(newInd);
            db.SaveChanges();

            this.Close();
        }
    }
}
