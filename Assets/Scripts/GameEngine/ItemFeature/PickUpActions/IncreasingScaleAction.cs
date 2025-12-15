using System;
using Common.Entity;
using Common.Physics;
using GameEngine.TransformFeature;
using UnityEngine;

namespace GameEngine.ItemFeature
{
    [Serializable]
    internal sealed class IncreasingScaleAction : IColliderAction
    {
        [SerializeField]
        private float _scaleIncreaseFactor;
        
        void IAction<Collider>.Invoke(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;
            
            if (entity.TryGetComponent(out ScaleComponent component))
                component.MultiplyScale(_scaleIncreaseFactor);
        }
    }
}