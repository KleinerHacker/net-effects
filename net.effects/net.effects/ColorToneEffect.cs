using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    public sealed class ColorToneEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/ColorToneShader.ps")
            };

        #region Dependency Properties

        public static readonly DependencyProperty DesaturationProperty = DependencyProperty.Register(
            "Desaturation", typeof(float), typeof(ColorToneEffect), new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty TonedProperty = DependencyProperty.Register(
            "Toned", typeof(float), typeof(ColorToneEffect), new UIPropertyMetadata(1.0f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty LightColorProperty = DependencyProperty.Register(
            "LightColor", typeof(Color), typeof(ColorToneEffect), new UIPropertyMetadata(Color.FromScRgb(1.0f, 1.0f, 0.9f, 0.5f), PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty DarkColorProperty = DependencyProperty.Register(
            "DarkColor", typeof(Color), typeof(ColorToneEffect), new UIPropertyMetadata(Color.FromScRgb(1.0f, 0.2f, 0.05f, 0.0f), PixelShaderConstantCallback(3)));

        public static readonly DependencyProperty GrayScaleChannelProperty = DependencyProperty.Register(
            "GrayScaleChannel", typeof(Color), typeof(ColorToneEffect), new UIPropertyMetadata(Color.FromScRgb(1.0f, 0.3f, 0.59f, 0.11f), PixelShaderConstantCallback(4)));

        public Color GrayScaleChannel
        {
            get { return (Color) GetValue(GrayScaleChannelProperty); }
            set { SetValue(GrayScaleChannelProperty, value); }
        }

        public Color DarkColor
        {
            get { return (Color) GetValue(DarkColorProperty); }
            set { SetValue(DarkColorProperty, value); }
        }

        public Color LightColor
        {
            get { return (Color) GetValue(LightColorProperty); }
            set { SetValue(LightColorProperty, value); }
        }

        public float Toned
        {
            get { return (float) GetValue(TonedProperty); }
            set { SetValue(TonedProperty, value); }
        }

        public float Desaturation
        {
            get { return (float) GetValue(DesaturationProperty); }
            set { SetValue(DesaturationProperty, value); }
        }

        #endregion

        public ColorToneEffect() : base(Shader)
        {
            UpdateShaderValue(DesaturationProperty);
            UpdateShaderValue(TonedProperty);
            UpdateShaderValue(LightColorProperty);
            UpdateShaderValue(DarkColorProperty);
            UpdateShaderValue(GrayScaleChannelProperty);
        }
    }
}
