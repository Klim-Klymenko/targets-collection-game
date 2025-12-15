using System;
using System.Collections.Generic;
using Common.Creation;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameEngine.ItemFeature
{
    [UsedImplicitly]
    internal sealed class ItemSpawner : ISpawner<Item>
    {
        internal event Action OnItemSpawned;
        internal event Action OnItemDespawned;
        
        private readonly List<Vector2> _occupiedPositions = new();
        
        private readonly IReadOnlyList<IPool<Item>> _pools;
        private readonly IReadOnlyDictionary<string, IPool<Item>> _poolsMap;
        private readonly Vector2 _spawnArea;
        private readonly Vector2 _itemScale;
    
        internal ItemSpawner(IReadOnlyList<IPool<Item>> pools, IReadOnlyDictionary<string, IPool<Item>> poolsMap,
            Vector2 spawnArea, Vector2 itemScale)
        {
            _pools = pools;
            _poolsMap = poolsMap;
            _spawnArea = spawnArea;
            _itemScale = itemScale;
        }

        Item ISpawner<Item>.Spawn()
        {
            int randomIndex = Random.Range(0, _pools.Count);
            IPool<Item> randomPool = _pools[randomIndex];
                
            Item item = randomPool.Get();
            Transform itemTransform = item.transform;
                
            Vector2 randomPosition = GenerateRandomPosition();
                
            for (int i = 0; i < _occupiedPositions.Count; i++)
            {
                Vector2 occupiedPosition = _occupiedPositions[i];
                    
                OccupiedPositionRange range = new(minX: occupiedPosition.x - _itemScale.x, maxX: occupiedPosition.x + _itemScale.x,
                    minY: occupiedPosition.y - _itemScale.y, maxY: occupiedPosition.y + _itemScale.y);

                if ((randomPosition.x >= range.MinX && randomPosition.x <= range.MaxX) &&
                       (randomPosition.y >= range.MinY && randomPosition.y <= range.MaxY))
                {
                    randomPosition = GenerateRandomPosition();
                    i = 0;
                }
            }
                
            itemTransform.position = new Vector3(randomPosition.x, 0, randomPosition.y);
            _occupiedPositions.Add(randomPosition);
                
            OnItemSpawned?.Invoke();
            return item;
        }

        void ISpawner<Item>.Despawn(Item item)
        {
            string itemId = item.Id;
            IPool<Item> pool = _poolsMap[itemId];
            
            pool.Put(item);
            OnItemDespawned?.Invoke();
        }

        private Vector2 GenerateRandomPosition()
        {
            return Random.insideUnitCircle * (_spawnArea / 2);
        }
    }
}