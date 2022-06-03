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

namespace lab_9
{
    /// <summary>
    /// Logika interakcji dla klasy Technology.xaml
    /// </summary>
    public partial class Technology : UserControl
    {
        public string Type { get; set; }

        public Brush Color
        {
            get { return this.techBroder.Background; }
            set { this.techBroder.Background = value; }
        }
        public CornerRadius Radius
        {
            get { return this.techBroder.CornerRadius; }
            set { this.techBroder.CornerRadius = value; }
        }

        public string Text
        {
            get { return this.techText.Text; }
            set { this.techText.Text = value; }
        }

        public Technology()
        {
            InitializeComponent();
        }
    }
}
