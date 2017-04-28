using System;
using System.Windows;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates an effect to calculate gray scale colors
    /// </summary>
    public sealed class GrayScaleEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/GrayScaleShader.ps")
            };

        #region Dependency Property

        public static readonly DependencyProperty ChannelRProperty =
           DependencyProperty.Register(
                   "ChannelR",
                   typeof(float),
                   typeof(GrayScaleEffect),
                   new UIPropertyMetadata(0.3f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ChannelGProperty =
           DependencyProperty.Register(
                   "ChannelG",
                   typeof(float),
                   typeof(GrayScaleEffect),
                   new UIPropertyMetadata(0.59f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty ChannelBProperty =
           DependencyProperty.Register(
                   "ChannelB",
                   typeof(float),
                   typeof(GrayScaleEffect),
                   new UIPropertyMetadata(0.11f, PixelShaderConstantCallback(2)));

        /// <summary>
        /// Gray scale factor for color channel R
        /// </summary>
        public float ChannelR
        {
            get { return (float)GetValue(ChannelRProperty); }
            set { SetValue(ChannelRProperty, value); }
        }

        /// <summary>
        /// Gray scale factor for color channel G
        /// </summary>
        public float ChannelG
        {
            get { return (float)GetValue(ChannelGProperty); }
            set { SetValue(ChannelGProperty, value); }
        }

        /// <summary>
        /// Gray scale factor for color channel B
        /// </summary>
        public float ChannelB
        {
            get { return (float)GetValue(ChannelBProperty); }
            set { SetValue(ChannelBProperty, value); }
        }

        #endregion

        public GrayScaleEffect()
            : base(Shader)
        {
            UpdateShaderValue(ChannelRProperty);
            UpdateShaderValue(ChannelGProperty);
            UpdateShaderValue(ChannelBProperty);
        }
    }
}
