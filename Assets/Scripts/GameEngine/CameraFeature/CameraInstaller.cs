using Common.Entity;
using UnityEngine;
using Zenject;

namespace GameEngine.CameraFeature
{
    public sealed class CameraInstaller : MonoInstaller
    {
        [SerializeField]
        private Entity _entity;
        
        [SerializeField] 
        private Transform _transform;
        
        [SerializeField]
        private Transform _targetTransform;
        
        [SerializeField]
        private float _followingSpeed = 3f;
        
        public override void InstallBindings()
        {
            BindComponent();
            BindController();
        }
        
        private void BindComponent()
        {
            CameraFollowingComponent followingComponent = new(_transform, _targetTransform, _followingSpeed);
            _entity.AddComponent(followingComponent);
        }
        
        private void BindController()
        {
            Container.BindInterfacesTo<CameraController>().AsCached().WithArguments(_entity);
        }
    }
}