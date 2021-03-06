using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PasswordManager
{
    class SmoothAppearanceAnimation
    {
        private DoubleAnimation widthAnimation;
        private DoubleAnimation heightAnimation;
        protected DoubleAnimation opacityAnimation;
        private System.Windows.FrameworkElement[] controls;    // Array of controls
        public SmoothAppearanceAnimation(params System.Windows.FrameworkElement[] controls)    // Getting controls for animation
        {
            this.controls = controls;
            widthAnimation = new DoubleAnimation();
            heightAnimation = new DoubleAnimation();
            opacityAnimation = new DoubleAnimation();
        }
        public void SetAnimationPropertiesAndBegin(double widthFactor, double heightFactor, double opacityFactor, double duration = 3)      //Setting animation properties for width, height, opacity.
        {
            if (widthFactor < 1 || heightFactor < 1 || opacityFactor < 1 || duration < 1)
            {
                throw new Exception("Значение аргумента не может быть меньше 0");
            }
            foreach (System.Windows.FrameworkElement control in controls)
            {
                widthAnimation.From = control.ActualWidth;
                heightAnimation.From = control.ActualHeight;
                opacityAnimation.From = control.Opacity;
                widthAnimation.To = control.ActualWidth * widthFactor;
                heightAnimation.To = control.ActualHeight * heightFactor;
                opacityAnimation.To = control.Opacity * opacityFactor;
                control.BeginAnimation(System.Windows.FrameworkElement.WidthProperty, widthAnimation);
                control.BeginAnimation(System.Windows.FrameworkElement.HeightProperty, heightAnimation);
                control.BeginAnimation(System.Windows.FrameworkElement.OpacityProperty, opacityAnimation);
            }
        }
    }
}
