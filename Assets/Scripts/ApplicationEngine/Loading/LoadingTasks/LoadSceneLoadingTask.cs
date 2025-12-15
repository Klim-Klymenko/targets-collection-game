using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ApplicationEngine.Loading
{
    [Serializable]
    internal sealed class LoadSceneLoadingTask : ILoadingTask
    {
        [SerializeField] 
        private LoadableScenes _scene;
        
        async UniTask ILoadingTask.Run(Blackboard loadingData)
        {
            await SceneManager.LoadSceneAsync(_scene.ToString());
        }
    }
}