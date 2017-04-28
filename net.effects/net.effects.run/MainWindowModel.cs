using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

namespace net.effects.run
{
    internal class MainWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _effectName;
        private bool _hasNext, _hasPrev;
        private Effect _effect;

        public string EffectName
        {
            get { return _effectName; }
            set
            {
                _effectName = value;
                RaisePropertyChange();
            }
        }

        public bool HasNext
        {
            get { return _hasNext; }
            set
            {
                _hasNext = value;
                RaisePropertyChange();
            }
        }

        public bool HasPrev
        {
            get { return _hasPrev; }
            set
            {
                _hasPrev = value;
                RaisePropertyChange();
            }
        }

        public Effect Effect
        {
            get { return _effect; }
            set
            {
                _effect = value;
                RaisePropertyChange();
            }
        }

        protected void RaisePropertyChange([CallerMemberName] string value = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
        }
    }
}
