using ApplicationEngine.GameCycle;
using JetBrains.Annotations;

namespace GameEngine.ItemFeature
{
    [UsedImplicitly]
    internal sealed class ItemDestructionObserver : IInitializable, IFinishable
    {
        private readonly ItemSpawner _spawner;
        private readonly ItemsCounter _counter;

        internal ItemDestructionObserver(ItemSpawner spawner, ItemsCounter counter)
        {
            _spawner = spawner;
            _counter = counter;
        }

        void IInitializable.OnInitialize()
        {
            _spawner.OnItemSpawned += IncrementItem;
            _spawner.OnItemDespawned += DecrementItem;
        }

        void IFinishable.OnFinish()
        {
            _spawner.OnItemSpawned -= IncrementItem;
            _spawner.OnItemDespawned -= DecrementItem;
        }

        private void IncrementItem()
        {
            _counter.IncrementItem();
        }
        
        private void DecrementItem()
        {
            _counter.DecrementItem();
        }
    }
}