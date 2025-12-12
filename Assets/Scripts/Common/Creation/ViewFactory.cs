using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Common.Creation
{
    [UsedImplicitly]
    public sealed class ViewFactory<T> : IFactory<T>
        where T : Object
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly DiContainer _diContainer;
        private readonly bool _injectTypeOnly;

        public ViewFactory(T prefab, Transform parent, DiContainer diContainer)
        {
            _prefab = prefab;
            _parent = parent;
            _diContainer = diContainer;
        }

        T IFactory<T>.Create()
        {
            return _diContainer.InstantiatePrefabForComponent<T>(_prefab, _parent);
        }
    }
    
    [UsedImplicitly]
    public sealed class ViewFactory<T, TArgs> : IFactory<T, TArgs>
        where T : Object
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly DiContainer _diContainer;
        private readonly bool _injectTypeOnly;

        public ViewFactory(T prefab, Transform parent, DiContainer diContainer)
        {
            _prefab = prefab;
            _parent = parent;
            _diContainer = diContainer;
        }

        T IFactory<T, TArgs>.Create(TArgs args1)
        {
            object[] args = { args1 };
            return _diContainer.InstantiatePrefabForComponent<T>(_prefab, _parent, args);
        }
    }
    
    [UsedImplicitly]
    public sealed class ViewFactory<T, TArgs1, TArgs2> : IFactory<T, TArgs1, TArgs2>
        where T : Object
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly DiContainer _diContainer;

        public ViewFactory(T prefab, Transform parent, DiContainer diContainer)
        {
            _prefab = prefab;
            _parent = parent;
            _diContainer = diContainer;
        }

        T IFactory<T, TArgs1, TArgs2>.Create(TArgs1 args1, TArgs2 args2)
        {
            object[] args = { args1, args2 };
            return _diContainer.InstantiatePrefabForComponent<T>(_prefab, _parent, args);
        }
    }
}