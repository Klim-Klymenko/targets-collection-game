namespace ApplicationEngine.GameCycle
{
    public interface IInitializable : IGameListener
    {
        void OnInitialize();
    }
}