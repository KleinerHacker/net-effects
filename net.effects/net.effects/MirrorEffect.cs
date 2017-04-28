using System;
using System.Windows;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates a mirror effect
    /// </summary>
    public sealed class MirrorEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/MirrorShader.ps")
            };

        #region Dependency Properties

        public static readonly DependencyProperty OpacityProperty = DependencyProperty.Register(
            "Opacity", typeof(float), typeof(MirrorEffect), new UIPropertyMetadata(0.1f, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Opacity value for the mirror
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

        #endregion

        public MirrorEffect()
            : base(Shader)
        {
            UpdateShaderValue(OpacityProperty);
        }
    }
}
