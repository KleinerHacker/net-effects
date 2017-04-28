using System;
using System.Windows;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates a simple relief effect
    /// </summary>
    public sealed class SimpleReliefEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/SimpleReliefShader.ps")
            };

        #region Dependency Property

        public static readonly DependencyProperty TranslationProperty =
            DependencyProperty.Register(
                    "Translation",
                    typeof(float),
                    typeof(SimpleReliefEffect),
                    new UIPropertyMetadata(0.003f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty InterpolationProperty =
            DependencyProperty.Register(
                    "Interpolation",
                    typeof(float),
                    typeof(SimpleReliefEffect),
                    new UIPropertyMetadata(2.7f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty IsGrayProperty =
            DependencyProperty.Register(
                    "IsGray",
                    typeof(bool),
                    typeof(SimpleReliefEffect),
                    new UIPropertyMetadata(true, PixelShaderConstantCallback(2)));

        /// <summary>
        /// Translation of image overlay for relief
        /// </summary>
        public float Translation
        {
            get { return (float)GetValue(TranslationProperty); }
            set { SetValue(TranslationProperty, value); }
        }

        /// <summary>
        /// Interpolation
        /// </summary>
        public float Interpolation
        {
            get { return (float)GetValue(InterpolationProperty); }
            set { SetValue(InterpolationProperty, value); }
        }

        /// <summary>
        /// Stay gray or use original colors
        /// </summary>
        public bool IsGray
        {
            get { return (bool)GetValue(IsGrayProperty); }
            set { SetValue(IsGrayProperty, value); }
        }

        #endregion

        public SimpleReliefEffect()
            : base(Shader)
        {
            UpdateShaderValue(TranslationProperty);
            UpdateShaderValue(InterpolationProperty);
            UpdateShaderValue(IsGrayProperty);
        }
    }
}
