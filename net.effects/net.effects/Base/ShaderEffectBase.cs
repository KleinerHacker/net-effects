using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace net.effects.Base
{
    /// <summary>
    /// Basic class for all shader effects
    /// </summary>
    public abstract class ShaderEffectBase : ShaderEffect
    {
        #region Dependency Properties

        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty(
            "Input", typeof(ShaderEffectBase), 0);

        /// <summary>
        /// Default input brush (normaly the effect based element)
        /// </summary>
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
