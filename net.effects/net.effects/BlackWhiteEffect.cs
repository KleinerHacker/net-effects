using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates a black and white effect (no gray scale)
    /// </summary>
    public sealed class BlackWhiteEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/BlackWhiteShader.ps")
            };

        #region Dependency Properties

        public static readonly DependencyProperty MiddleProperty =
            DependencyProperty.Register(
                "MiddleValue",
                typeof(float),
                typeof(BlackWhiteEffect),
                new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty HeightColorProperty =
            DependencyProperty.Register(
                "HeightColor",
                typeof(Color),
                typeof(BlackWhiteEffect),
                new UIPropertyMetadata(Colors.White,
                    PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty LowColorProperty =
            DependencyProperty.Register(
                "LowColor",
                typeof(Color),
                typeof(BlackWhiteEffect),
                new UIPropertyMetadata(Colors.Black,
                    PixelShaderConstantCallback(2)));

        /// <summary>
        /// Value between 0 and 1 to find middle value to define what is low and high color
        /// </summary>
        public float MiddleValue
        {
            get { return (float)GetValue(MiddleProperty); }
            set
            {
                if (value < 0f && value > 1f)
                    throw new ArgumentOutOfRangeException("Alpha value must be between 0 and 1!");

                SetValue(MiddleProperty, value);
            }
        }

        /// <summary>
        /// Replacing color for a color, identified as high color
        /// </summary>
        public Color HeightColor
        {
            get { return (Color)GetValue(HeightColorProperty); }
            set { SetValue(HeightColorProperty, value); }
        }

        /// <summary>
        /// Replacing color for a color, identified as low color
        /// </summary>
        public Color LowColor
        {
            get { return (Color)GetValue(LowColorProperty); }
            set { SetValue(LowColorProperty, value); }
        }

        #endregion

        public BlackWhiteEffect()
            : base(Shader)
        {
            MiddleValue = 0.5f;
            HeightColor = Colors.White;
            LowColor = Colors.Black;

            UpdateShaderValue(MiddleProperty);
            UpdateShaderValue(HeightColorProperty);
            UpdateShaderValue(LowColorProperty);
        }
    }
}