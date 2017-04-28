using System;
using System.Windows;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates an effect to grown up pixels
    /// </summary>
    public sealed class PixelEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/PixelShader.ps")
            };

        #region Dependency Property

        public static readonly DependencyProperty WidthProperty =
           DependencyProperty.Register(
                   "Width",
                   typeof(float),
                   typeof(PixelEffect),
                   new UIPropertyMetadata(0.01f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty HeightProperty =
           DependencyProperty.Register(
                   "Height",
                   typeof(float),
                   typeof(PixelEffect),
                   new UIPropertyMetadata(0.01f, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Width of grown up pixel
        /// </summary>
        public float Width
        {
            get { return (float)GetValue(WidthProperty); }
            set
            {
                if (value < 0f && value > 1f)
                    throw new ArgumentOutOfRangeException("Alpha value must be between 0 and 1!");
                SetValue(WidthProperty, value);
            }
        }

        /// <summary>
        /// Height of grown up pixel
        /// </summary>
        public float Height
        {
            get { return (float)GetValue(HeightProperty); }
            set
            {
                if (value < 0f && value > 1f)
                    throw new ArgumentOutOfRangeException("Alpha value must be between 0 and 1!");
                SetValue(HeightProperty, value);
            }
        }

        #endregion

        public PixelEffect()
            : base(Shader)
        {
            UpdateShaderValue(WidthProperty);
            UpdateShaderValue(HeightProperty);
        }
    }
}
