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
    public sealed class BandedSwirlEffect : ShaderEffectBase
    {
        private static readonly PixelShader Shader = new PixelShader
        {
            UriSource = ResourceUtils.GetPackageUri("Resources/BandedSwirlShader.ps")
        };

        #region Dependency Properties

        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register(
            "Center", typeof(Point), typeof(BandedSwirlEffect), new UIPropertyMetadata(new Point(0.5d, 0.5d), PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty StrengthProperty = DependencyProperty.Register(
            "Strength", typeof(float), typeof(BandedSwirlEffect), new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty DistanceProperty = DependencyProperty.Register(
            "Distance", typeof(float), typeof(BandedSwirlEffect), new UIPropertyMetadata(0.2f, PixelShaderConstantCallback(2)));

        public float Distance
        {
            get { return (float) GetValue(DistanceProperty); }
            set { SetValue(DistanceProperty, value); }
        }

        public float Strength
        {
            get { return (float) GetValue(StrengthProperty); }
            set { SetValue(StrengthProperty, value); }
        }

        public Point Center
        {
            get { return (Point) GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        #endregion

        public BandedSwirlEffect() : base(Shader)
        {
            UpdateShaderValue(CenterProperty);
            UpdateShaderValue(StrengthProperty);
            UpdateShaderValue(DistanceProperty);
        }
    }
}
