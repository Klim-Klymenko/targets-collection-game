using Common.Entity;
using Common.Time;
using UnityEngine;
using Zenject;
using Lean.Gui;

namespace GameEngine.Character
{
    internal sealed class CharacterInstaller : MonoInstaller
    {
        [SerializeField]
        private Entity _entity;
        
        [SerializeField] 
        private LeanJoystick _joystick;
        
        public override void InstallBindings()
        {
            BindEntity();
            BindJoystick();
            BindScore();
            BindTickTimer();
        }

        private void BindEntity()
        {
            Container.Bind<IEntity>().To<Entity>().FromInstance(_entity).AsSingle();
        }
        
        private void BindJoystick()
        {
            Container.Bind<IJoystick>().To<LeanJoystick>().FromInstance(_joystick).AsSingle();
        }

        private void BindScore()
        {
            Container.Bind<ScoreCounter>().AsSingle();
        }

        private void BindTickTimer()
        {
            Container.BindInterfacesAndSelfTo<TickTimer>().AsSingle();
        }
    }
}