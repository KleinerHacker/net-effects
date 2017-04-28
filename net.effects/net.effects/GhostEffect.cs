using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Set with help of gray scaled color values from given image the alpha value
    /// </summary>
    public sealed class GhostEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/GhostShader.ps")
            };

        #region Dependency Property

        public static readonly DependencyProperty OpacityProperty =
            DependencyProperty.Register(
                    "Opacity",
                    typeof(float),
                    typeof(GhostEffect),
                    new UIPropertyMetadata(1f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty IsInverseProperty =
            DependencyProperty.Register(
                    "IsInverse",
                    typeof(bool),
                    typeof(GhostEffect),
                    new UIPropertyMetadata(false, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty IsReplaceColorProperty = DependencyProperty.Register(
            "IsReplaceColor", typeof(bool), typeof(GhostEffect), new UIPropertyMetadata(false, PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty ReplaceColorProperty = DependencyProperty.Register(
            "ReplaceColor", typeof(Color), typeof(GhostEffect), new UIPropertyMetadata(Colors.White, PixelShaderConstantCallback(3)));

        public static readonly DependencyProperty ChannelRProperty =
            DependencyProperty.Register(
                "ChannelR",
                typeof(float),
                typeof(GhostEffect),
                new UIPropertyMetadata(0.3f, PixelShaderConstantCallback(4)));

        public static readonly DependencyProperty ChannelGProperty =
            DependencyProperty.Register(
                "ChannelG",
                typeof(float),
                typeof(GhostEffect),
                new UIPropertyMetadata(0.59f, PixelShaderConstantCallback(5)));

        public static readonly DependencyProperty ChannelBProperty =
            DependencyProperty.Register(
                "ChannelB",
                typeof(float),
                typeof(GhostEffect),
                new UIPropertyMetadata(0.11f, PixelShaderConstantCallback(6)));

        /// <summary>
        /// Gray Scale Color Channel R
        /// </summary>
        public float ChannelR
        {
            get { return (float)GetValue(ChannelRProperty); }
            set { SetValue(ChannelRProperty, value); }
        }

        /// <summary>
        /// Gray Scale Color Channel G
        /// </summary>
        public float ChannelG
        {
            get { return (float)GetValue(ChannelGProperty); }
            set { SetValue(ChannelGProperty, value); }
        }

        /// <summary>
        /// Gray Scale Color Channel B
        /// </summary>
        public float ChannelB
        {
            get { return (float)GetValue(ChannelBProperty); }
            set { SetValue(ChannelBProperty, value); }
        }

        /// <summary>
        /// Color to use for replacing original color. Only used if IsReplaceColor is TRUE
        /// </summary>
        public Color ReplaceColor
        {
            get { return (Color) GetValue(ReplaceColorProperty); }
            set { SetValue(ReplaceColorProperty, value); }
        }

        /// <summary>
        /// TRUE if original color would be replaced with ReplaceColor, otherwise FALSE
        /// </summary>
        public bool IsReplaceColor
        {
            get { return (bool) GetValue(IsReplaceColorProperty); }
            set { SetValue(IsReplaceColorProperty, value); }
        }

        /// <summary>
        /// Opacity value for the cloud displaying
        /// </summary>
        public float Opacity
        {
            get { return (float)GetValue(OpacityProperty); }
            set
            {
                if (value < 0f && value > 1f)
                    throw new ArgumentOutOfRangeException("Opacity value must be between 0 and 1!");
                SetValue(OpacityProperty, value);
            }
        }

        /// <summary>
        /// Invert calculated alpha value
        /// </summary>
        public bool IsInverse
        {
            get { return (bool)GetValue(IsInverseProperty); }
            set { SetValue(IsInverseProperty, value); }
        }

        #endregion

        public GhostEffect() : base(Shader)
        {
            UpdateShaderValue(OpacityProperty);
            UpdateShaderValue(IsInverseProperty);
            UpdateShaderValue(IsReplaceColorProperty);
            UpdateShaderValue(ReplaceColorProperty);
            UpdateShaderValue(ChannelRProperty);
            UpdateShaderValue(ChannelGProperty);
            UpdateShaderValue(ChannelBProperty);
        }
    }
}
