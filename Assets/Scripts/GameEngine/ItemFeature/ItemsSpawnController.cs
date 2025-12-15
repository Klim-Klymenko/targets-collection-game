using ApplicationEngine.GameCycle;
using Common.Creation;
using JetBrains.Annotations;

namespace GameEngine.ItemFeature
{
    [UsedImplicitly]
    internal sealed class ItemsSpawnController : IStartable
    {
        private readonly int _itemsSpawnCount;
        private readonly ISpawner<Item> _spawner;

        internal ItemsSpawnController(int itemsSpawnCount, ISpawner<Item> spawner)
        {
            _itemsSpawnCount = itemsSpawnCount;
            _spawner = spawner;
        }

        void IStartable.OnStart()
        {
            for (int i = 0; i < _itemsSpawnCount; i++)
            {
                _spawner.Spawn();
            }
        }
    }
}