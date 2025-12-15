using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Entity
{
    public sealed class Entity : MonoBehaviour, IEntity
    {
        private readonly Dictionary<Type, object> _components = new();

        public void AddComponent<T>(T component) where T : class
        {
            Type componentType = typeof(T);
            _components.Add(componentType, component);
        }

        public bool TryAddComponent<T>(T component) where T : class
        {
            if (!HasComponent<T>())
                return false;

            AddComponent(component);
            return true;
        }

        public void RemoveComponent<T>() where T : class
        {
            Type componentType = typeof(T);
            _components.Remove(componentType);
        }

        public bool TryRemoveComponent<T>() where T : class
        {
            if (!HasComponent<T>())
                return false;

            RemoveComponent<T>();
            return true;
        }

        public T GetComponent<T>() where T : class
        {
            Type componentType = typeof(T);
            return (T)_components[componentType];
        }

        public bool TryGetComponent<T>(out T component) where T : class
        {
            Type componentType = typeof(T);

            if (_components.TryGetValue(componentType, out object componentObj))
            {
                component = (T)componentObj;
                return true;
            }

            component = default;
            return false;
        }

        public bool HasComponent<T>() where T : class
        {
            Type componentType = typeof(T);
            return _components.TryGetValue(componentType, out _);
        }
    }
}