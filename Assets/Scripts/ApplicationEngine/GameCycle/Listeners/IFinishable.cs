namespace ApplicationEngine.GameCycle
{
    public interface IFinishable : IGameListener
    {
        void OnFinish();
    }
}