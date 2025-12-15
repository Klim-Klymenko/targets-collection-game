using System.Collections.Generic;
using ApplicationEngine.GameCycle;
using Common.UI;
using Zenject;

namespace UI.Widgets
{
    internal sealed class WindowShowerInstaller : MonoInstaller, IStartable
    {
        private IReadOnlyList<IWindowShower> _showers;
        
        public override void InstallBindings()
        {
            _showers = Container.Resolve<IWindowShower[]>();
        }
        
        void IStartable.OnStart()
        {
            for (int i = 0; i < _showers.Count; i++)
            {
                _showers[i].Show();
            }
        }
    }
}