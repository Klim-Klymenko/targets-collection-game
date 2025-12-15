using System;
using ApplicationEngine.GameCycle;
using Cysharp.Threading.Tasks;

namespace ApplicationEngine.Loading
{
    [Serializable]
    internal sealed class RunGameCycleLoadingTask : ILoadingTask
    {
        async UniTask ILoadingTask.Run(Blackboard loadingData)
        {
            const string gameCycleKey = nameof(GameCycleManager);
            GameCycleManager gameCycleManager = loadingData.Get<GameCycleManager>(gameCycleKey);
            
            gameCycleManager.OnInitialize();
            gameCycleManager.OnStart();
            
            await UniTask.CompletedTask;
        }
    }
}