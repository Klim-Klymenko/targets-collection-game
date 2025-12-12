using System.Collections.Generic;
using JetBrains.Annotations;

namespace ApplicationEngine.Loading
{
    [UsedImplicitly]
    internal sealed class Blackboard
    {
        private readonly Dictionary<string, object> _values;

        internal Blackboard(Dictionary<string, object> values)
        {
            _values = values;
        }

        internal Blackboard()
        {
            _values = new Dictionary<string, object>();
        }
        
        internal void Add(string key, object value)
        {
            _values.Add(key, value);
        }
        
        internal bool TryAdd(string key, object value)
        {
            return _values.TryAdd(key, value);
        }
        
        internal void Remove(string key)
        {
            _values.Remove(key);
        }
        
        internal bool TryRemove(string key)
        {
            return _values.Remove(key);
        }
        
        internal void Set(string key, object value)
        {
            _values[key] = value;
        }
        
        internal T Get<T>(string key)
        {
            return (T) _values[key];
        }
        
        internal bool TryGet<T>(string key, out T value)
        {
            if (_values.TryGetValue(key, out object data))
            {
                value = (T) data;
                return true;
            }

            value = default;
            return false;
        }

        internal bool Has(string key)
        {
            return _values.ContainsKey(key);
        }
    }
}