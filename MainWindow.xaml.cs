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
using System.IO;
using System.Windows.Media.Animation;
using PasswordManager.View;
using PasswordManager.Properties;

namespace PasswordManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // НЕ ЗАБЫТЬ УБРАТЬ
           /* !!! */ Settings.Default.Reset(); /* !!! */
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            if (Settings.Default.isFirstLaunch)
            {                               
                Hide();
                WelcomeWindow win = new WelcomeWindow();
                win.Show();
              /* ! */  Settings.Default.isFirstLaunch = false;
                Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("MainWindow");
                Application.Current.Shutdown();
                /*
                 * 
                 * TODO:
                 * Launch MainWindow with normal created normal GUI and realize save info from WelcomeForm.
                 * Add new comments
                 */
            }
        }
    }
}
