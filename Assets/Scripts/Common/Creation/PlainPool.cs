using ApplicationEngine.GameCycle;
using JetBrains.Annotations;
using Zenject;

namespace Common.Creation
{
    [UsedImplicitly]
    public sealed class PlainPool<T> : BasePool<T>
        where T : class
    {
        private readonly DiContainer _diContainer;
        private readonly GameCycleManager _gameCycleManager;

        public PlainPool(int poolSize, DiContainer diContainer, GameCycleManager gameCycleManager) : base(poolSize)
        {
            _diContainer = diContainer;
            _gameCycleManager = gameCycleManager;
            
            Reserve();
        }

        private protected override T Instantiate()
        {
            return _diContainer.Instantiate<T>();
        }

        private protected override void SetActive(T obj, bool active)
        {
            IGameListener listener = obj as IGameListener;
            
            if (active)
            {
                if (listener != null)
                    _gameCycleManager.AddListener(listener);
                
                return;
            }
            
            if (listener != null)
                _gameCycleManager.RemoveListener(listener);
        }
    }
}