namespace ApplicationEngine.GameCycle
{
    public interface IUpdatable : IGameListener
    {
        void OnUpdate();
    }
}