using ApplicationEngine.GameCycle;
using Common.Entity;
using JetBrains.Annotations;
using Lean.Gui;
using UnityEngine;

namespace GameEngine.TransformFeature
{
    [UsedImplicitly]
    internal sealed class TransformController : IStartable, IFixedUpdatable
    {
        private readonly MovementComponent _movementComponent;
        private readonly ScaleComponent _scaleComponent;
        private readonly IJoystick _joystick;

        internal TransformController(IEntity entity, IJoystick joystick)
        {
            _movementComponent = entity.GetComponent<MovementComponent>();
            _scaleComponent = entity.GetComponent<ScaleComponent>();
            _joystick = joystick;
        }
        
        void IStartable.OnStart()
        {
            _scaleComponent.SetInitialScale();
        }

        void IFixedUpdatable.OnFixedUpdate()
        {
            Vector2 value = _joystick.Value;
            Vector3 movementDirection = new Vector3(value.x, 0, value.y); 
            
            // There is no need to normalize the movementDirection because LeanJoystick already provides normalized values
            _movementComponent.Move(movementDirection);
        }
    }
}