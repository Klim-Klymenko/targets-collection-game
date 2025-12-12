using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ApplicationEngine.Loading
{
    internal sealed class LoadingInstaller : MonoInstaller
    {
        [SerializeField]
        private LoadingRunner _loadingRunner;

        [SerializeField]
        private LoadableScenes[] _loadableScenes;

        [SerializeField] 
        private LoadingPipeline[] _loadingPipelines;
        
        public override void InstallBindings()
        {
            BindBlackboard();
            BindLoader();
            BindLoadingRunner();
        }

        private void BindBlackboard()
        {
            Container.Bind<Blackboard>().AsSingle();
        }
        
        private void BindLoader()
        {
            Container.Bind<Loader>().AsSingle();
        }
        
        private void BindLoadingRunner()
        {
            Dictionary<LoadableScenes, LoadingPipeline> loadingPipelines = new();

            for (int i = 0; i < _loadableScenes.Length; i++)
            {
                loadingPipelines.Add(_loadableScenes[i], _loadingPipelines[i]);
            }

            Container.Bind<IReadOnlyDictionary<LoadableScenes, LoadingPipeline>>().FromInstance(loadingPipelines).AsSingle();
            Container.Bind<LoadingRunner>().FromInstance(_loadingRunner).AsSingle();
        }
    }
}