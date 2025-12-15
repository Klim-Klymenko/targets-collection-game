using ApplicationEngine.GameCycle;
using Common.Entity;
using JetBrains.Annotations;

namespace GameEngine.CameraFeature
{
    [UsedImplicitly]
    internal sealed class CameraController : IStartable, IFixedUpdatable
    {
        private readonly CameraFollowingComponent _followingComponent;

        internal CameraController(IEntity entity)
        {
            _followingComponent = entity.GetComponent<CameraFollowingComponent>();
        }
        
        void IStartable.OnStart()
        {
            _followingComponent.CalculateOffset();
        }

        void IFixedUpdatable.OnFixedUpdate()
        {
            _followingComponent.FollowTarget();
        }
    }
}