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

namespace bl1.Views
{
    /// <summary>
    /// Логика взаимодействия для RequestForm.xaml
    /// </summary>
    public partial class RequestForm : Window
    {
        public Requests Request { get; set; }
        public Tech tech { get; set; }
        public Clients cl { get; set; }
        public Workers works { get; set; }

        public RequestForm(Requests existing = null, Tech exTech = null, Clients exCl = null, Workers exW = null)
        {
            InitializeComponent();

            if (existing != null && exTech != null && exCl != null && exW != null)
            {

                Requests req = new Requests();
                Tech tech = new Tech();
                Clients cl = new Clients();
                Workers works = new Workers();
                Request = existing;
                tech = exTech;
                cl = exCl;
                works = exW;
                ReqNameTbx.Text = Request.ReqName;
                ReqNumberTbx.Text = req.ReqNumber.ToString();
                TechNameTbx.Text = tech.TechName;
                ClientFIOTbx.Text = cl.FIOClient;
                WorkerFIOTbx.Text = works.WorkerFIO;

            }
            else
            { 
                Request = new Requests();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Requests req = new Requests();

            ReqNameTbx.Text = Request.ReqName;
            ReqNumberTbx.Text = req.ReqNumber.ToString();
            TechNameTbx.Text = tech.TechName;
            ClientFIOTbx.Text = cl.FIOClient;
            WorkerFIOTbx.Text = works.WorkerFIO;
            DialogResult = true;
        }
    }
}
