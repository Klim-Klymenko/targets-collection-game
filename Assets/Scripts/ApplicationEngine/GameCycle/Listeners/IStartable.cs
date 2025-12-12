namespace ApplicationEngine.GameCycle
{
    public interface IStartable : IGameListener
    {
        void OnStart();
    }
}