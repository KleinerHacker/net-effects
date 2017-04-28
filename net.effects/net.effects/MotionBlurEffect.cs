using System;
using System.Windows;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates a motion blur effect
    /// </summary>
    public sealed class MotionBlurEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/MotionBlurShader.ps")
            };

        #region Dependency Property

        public static readonly DependencyProperty AngleProperty =
           DependencyProperty.Register(
                   "Angle",
                   typeof(float),
                   typeof(MotionBlurEffect),
                   new UIPropertyMetadata(0.1f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty BlurAmountProperty =
           DependencyProperty.Register(
                   "BlurAmount",
                   typeof(float),
                   typeof(MotionBlurEffect),
                   new UIPropertyMetadata(0.005f, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Angle of motion
        /// </summary>
        public float Angle
        {
            get { return (float)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        /// <summary>
        /// Blur Amount
        /// </summary>
        public float BlurAmount
        {
            get { return (float)GetValue(BlurAmountProperty); }
            set { SetValue(BlurAmountProperty, value); }
        }

        #endregion

        public MotionBlurEffect()
            : base(Shader)
        {
            UpdateShaderValue(AngleProperty);
            UpdateShaderValue(BlurAmountProperty);
        }
    }
}
