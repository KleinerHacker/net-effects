using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace net.effects.Base
{
    /// <summary>
    /// Basic class for a color overlay effect
    /// </summary>
    public abstract class ColorOverlayShaderEffectBase : ShaderEffectBase 
    {
        #region Dependency Properties

        public static readonly DependencyProperty IsChangedSamplersProperty = DependencyProperty.Register(
            "IsChangedSamplers", typeof(bool), typeof(ColorOverlayShaderEffectBase), new UIPropertyMetadata(false, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty OverlayColorProperty = DependencyProperty.Register(
            "OverlayColor", typeof(Color), typeof(ColorOverlayShaderEffectBase), new UIPropertyMetadata(Colors.White, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Defines the overlay color to use for this overlay effect
        /// </summary>
        public Color OverlayColor
        {
            get { return (Color) GetValue(OverlayColorProperty); }
            set { SetValue(OverlayColorProperty, value); }
        }

        /// <summary>
        /// Defines that the sampler and the color has changed for blending calculations
        /// </summary>
        public bool IsChangedSamplers
        {
            get { return (bool)GetValue(IsChangedSamplersProperty); }
            set { SetValue(IsChangedSamplersProperty, value); }
        }

        #endregion

        protected ColorOverlayShaderEffectBase(PixelShader shader) : base(shader)
        {
            UpdateShaderValue(OverlayColorProperty);
            UpdateShaderValue(IsChangedSamplersProperty);
        }
    }
}
