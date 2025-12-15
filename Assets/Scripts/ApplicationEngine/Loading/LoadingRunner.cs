using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace ApplicationEngine.Loading
{
    public sealed class LoadingRunner : MonoBehaviour
    {
        private const string EditorMenuLoadingPipelinePath = "MenuEditorLoadingPipeline";
        private const string EditorLevelLoadingPipelinePath = "LevelEditorLoadingPipeline";

        private const string MenuScenePrefix = "Menu";
        private const string MainScenePostfix = "Main";
        
        private LoadableScenes _currentScene;
        
        private IReadOnlyDictionary<LoadableScenes, LoadingPipeline> _loadingPipelines;
        private Loader _loader;
        
        [Inject]
        internal void Construct(IReadOnlyDictionary<LoadableScenes, LoadingPipeline> loadingPipelines, Loader loader)
        {
            _loadingPipelines = loadingPipelines;
            _loader = loader;
        }
        
        private void Start()
        {
#if UNITY_EDITOR
            string sceneName = SceneManager.GetActiveScene().name;
            
            string path = sceneName.Contains(MenuScenePrefix) ? EditorMenuLoadingPipelinePath
                : sceneName.StartsWith(MainScenePostfix) ? EditorLevelLoadingPipelinePath 
                : string.Empty;

            if (!string.IsNullOrEmpty(path))
            {
                LoadingPipeline loadingPipeline = Resources.Load<LoadingPipeline>(path);
                _loader.Load(loadingPipeline).Forget();
                
                _currentScene = Enum.Parse<LoadableScenes>(sceneName);
                return;
            }
#endif
            RunLoading(LoadableScenes.MenuScene);
        }

        public void RunLoading(LoadableScenes loadingScene)
        {
            _currentScene = loadingScene;
            
            LoadingPipeline loadingPipeline = _loadingPipelines[loadingScene];
            _loader.Load(loadingPipeline).Forget();
        }
        
        public void ReloadScene()
        {
            RunLoading(_currentScene);
        }
    }
}