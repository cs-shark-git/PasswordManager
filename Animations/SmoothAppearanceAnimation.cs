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
        DoubleAnimation widthAnimation;
        DoubleAnimation heightAnimation;
        DoubleAnimation opacityAnimation;
        Control[] controls;    // Array of controls
        SmoothAppearanceAnimation(params Control[] controls)    // Getting controls for animation
        {
            this.controls = controls;
        }
        void AnimationProperties(double startWidth, double startHeight, double endWidth, double endHeight, double startOpacity, double endOpacity)      //Setting animation properties for width, height, opacity.
        {
            widthAnimation = new DoubleAnimation();
            widthAnimation.To = endWidth;
            widthAnimation.Duration = TimeSpan.FromSeconds(3);
            heightAnimation = new DoubleAnimation();
            heightAnimation.To = endHeight;
            heightAnimation.Duration = TimeSpan.FromSeconds(3);
            opacityAnimation = new DoubleAnimation();
            opacityAnimation.To = endOpacity;
            opacityAnimation.Duration = TimeSpan.FromSeconds(3);
            foreach (Control control in controls)
            {
                widthAnimation.From = startWidth;
                heightAnimation.From = startHeight;
                opacityAnimation.From = startOpacity;
            }

        }
        void BeginAnimation()   // Begin animation on all components
        {
            foreach (Control control in controls)
            {
                control.BeginAnimation(Control.WidthProperty, widthAnimation);
                control.BeginAnimation(Control.HeightProperty, heightAnimation);
                control.BeginAnimation(Control.OpacityProperty, opacityAnimation);
            }
        }
        void BeginAnimationReverse()   // Begin animation on all components
        {
            widthAnimation.AutoReverse = true;
            heightAnimation.AutoReverse = true;
            opacityAnimation.AutoReverse = true;
            foreach (Control control in controls)
            {
                control.BeginAnimation(Control.WidthProperty, widthAnimation);
                control.BeginAnimation(Control.HeightProperty, heightAnimation);
                control.BeginAnimation(Control.OpacityProperty, opacityAnimation);
            }
            widthAnimation.AutoReverse = false;
            heightAnimation.AutoReverse = false;
            opacityAnimation.AutoReverse = false;
        }
    }
}
