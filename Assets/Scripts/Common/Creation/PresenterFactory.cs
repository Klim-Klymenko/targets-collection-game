using ApplicationEngine.GameCycle;
using JetBrains.Annotations;
using Zenject;

namespace Common.Creation
{
    [UsedImplicitly]
    public sealed class PresenterFactory<T> : IFactory<T>
    where T : class
    {
        private readonly GameCycleManager _gameCycleManager;
        private readonly DiContainer _diContainer;

        public PresenterFactory(GameCycleManager gameCycleManager, DiContainer diContainer)
        {
            _gameCycleManager = gameCycleManager;
            _diContainer = diContainer;
        }

        T IFactory<T>.Create()
        {
            T presenter = _diContainer.Instantiate<T>();
            
            if (presenter is IGameListener gameListener)
                _gameCycleManager.AddListener(gameListener);

            return presenter;
        }
    }
    
    [UsedImplicitly]
    public sealed class PresenterFactory<T, TArgs1> : IFactory<T, TArgs1>
        where T : class
    {
        private readonly GameCycleManager _gameCycleManager;
        private readonly DiContainer _diContainer;

        public PresenterFactory(GameCycleManager gameCycleManager, DiContainer diContainer)
        {
            _gameCycleManager = gameCycleManager;
            _diContainer = diContainer;
        }

        T IFactory<T, TArgs1>.Create(TArgs1 args1)
        {
            object[] args = { args1 };
            
            T presenter = _diContainer.Instantiate<T>(args);
            
            if (presenter is IGameListener gameListener)
                _gameCycleManager.AddListener(gameListener);

            return presenter;
        }
    }
    
    [UsedImplicitly]
    public sealed class PresenterFactory<T, TArgs1, TArgs2> : IFactory<T, TArgs1, TArgs2>
        where T : class
    {
        private readonly GameCycleManager _gameCycleManager;
        private readonly DiContainer _diContainer;

        public PresenterFactory(GameCycleManager gameCycleManager, DiContainer diContainer)
        {
            _gameCycleManager = gameCycleManager;
            _diContainer = diContainer;
        }

        T IFactory<T, TArgs1, TArgs2>.Create(TArgs1 args1, TArgs2 args2)
        {
            object[] args = { args1, args2 };
            
            T presenter = _diContainer.Instantiate<T>(args);
            
            if (presenter is IGameListener gameListener)
                _gameCycleManager.AddListener(gameListener);

            return presenter;
        }
    }
}