using UnityEngine;
using Zenject;

namespace ApplicationEngine.GameCycle
{
    internal sealed class GameCycleInstaller : MonoInstaller
    {
        [SerializeField]
        private GameCycleManager _gameCycleManager;
     
        public override void InstallBindings()
        {
            BindGameCycleManager();
            BindGameCycleManagerInstaller();
        }
        
        private void BindGameCycleManager()
        {
            Container.Bind<GameCycleManager>().FromInstance(_gameCycleManager).AsSingle();
        }

        private void BindGameCycleManagerInstaller()
        {
            Container.Bind<GameCycleManagerInstaller>().AsSingle().NonLazy();
        }
    }
}