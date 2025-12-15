using System.Collections.Generic;
using Common.UI;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace ApplicationEngine.Loading
{
    [UsedImplicitly]
    internal sealed class InitializeUILoadingTask : ILoadingTask
    {
        private const string WindowShowersKey = "IReadOnlyList<IWindowShower>";
        private const string PopupShowersKey = "IReadOnlyList<IPopupShower>";
        
        async UniTask ILoadingTask.Run(Blackboard loadingData)
        {
            if (loadingData.TryGet(WindowShowersKey, out IReadOnlyList<IWindowShower> windowShowers))
            {
                for (int i = 0; i < windowShowers.Count; i++)
                {
                    windowShowers[i].Show();
                }
            }
            
            if (loadingData.TryGet(PopupShowersKey, out IReadOnlyList<IPopupShower> popupShowers))
            {
                for (int i = 0; i < popupShowers.Count; i++)
                {
                    popupShowers[i].Show();
                }
            }
            
            await UniTask.CompletedTask;
        }
    }
}