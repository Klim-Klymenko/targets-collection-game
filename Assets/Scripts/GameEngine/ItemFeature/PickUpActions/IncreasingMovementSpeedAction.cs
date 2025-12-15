using System;
using Common.Entity;
using Common.Physics;
using GameEngine.TransformFeature;
using UnityEngine;
using Zenject;

namespace GameEngine.ItemFeature
{
    [Serializable]
    internal sealed class IncreasingMovementSpeedAction : IColliderAction
    {
        [SerializeField]
        private bool _isTemporaryIncreasing;
        
        [SerializeField]
        private float _duration = -1;

        [SerializeField]
        private float _speedIncreaseFactor;

        private MovementSpeedTimeController _controller;

        [Inject]
        internal void Construct(MovementSpeedTimeController controller)
        {
            _controller = controller;
        }
        
        void IAction<Collider>.Invoke(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;
            
            if (!entity.TryGetComponent(out MovementComponent component))
                return;

            if (_isTemporaryIncreasing)
            {
                _controller.TemporaryMultiplySpeed(_duration, _speedIncreaseFactor, component);
                return;
            }
                
            component.MultiplySpeed(_speedIncreaseFactor);
        }
    }
}