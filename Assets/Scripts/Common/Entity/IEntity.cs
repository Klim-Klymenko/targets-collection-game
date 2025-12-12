namespace Common.Entity
{
    public interface IEntity
    {
        void AddComponent<T>(T component) where T : class;
        bool TryAddComponent<T>(T component) where T : class;
        void RemoveComponent<T>() where T : class;
        bool TryRemoveComponent<T>() where T : class;
        T GetComponent<T>() where T : class;
        bool TryGetComponent<T>(out T component) where T : class;
        bool HasComponent<T>() where T : class;
    }
}