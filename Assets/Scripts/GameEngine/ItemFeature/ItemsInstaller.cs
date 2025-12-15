using System.Collections.Generic;
using Common.Creation;
using Common.Time;
using UnityEngine;
using Zenject;

namespace GameEngine.ItemFeature
{
    internal sealed class ItemsInstaller : MonoInstaller
    {
        [SerializeField] 
        private SceneContext _sceneContext;
        
        [SerializeField] 
        private ItemsSpawnConfig _config;
        
        [SerializeField]
        private Transform _characterTransform;
        
        [SerializeField]
        private Item[] _itemPrefabs;
        
        [SerializeField]
        private Transform _itemsContainer;
        
        private IReadOnlyList<ObjectPool<Item>> _pools;
        
        public override void InstallBindings()
        {
            BindCounter();
            BindSpawner();
            BindObserver();
            BindControllers();
            
            _sceneContext.PostResolve += ReservePools;
        }

        private void BindCounter()
        {
            Container.Bind<ItemsCounter>().AsSingle();
        }
        
        private void BindSpawner()
        {
            int itemTypesCount = _itemPrefabs.Length;
            
            ObjectPool<Item>[] pools = new ObjectPool<Item>[itemTypesCount];
            Dictionary<string, IPool<Item>> poolsMap = new();
            
            for (int i = 0; i < itemTypesCount; i++)
            {
                Item prefab = _itemPrefabs[i];
                string prefabId = prefab.Id;
                
                // Manually calling Reserve() of pool allows to avoid the exception for Item's physics actions which requite 
                // dependencies in the Zenject's IoC. Otherwise, there will be an exception because Items are being created 
                // earlier, than needed dependencies for their actions get to the container
                ObjectPool<Item> pool = new(_config.ItemsCount, 
                    prefab, _itemsContainer, Container, manualReserve: true);
                
                pools[i] = pool;
                poolsMap.Add(prefabId, pool);
            }
            
            _pools = pools;
            
            Vector3 itemLocalScale = _itemsContainer.localScale;
            Vector2 itemScale = new Vector2(itemLocalScale.x, itemLocalScale.z);
            
            IReadOnlyList<IPool<Item>> castedPools = _pools;
            IReadOnlyDictionary<string, IPool<Item>> castedPoolsMap = poolsMap;
            
            Container.BindInterfacesAndSelfTo<ItemSpawner>().AsSingle()
                .WithArguments(castedPools, castedPoolsMap, _config.Area, itemScale);
        }

        private void BindObserver()
        {
            Container.BindInterfacesTo<ItemDestructionObserver>().AsCached();
        }

        private void BindControllers()
        {
            Container.BindInterfacesTo<ItemsSpawnController>().AsCached().WithArguments(_config.ItemsCount);

            Timer timer = new();
            Container.BindInterfacesAndSelfTo<MovementSpeedTimeController>().AsSingle().WithArguments(timer);
        }

        private void ReservePools()
        {
            for (int i = 0; i < _itemPrefabs.Length; i++)
            {
                _pools[i].Reserve();
            }
            
            _sceneContext.PostResolve -= ReservePools;
        }
    }
}