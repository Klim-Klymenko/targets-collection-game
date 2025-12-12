using Common.Entity;
using UnityEngine;
using Zenject;

namespace GameEngine.TransformFeature
{
    public sealed class TransformInstaller : MonoInstaller
    {
        [SerializeField]
        private TransformConfig _config;

        private IEntity _entity;
        private DiContainer _diContainer;

        public void InstallBindings(IEntity entity, DiContainer diContainer)
        {
            _entity = entity;
            _diContainer = diContainer;
            
            InstallBindings();
        }
        
        public override void InstallBindings()
        {
            BindComponents();
            BindController();
        }

        private void BindComponents()
        {
            Rigidbody rigidbody = _entity.GetComponent<Rigidbody>();
            MovementComponent movementComponent = new(rigidbody, _config.MovementSpeed);
            _entity.AddComponent(movementComponent);

            Transform transform = _entity.GetComponent<Transform>();
            ScaleComponent scaleComponent = new(transform, _config.Scale);
            _entity.AddComponent(scaleComponent);
        }
        private void BindController()
        {
            _diContainer.BindInterfacesTo<TransformController>().AsCached();
        }
    }
}