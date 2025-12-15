using System;
using ApplicationEngine.GameCycle;
using Cysharp.Threading.Tasks;

namespace ApplicationEngine.Loading
{
    [Serializable]
    internal sealed class InstallGameCycleListenersLoadingTask : ILoadingTask
    {
        async UniTask ILoadingTask.Run(Blackboard loadingData)
        {
            const string gameCycleInstallerKey = nameof(GameCycleManagerInstaller);
            GameCycleManagerInstaller gameCycleManagerInstaller = loadingData.Get<GameCycleManagerInstaller>(gameCycleInstallerKey);
          
            gameCycleManagerInstaller.InstallListeners();
            await UniTask.CompletedTask;
        }
    }
}