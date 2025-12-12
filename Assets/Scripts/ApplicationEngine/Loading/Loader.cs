using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace ApplicationEngine.Loading
{
    [UsedImplicitly]
    public sealed class Loader
    {
        public event Action OnLoadingStarted;
        public event Action<float> OnLoadingProgressed;
        public event Action OnLoadingFinished;

        private const byte ArrayIndexOffset = 1;
        
        private readonly Blackboard _loadingData;

        internal Loader(Blackboard loadingData)
        {
            _loadingData = loadingData;
        }
        
        internal async UniTaskVoid Load(LoadingPipeline loadingPipeline)
        {
            IReadOnlyList<ILoadingTask> loadingTasks = loadingPipeline.LoadingTasks;
            int tasksCount = loadingTasks.Count;
            
            OnLoadingStarted?.Invoke();
            
            for (int i = 0; i < tasksCount; i++)
            {
                await loadingTasks[i].Run(_loadingData);

                float progress = (float) (i + ArrayIndexOffset) / tasksCount;
                OnLoadingProgressed?.Invoke(progress);
            }
            
            OnLoadingFinished?.Invoke();
        }
    }
}