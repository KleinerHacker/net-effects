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
    public sealed class ColorKeyEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/ColorKeyShader.ps")
            };

        #region Dependency Properties

        public static readonly DependencyProperty ThresholdProperty = DependencyProperty.Register(
            "Threshold", typeof(float), typeof(ColorKeyEffect), new UIPropertyMetadata(0.3f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ReplaceColorProperty = DependencyProperty.Register(
            "ReplaceColor", typeof(Color), typeof(ColorKeyEffect), new UIPropertyMetadata(Colors.Transparent, PixelShaderConstantCallback(1)));

        public Color ReplaceColor
        {
            get { return (Color) GetValue(ReplaceColorProperty); }
            set { SetValue(ReplaceColorProperty, value); }
        }

        public float Threshold
        {
            get { return (float) GetValue(ThresholdProperty); }
            set { SetValue(ThresholdProperty, value); }
        }

        #endregion

        public ColorKeyEffect() : base(Shader)
        {
            UpdateShaderValue(ThresholdProperty);
            UpdateShaderValue(ReplaceColorProperty);
        }
    }
}
