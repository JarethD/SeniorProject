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

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HardwareStore lumberCompany = new HardwareStore("AceHardwareBKOR", "", "Ace Hardware", "Brookings Oregon", 5416619764, 01);
            LumberAssociate lumberPerson = new LumberAssociate("JarethDodson", "", 01, "Jareth Dodson", 5415554444, "Ace Hardware", 01);
            lumberCompany.AddLA(lumberPerson);
            
        }
    }
}
