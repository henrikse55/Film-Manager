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
          private string Username;
          private bool AutoScan;
          private bool AutoAcceptManagers;
          private int PromptLevel;

          public Network(OptionsMenu menu)
          {
               InitializeComponent();
               menu.Save += Menu_Save;
          }

          private void Menu_Save(object sender, EventArgs e)
          {
               Properties.Settings.Default.Username = UsernameTextBox.Text;
               Properties.Settings.Default.PromptLevel = PromptLevelComboBox.SelectedIndex;
          }

          private async void Page_Initialized(object sender, EventArgs e)
          {
               //Set Promp level
               PromptLevel = Properties.Settings.Default.PromptLevel;
               PromptLevelComboBox.SelectedIndex = Properties.Settings.Default.PromptLevel;

               //Check Username and set username
               if (!String.IsNullOrEmpty(Properties.Settings.Default.Username) || !String.IsNullOrWhiteSpace(Properties.Settings.Default.Username)){
                    UsernameTextBox.Text = Properties.Settings.Default.Username;
               }else{
                    UsernameTextBox.Text = Environment.UserName;
                    Properties.Settings.Default.Username = Environment.UserName;
                    Properties.Settings.Default.Save();
               }

               //Auto Scan Network
               AutoScan = (AutoScanCheckBox?.IsChecked.HasValue == true ? AutoScanCheckBox.IsChecked.Value : false);

               //Auto Accept Managers
               AutoAcceptManagers = (AutoAcceptCheckBox?.IsChecked.HasValue == true ? AutoAcceptCheckBox.IsChecked.Value : false);

               await UpdateAutoScanLabel();
          }

          public Task UpdateAutoScanLabel()
          {


               return Task.FromResult(0);
          }

          private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
               PromptLevel = PromptLevelComboBox.SelectedIndex;
          }
     }
}
