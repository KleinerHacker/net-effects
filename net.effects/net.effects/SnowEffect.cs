using System;
using System.Windows;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates a snow effect
    /// </summary>
    public sealed class SnowEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/SnowShader.ps")
            };

        #region Dependency Property

        public static readonly DependencyProperty OpacityProperty =
            DependencyProperty.Register(
                "Opacity",
                typeof(float),
                typeof(SnowEffect),
                new UIPropertyMetadata(0.1f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty OccurFactorProperty =
            DependencyProperty.Register(
                "OccurFactor",
                typeof(float),
                typeof(SnowEffect),
                new UIPropertyMetadata(0.9f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty RandomProperty =
            DependencyProperty.Register(
                "Random",
                typeof(float),
                typeof(SnowEffect),
                new UIPropertyMetadata((float) new Random().NextDouble(), PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty IsColoredProperty =
            DependencyProperty.Register(
                "IsColored",
                typeof(bool),
                typeof(SnowEffect),
                new UIPropertyMetadata(false, PixelShaderConstantCallback(3)));

        /// <summary>
        /// TRUE if snow must be colored
        /// </summary>
        public bool IsColored
        {
            get { return (bool) GetValue(IsColoredProperty); }
            set { SetValue(IsColoredProperty, value); }
        }

        /// <summary>
        /// Opacity of snow
        /// </summary>
        public float Opacity
        {
            get { return (float) GetValue(OpacityProperty); }
            set
            {
                if (value < 0f && value > 1f)
                    throw new ArgumentOutOfRangeException("Opacity value must be between 0 and 1!");

                SetValue(OpacityProperty, value);
            }
        }

        /// <summary>
        /// factor of occur
        /// </summary>
        public float OccurFactor
        {
            get { return (float) GetValue(OccurFactorProperty); }
            set
            {
                if (value < 0f && value > 1f)
                    throw new ArgumentOutOfRangeException("OccurFactor must be between 0 and 1!");

                SetValue(OccurFactorProperty, value);
            }
        }

        /// <summary>
        /// A random value to change snow pattern
        /// </summary>
        public float Random
        {
            get { return (float) GetValue(RandomProperty); }
            set { SetValue(RandomProperty, value); }
        }

        #endregion

        public SnowEffect()
            : base(Shader)
        {
            UpdateShaderValue(OpacityProperty);
            UpdateShaderValue(OccurFactorProperty);
            UpdateShaderValue(RandomProperty);
        }
    }
}