namespace ApplicationEngine.GameCycle
{
    public interface IFixedUpdatable : IGameListener
    {
        void OnFixedUpdate();
    }
}