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
using Client_Revamp.Forms.OptionPages;
using Client_Revamp.Interfaces;

namespace Client_Revamp.Forms
{
     /// <summary>
     /// Interaction logic for OptionsMenu.xaml
     /// </summary>
     public partial class OptionsMenu : Window, ISave
     {
          Dictionary<String, Page> Pages = new Dictionary<string, Page>();

          public event EventHandler Save;

          public OptionsMenu()
          {
               InitializeComponent();
          }

          private void Window_Initialized(object sender, EventArgs e)
          {
               Pages.Add("General", new General());
               Pages.Add("Network", new Network(this));
               Pages.Add("Search", new Search());

               RefreshPage();
          }

          private void RefreshPage()
          {
               Page temp;
               Pages.TryGetValue(((ListBoxItem)OptionList.SelectedItem).Content.ToString(), out temp);

               if(OptionsControl != null)
                    OptionsControl.Content = temp;
          }

          private void OptionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
               RefreshPage();
          }

          private void CommandBinding_Save(object sender, ExecutedRoutedEventArgs e)
          {
               if (Save != null)
                    Save.Invoke(this,null);
          }

          private void CommandBinding_Close(object sender, ExecutedRoutedEventArgs e)
          {
               this.Hide();
          }
     }
}
