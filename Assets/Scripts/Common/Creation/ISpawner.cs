using UnityEngine;

namespace Common.Creation
{
    public interface ISpawner<T> where T : Component
    {
        T Spawn();
        void Despawn(T obj);
    }
    
    public interface ISpawner<TR, in TArgs> where TR : Component
    {
        TR Spawn(TArgs args);
        void Despawn(TR obj);
    }
    
    public interface ISpawner<TR, in TArgs1, in TArgs2> where TR : Component
    {
        TR Spawn(TArgs1 args1, TArgs2 args2);
        void Despawn(TR obj);
    }
    
    public interface ISpawner<TR, in TArgs1, in TArgs2, in TArgs3> where TR : Component
    {
        TR Spawn(TArgs1 args1, TArgs2 args2, TArgs3 args3);
        void Despawn(TR obj);
    }
}