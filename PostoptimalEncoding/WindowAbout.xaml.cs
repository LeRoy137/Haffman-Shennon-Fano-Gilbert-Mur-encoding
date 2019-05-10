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

namespace PostoptimalEncoding
{
    /// <summary>
    /// Логика взаимодействия для WindowAbout.xaml
    /// </summary>
    public partial class WindowAbout : Window
    {
        public WindowAbout()
        {
            InitializeComponent();
        }
    }

    public class Row
    {
        public String Col1 { get; set; }
        public String Col2 { get; set; }
        public String Col3 { get; set; }
        public String Col4 { get; set; }
        public String Col5 { get; set; }
    }

    public class RowShennon
    {
        public String Col1 { get; set; }
        public String Col2 { get; set; }
        public String Col3 { get; set; }
        public String Col4 { get; set; }
        public String Col5 { get; set; }
        public String Col6 { get; set; }
        public String Col7 { get; set; }

    }

}
