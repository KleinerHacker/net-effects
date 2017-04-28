using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using net.effects.Base;

namespace net.effects.run
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowModel _model;
        private readonly IList<System.Type> _effectTypeList;

        private int index = 0;

        public MainWindow()
        {
            InitializeComponent();
            _model = (MainWindowModel) FindResource("Model");

            _effectTypeList = typeof(ShaderEffectBase).Assembly.GetTypes()
                .Where(type => !type.IsAbstract)
                .Where(type => type.IsSubclassOf(typeof(ShaderEffectBase)))
                .OrderBy(type => type.Name)
                .ToList();
            UpdateEffect();
        }

        private void OnNextClick(object sender, RoutedEventArgs e)
        {
            index++;
            if (index >= _effectTypeList.Count)
            {
                index = 0;
            }
            UpdateEffect();
        }

        private void OnPrevClick(object sender, RoutedEventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = _effectTypeList.Count - 1;
            }
            UpdateEffect();
        }

        private void UpdateEffect()
        {
            _model.Effect = (ShaderEffectBase) _effectTypeList[index].GetConstructor(new System.Type[0]).Invoke(new object[0]);
            _model.EffectName = _effectTypeList[index].Name + " (" + (index + 1) + "/" + _effectTypeList.Count + ")";
            _model.HasNext = index < _effectTypeList.Count - 1;
            _model.HasPrev = index > 0;
        }
    }
}
