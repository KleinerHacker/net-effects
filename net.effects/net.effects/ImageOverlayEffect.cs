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
    /// Creates an effect with an overlay image
    /// </summary>
    public sealed class ImageOverlayEffect : ImageOverlayShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/ImageOverlayShader.ps")
            };

        #region Dependency Property

        public static readonly DependencyProperty OpacityProperty =
            DependencyProperty.Register(
                    "Opacity",
                    typeof(float),
                    typeof(ImageOverlayEffect),
                    new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty BlendTypeProperty = DependencyProperty.Register(
            "BlendType", typeof(int), typeof(ImageOverlayEffect), new PropertyMetadata((int) Type.BlendType.Overlay, PixelShaderConstantCallback(2)));

        /// <summary>
        /// Type of blending
        /// </summary>
        public BlendType BlendType
        {
            get { return (BlendType)(int) GetValue(BlendTypeProperty); }
            set { SetValue(BlendTypeProperty, (int)value); }
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

        public ImageOverlayEffect()
            : base(Shader)
        {
            UpdateShaderValue(OpacityProperty);
            UpdateShaderValue(BlendTypeProperty);
        }

        
    }
}
