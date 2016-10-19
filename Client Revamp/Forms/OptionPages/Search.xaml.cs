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
using Client_Revamp.Interfaces;


namespace Client_Revamp.Forms.OptionPages
{
     /// <summary>
     /// Interaction logic for Search.xaml
     /// </summary>
     public partial class Search : Page
     {
          public Search(OptionsMenu menu)
          {
               InitializeComponent();
               menu.Save += Menu_Save;
          }

          private void Menu_Save(object sender, EventArgs e)
          {
               
          }
     }
}
