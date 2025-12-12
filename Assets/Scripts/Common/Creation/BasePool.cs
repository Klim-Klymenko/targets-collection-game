using System.Collections.Generic;

namespace Common.Creation
{
    public abstract class BasePool<T> : IPool<T>
        where T : class
    {
        private readonly List<T> _objects = new();
        private readonly int _poolSize;

        private protected BasePool(int poolSize)
        {
            _poolSize = poolSize;
        }

        private protected void Reserve()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                T obj = Instantiate();
                
                _objects.Add(obj);
                SetActive(obj, false);
            }
        }

        public T Get()
        {
            T obj = _objects.Count > 0 ? _objects[^1] : Instantiate();
            
            SetActive(obj, true);
            _objects.Remove(obj);
            
            return obj;
        }

        public void Put(T obj)
        {
            SetActive(obj, false);
            _objects.Add(obj);
            
            OnObjectPut(obj);
        }

        private protected abstract T Instantiate();

        private protected abstract void SetActive(T obj, bool active);

        private protected virtual void OnObjectPut(T obj) { }
    }
}