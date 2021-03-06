using PasswordManager.Animations;
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
using PasswordManager.Properties;

namespace PasswordManager.Forms
{
    /// <summary>
    /// Логика взаимодействия для WelcomeForm.xaml
    /// </summary>
    public partial class WelcomeForm : Window
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SmoothAppearanceAnimation animation = new SmoothAppearanceAnimation(welcomeGrid, nextButton);
            SmoothAppearanceAnimationText animationText = new SmoothAppearanceAnimationText(infoLabel, welcomeLabel);
            animation.SetAnimationPropertiesAndBegin(2, 2, 100, 10);
            animationText.SetAnimationPropertiesAndBegin(2, 100, 10);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            welcomeLabel.Opacity = 0.01;
            welcomeGrid.Opacity = 0.01;
            infoLabel.Opacity = 0.01;
            nextButton.Opacity = 0.01;
            welcomeGrid.Width = 250;
            welcomeGrid.Height = 114;
            nextButton.Width = 72;
            nextButton.Height = 18;
            welcomeLabel.FontSize = 12;
            infoLabel.FontSize = 8;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
            
        }
    }
}
