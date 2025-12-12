using Cysharp.Threading.Tasks;

namespace ApplicationEngine.Loading
{
    internal interface ILoadingTask
    {
        UniTask Run(Blackboard loadingData);
    }
}