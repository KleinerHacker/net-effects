using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Type;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates an effect with a given color overlay
    /// </summary>
    public sealed class ColorOverlayEffect : ColorOverlayShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/ColorOverlayShader.ps")
            };

        #region Dependency Property

        public static readonly DependencyProperty OpacityProperty =
            DependencyProperty.Register(
                    "Opacity",
                    typeof(float),
                    typeof(ColorOverlayEffect),
                    new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty BlendTypeProperty = DependencyProperty.Register(
            "BlendType", typeof(int), typeof(ColorOverlayEffect), new UIPropertyMetadata((int) BlendType.Overlay, PixelShaderConstantCallback(3)));

        /// <summary>
        /// Type of blending
        /// </summary>
        public BlendType BlendType
        {
            get { return (BlendType)(int) GetValue(BlendTypeProperty); }
            set { SetValue(BlendTypeProperty, (int) value); }
        }

        /// <summary>
        /// Opacity value in case of overlay blending
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

        #endregion

        public ColorOverlayEffect()
            : base(Shader)
        {
            UpdateShaderValue(OpacityProperty);
            UpdateShaderValue(BlendTypeProperty);
        }
    }
}
