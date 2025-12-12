using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Common.Creation
{
    [UsedImplicitly]
    public sealed class ObjectPool<T> : BasePool<T>
        where T : Component
    {
        private readonly DiContainer _diContainer;
        private readonly T _prefab;
        private readonly Transform _parent;
        
        public ObjectPool(int poolSize, T prefab, Transform parent, DiContainer diContainer) : base(poolSize)
        {
            _diContainer = diContainer;
            _prefab = prefab;
            _parent = parent;
            
            Reserve();
        }

        private protected override T Instantiate()
        {
            return _diContainer.InstantiatePrefabForComponent<T>(_prefab, _parent);
        }

        private protected override void SetActive(T obj, bool active)
        {
            obj.gameObject.SetActive(active);
        }

        private protected override void OnObjectPut(T obj)
        {
            if (_parent != null && obj.transform.parent != _parent)
                obj.transform.SetParent(_parent);
        }
    }
}