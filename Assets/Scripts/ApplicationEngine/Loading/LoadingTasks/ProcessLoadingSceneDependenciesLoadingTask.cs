using System;
using System.Collections.Generic;
using ApplicationEngine.GameCycle;
using Common.UI;
using Cysharp.Threading.Tasks;
using Zenject;

namespace ApplicationEngine.Loading
{
    [Serializable]
    internal sealed class ProcessLoadingSceneDependenciesLoadingTask : ILoadingTask
    {
        private const string WidgetShowersKey = "IReadOnlyList<IWindowShower>";
        private const string PopupShowersKey = "IReadOnlyList<IPopupShower>";
        
        async UniTask ILoadingTask.Run(Blackboard loadingData)
        {
            SceneContext sceneContext = UnityEngine.Object.FindFirstObjectByType<SceneContext>();
            DiContainer diContainer = sceneContext.Container;
            
            IReadOnlyList<IWindowShower> widgetShowers = diContainer.Resolve<IWindowShower[]>();
            IReadOnlyList<IPopupShower> popupShowers = diContainer.Resolve<IPopupShower[]>();
           
            GameCycleManager gameCycleManager = diContainer.Resolve<GameCycleManager>();
            GameCycleManagerInstaller gameCycleManagerInstaller = diContainer.Resolve<GameCycleManagerInstaller>();
            
            const string diContainerKey = nameof(DiContainer);
            loadingData.Set(diContainerKey, diContainer);
            
            if (widgetShowers != null && widgetShowers.Count > 0)
                loadingData.Set(WidgetShowersKey, widgetShowers);
            
            if (popupShowers != null &&  popupShowers.Count > 0)
                loadingData.Set(PopupShowersKey, popupShowers);
            
            const string gameCycleKey = nameof(GameCycleManager);
            loadingData.Set(gameCycleKey, gameCycleManager);
            
            const string gameCycleInstallerKey = nameof(GameCycleManagerInstaller);
            loadingData.Set(gameCycleInstallerKey, gameCycleManagerInstaller);
           
            if (widgetShowers == null || widgetShowers.Count == 0)
                loadingData.TryRemove(WidgetShowersKey);
         
            if (popupShowers == null || popupShowers.Count == 0)
                loadingData.TryRemove(PopupShowersKey);
            
            await UniTask.CompletedTask;
        }
    }
}