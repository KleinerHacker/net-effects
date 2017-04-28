using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace net.effects.Base
{
    public abstract class ShaderEffectBase : ShaderEffect
    {
        #region Dependency Properties

        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty(
            "Input", typeof(ShaderEffectBase), 0);

        public Brush Input
        {
            get { return (Brush) GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        #endregion

        protected ShaderEffectBase(PixelShader shader)
        {
            PixelShader = shader;
            UpdateShaderValue(InputProperty);
        }
    }
}
