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

namespace PasswordManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();          
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
           // File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\firstLaunch.cs_shark");  //Файлы с моим расширением :)
            if (FirstLaunch.CheckLaunch(AppDomain.CurrentDomain.BaseDirectory + "\\firstLaunch.cs_shark"))
            {
                button.Content = "пипа";
            }
            else
            {               
                button.Content = "не пипа";
            }
        }
    }
}
