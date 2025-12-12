using Common.Entity;
using GameEngine.CameraFeature;
using GameEngine.TransformFeature;
using UnityEngine;
using Zenject;
using Lean.Gui;

namespace GameEngine.Character
{
    internal sealed class CharacterInstaller : MonoInstaller
    {
        [SerializeField] 
        private Transform _transform;
        
        [SerializeField]
        private Rigidbody _rigidbody;
        
        [SerializeField] 
        private LeanJoystick _joystick;

        [SerializeField]
        private TransformInstaller _transformInstaller;
        
        [SerializeField]
        private CameraInstaller _cameraInstaller;
        
        private readonly Entity _entity = new();
        
        public override void InstallBindings()
        {
            BindEntity();
            BindJoystick();
            BindScore();
            
            _transformInstaller.InstallBindings(_entity, Container);
            _cameraInstaller.InstallBindings(_entity, Container);
        }

        private void BindEntity()
        {
            _entity.AddComponent(_transform);
            _entity.AddComponent(_rigidbody);
            
            Container.Bind<IEntity>().To<Entity>().FromInstance(_entity).AsSingle();
        }
        
        private void BindJoystick()
        {
            Container.Bind<IJoystick>().To<LeanJoystick>().FromInstance(_joystick).AsSingle();
        }

        private void BindScore()
        {
            Container.Bind<Score>().AsSingle();
        }
    }
}