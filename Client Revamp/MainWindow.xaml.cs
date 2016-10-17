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
using Client_Revamp.Forms;


namespace Client_Revamp
{
     /// <summary>
     /// Interaction logic for MainWindow.xaml
     /// </summary>
     public partial class MainWindow : Window
     {
          private OptionsMenu menu = new OptionsMenu();
          public MainWindow()
          {
               InitializeComponent();
          }

          private void CommandBinding_Close(object sender, ExecutedRoutedEventArgs e)
          {
               Environment.Exit(0);
          }

          private void CommandBinding_About(object sender, ExecutedRoutedEventArgs e)
          {
               //TODO Add About Form
               throw new NotImplementedException("This feature ain't implemented yet.");
          }

          private void CommandBinding_Options(object sender, ExecutedRoutedEventArgs e)
          {
               menu.ShowDialog();
          }
     }

     public class Commands
     {
          #region MainWindow Commands
          public static readonly RoutedUICommand AboutCommand = new RoutedUICommand("About Command", "About", typeof(MainWindow));
          public static readonly RoutedUICommand OptionsCommand = new RoutedUICommand("Options Command", "Options", typeof(MainWindow));
          #endregion

          #region Options Window and Pages
          public static readonly RoutedUICommand SaveCommand = new RoutedUICommand("Save Command", "Save", typeof(OptionsMenu));
          #endregion
     }
}
