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

namespace Client_Revamp.Forms.OptionPages
{
     /// <summary>
     /// Interaction logic for Network.xaml
     /// </summary>
     public partial class Network : Page
     {
          public Network(OptionsMenu menu)
          {
               InitializeComponent();
               menu.Save += Menu_Save;
          }

          private void Menu_Save(object sender, EventArgs e)
          {
              
          }

          private void Page_Initialized(object sender, EventArgs e)
          {

          }

          private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {

          }
     }
}
