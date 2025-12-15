using Common.Entity;
using UnityEngine;
using Zenject;

namespace GameEngine.TransformFeature
{
    public sealed class TransformInstaller : MonoInstaller
    {
        [SerializeField]
        private TransformConfig _config;

        [SerializeField]
        private Entity _entity;
        
        public override void InstallBindings()
        {
            BindComponents();
            BindController();
        }

        private void BindComponents()
        {
            Rigidbody rigidbody = _entity.gameObject.GetComponent<Rigidbody>();
            MovementComponent movementComponent = new(rigidbody, _config.MovementSpeed);
            _entity.AddComponent(movementComponent);
            
            ScaleComponent scaleComponent = new(_entity.transform, _config.Scale);
            _entity.AddComponent(scaleComponent);
        }
        private void BindController()
        {
            Container.BindInterfacesTo<TransformController>().AsCached();
        }
    }
}