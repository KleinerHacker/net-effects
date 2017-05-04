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
    public sealed class BrightExtractEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/BrightExtractShader.ps")
            };

        #region Dependency Properties

        public static readonly DependencyProperty TresholdProperty = DependencyProperty.Register(
            "Treshold", typeof(float), typeof(BrightExtractEffect), new UIPropertyMetadata(0.25f, PixelShaderConstantCallback(0)));

        public float Treshold
        {
            get { return (float) GetValue(TresholdProperty); }
            set { SetValue(TresholdProperty, value); }
        }

        #endregion

        public BrightExtractEffect() : base(Shader)
        {
            UpdateShaderValue(TresholdProperty);
        }
    }
}
