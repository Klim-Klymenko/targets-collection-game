namespace ApplicationEngine.GameCycle
{
    public interface ILateUpdatable : IGameListener
    {
        void OnLateUpdate();
    }
}