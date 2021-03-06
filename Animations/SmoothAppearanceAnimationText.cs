using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace PasswordManager.Animations
{
    class SmoothAppearanceAnimationText
    {
        private Control[] controls;
        private DoubleAnimation textSizeAnimation;
        private DoubleAnimation opacityAnimation;
        public SmoothAppearanceAnimationText(params Control[] controls)    // Getting controls for animation and init fields
        {
            this.controls = controls;
            textSizeAnimation = new DoubleAnimation();
            opacityAnimation = new DoubleAnimation();
        }
        public void SetAnimationPropertiesAndBegin(double textSizeFactor, double opacityFactor, double duration = 3)
        {
            if (textSizeFactor < 1 || opacityFactor < 1 || duration < 1)
            {
                throw new Exception("Значение аргумента не может быть меньше 0");
            }
            foreach (Control control in controls)
            {   
                opacityAnimation.From = control.Opacity;               
                textSizeAnimation.From = control.FontSize;
                opacityAnimation.To = control.Opacity * opacityFactor;
                textSizeAnimation.To = control.FontSize * textSizeFactor;
                
                control.BeginAnimation(Control.FontSizeProperty, textSizeAnimation);
                control.BeginAnimation(Control.OpacityProperty, opacityAnimation);
            }
        }
    }
}
