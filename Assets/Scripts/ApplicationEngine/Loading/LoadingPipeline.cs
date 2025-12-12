using System.Collections.Generic;
using UnityEngine;

namespace ApplicationEngine.Loading
{
    [CreateAssetMenu(fileName = "LoadingPipeline", menuName = "Configs/Loading/LoadingPipeline")]
    internal sealed class LoadingPipeline : ScriptableObject
    {
        internal IReadOnlyList<ILoadingTask> LoadingTasks => _loadingTasks;

        [SerializeReference] 
        private ILoadingTask[] _loadingTasks;
    }
}