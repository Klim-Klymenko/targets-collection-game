using Common.Entity;
using UnityEngine;
using Zenject;

namespace GameEngine.CameraFeature
{
    public sealed class CameraInstaller : MonoInstaller
    {
        [SerializeField] 
        private Transform _transform;

        [SerializeField]
        private float _followingStep = 0.025f;

        private readonly Entity _entity = new();
        
        private Transform _targetTransform;
        private DiContainer _diContainer;
        
        public void InstallBindings(IEntity targetEntity, DiContainer diContainer)
        { 
            _targetTransform = targetEntity.GetComponent<Transform>();
            _diContainer = diContainer;
            
            InstallBindings();
        }
        
        public override void InstallBindings()
        {
            BindComponent();
            BindController();
        }
        
        private void BindComponent()
        {
            CameraFollowingComponent followingComponent = new(_transform, _targetTransform, _followingStep);
            _entity.AddComponent(followingComponent);
        }
        
        private void BindController()
        {
            _diContainer.BindInterfacesTo<CameraController>().AsCached().WithArguments(_entity);
        }
    }
}