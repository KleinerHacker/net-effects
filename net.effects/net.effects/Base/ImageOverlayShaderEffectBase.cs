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
    /// Basic class for image overlay effects
    /// </summary>
    public abstract class ImageOverlayShaderEffectBase : ShaderEffectBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty IsChangedSamplersProperty = DependencyProperty.Register(
            "IsChangedSamplers", typeof(bool), typeof(ImageOverlayShaderEffectBase), new UIPropertyMetadata(false, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty OverlayImageProperty = RegisterPixelShaderSamplerProperty(
            "OverlayImage",typeof(ImageOverlayShaderEffectBase), 1);

        /// <summary>
        /// Defines the overlay image to use for this overlay effect
        /// </summary>
        public Brush OverlayImage
        {
            get { return (Brush) GetValue(OverlayImageProperty); }
            set { SetValue(OverlayImageProperty, value); }
        }

        /// <summary>
        /// Defines that the source and overlay sampler has changed for blending calculations
        /// </summary>
        public bool IsChangedSamplers
        {
            get { return (bool)GetValue(IsChangedSamplersProperty); }
            set { SetValue(IsChangedSamplersProperty, value); }
        }

        #endregion

        protected ImageOverlayShaderEffectBase(PixelShader shader) : base(shader)
        {
            UpdateShaderValue(OverlayImageProperty);
            UpdateShaderValue(IsChangedSamplersProperty);
        }
    }
}
