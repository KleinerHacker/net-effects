using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    public sealed class BloomEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/BloomShader.ps")
            };

        #region Dependency Properties

        public static readonly DependencyProperty IntensityProperty = DependencyProperty.Register(
            "Intensity", typeof(float), typeof(BloomEffect), new UIPropertyMetadata(1.0f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty BaseIntensityProperty = DependencyProperty.Register(
            "BaseIntensity", typeof(float), typeof(BloomEffect), new UIPropertyMetadata(1.0f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty SaturationProperty = DependencyProperty.Register(
            "Saturation", typeof(float), typeof(BloomEffect), new UIPropertyMetadata(1.0f, PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty BaseSaturationProperty = DependencyProperty.Register(
            "BaseSaturation", typeof(float), typeof(BloomEffect), new UIPropertyMetadata(1.0f, PixelShaderConstantCallback(3)));

        public float BaseSaturation
        {
            get { return (float) GetValue(BaseSaturationProperty); }
            set { SetValue(BaseSaturationProperty, value); }
        }

        public float Saturation
        {
            get { return (float) GetValue(SaturationProperty); }
            set { SetValue(SaturationProperty, value); }
        }

        public float BaseIntensity
        {
            get { return (float) GetValue(BaseIntensityProperty); }
            set { SetValue(BaseIntensityProperty, value); }
        }

        public float Intensity
        {
            get { return (float) GetValue(IntensityProperty); }
            set { SetValue(IntensityProperty, value); }
        }

        #endregion

        public BloomEffect() : base(Shader)
        {
            UpdateShaderValue(BaseSaturationProperty);
            UpdateShaderValue(SaturationProperty);
            UpdateShaderValue(BaseIntensityProperty);
            UpdateShaderValue(IntensityProperty);
        }
    }
}
