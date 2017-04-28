using System;
using System.Windows.Media.Effects;
using net.effects.Base;
using net.effects.Utils;

namespace net.effects
{
    /// <summary>
    /// Creates a negative of the image
    /// </summary>
    public class NegativeEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader =
            new PixelShader()
            {
                UriSource = ResourceUtils.GetPackageUri("Resources/NegativeShader.ps")
            };

        public NegativeEffect()
            : base(Shader)
        {
        }
    }
}
