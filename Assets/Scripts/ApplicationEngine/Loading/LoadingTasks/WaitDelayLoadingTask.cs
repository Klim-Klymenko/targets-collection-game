using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ApplicationEngine.Loading
{
    [Serializable]
    internal sealed class WaitDelayLoadingTask : ILoadingTask
    {
        [SerializeField]
        private float _delay = 0.15f;
        
        private const short MillisecondsInSecond = 1000;
        
        async UniTask ILoadingTask.Run(Blackboard loadingData)
        {
            await UniTask.Delay((int) (_delay * MillisecondsInSecond));
        }
    }
}