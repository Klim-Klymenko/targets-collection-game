using System;
using Common.Creation;
using Common.Physics;
using UnityEngine;
using Zenject;

namespace GameEngine.ItemFeature
{
    [Serializable]
    internal sealed class DestroyingItemAction : IAction
    {
        [SerializeField]
        private Item _item;
        
        private ISpawner<Item> _spawner;
        
        [Inject]
        internal void Construct(ISpawner<Item> spawner)
        {
            _spawner = spawner;
        }
        
        void IAction.Invoke()
        {
            _spawner.Despawn(_item);
        }
    }
}