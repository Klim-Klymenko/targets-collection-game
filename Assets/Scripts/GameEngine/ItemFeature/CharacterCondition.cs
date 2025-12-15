using System;
using Common.Physics;
using UnityEngine;

namespace GameEngine.ItemFeature
{
    [Serializable]
    internal sealed class CharacterCondition : IColliderCondition
    {
        [SerializeField]
        private LayerMask _characterLayer;
        
        private const byte FirstBit = 1;
        
        bool IFunction<Collider, bool>.Invoke(Collider other)
        {
            int power = other.gameObject.layer;
            return _characterLayer.value >> power == FirstBit;
        }
    }
}