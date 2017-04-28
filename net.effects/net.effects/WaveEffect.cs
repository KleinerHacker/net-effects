using System;
using System.Windows;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates a wave effect
    /// </summary>
    public sealed class WaveEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/WaveShader.ps")
            };

        #region Dependency Property

        public static readonly DependencyProperty ScaleXProperty =
            DependencyProperty.Register(
                    "ScaleX",
                    typeof(float),
                    typeof(WaveEffect),
                    new UIPropertyMetadata(100f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ScaleYProperty =
            DependencyProperty.Register(
                    "ScaleY",
                    typeof(float),
                    typeof(WaveEffect),
                    new UIPropertyMetadata(0.03f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty TranslationXProperty =
            DependencyProperty.Register(
                    "TranslationX",
                    typeof(float),
                    typeof(WaveEffect),
                    new UIPropertyMetadata(0f, PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty TranslationYProperty =
            DependencyProperty.Register(
                    "TranslationY",
                    typeof(float),
                    typeof(WaveEffect),
                    new UIPropertyMetadata(0f, PixelShaderConstantCallback(3)));

        /// <summary>
        /// Scale factor X for waves
        /// </summary>
        public float ScaleX
        {
            get { return (float)GetValue(ScaleXProperty); }
            set { SetValue(ScaleXProperty, value); }
        }

        /// <summary>
        /// Scale factor Y for waves
        /// </summary>
        public float ScaleY
        {
            get { return (float)GetValue(ScaleYProperty); }
            set { SetValue(ScaleYProperty, value); }
        }

        /// <summary>
        /// Translation of waves X
        /// </summary>
        public float TranslationX
        {
            get { return (float)GetValue(TranslationXProperty); }
            set { SetValue(TranslationXProperty, value); }
        }

        /// <summary>
        /// Translation of waves Y
        /// </summary>
        public float TranslationY
        {
            get { return (float)GetValue(TranslationYProperty); }
            set { SetValue(TranslationYProperty, value); }
        }

        #endregion

        public WaveEffect()
            : base(Shader)
        {
            UpdateShaderValue(ScaleXProperty);
            UpdateShaderValue(ScaleYProperty);
            UpdateShaderValue(TranslationXProperty);
            UpdateShaderValue(TranslationYProperty);
        }
    }
}
