using System.Windows;
using System.Windows.Media;

namespace SelfDevelopmentApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FontFamily = new FontFamily("Segoe UI");
        }
    }
}