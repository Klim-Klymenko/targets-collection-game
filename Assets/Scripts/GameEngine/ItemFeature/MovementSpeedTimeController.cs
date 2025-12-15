using ApplicationEngine.GameCycle;
using Common.Time;
using GameEngine.TransformFeature;
using JetBrains.Annotations;
using UnityEngine;

namespace GameEngine.ItemFeature
{
    [UsedImplicitly]
    internal sealed class MovementSpeedTimeController : IUpdatable
    {
        private bool _isTicking;

        private float _initialSpeed;
        private float _speedIncreaseFactor;
        private MovementComponent _component;
        
        private readonly Timer _timer;

        internal MovementSpeedTimeController(Timer timer)
        {
            _timer = timer;
        }

        void IUpdatable.OnUpdate()
        {
            if (!_isTicking) 
                return;
            
            if (_timer.IsFinished())
            {
                float currentSpeed = _component.Speed;
                
                if (currentSpeed > _initialSpeed)
                {
                    float speedDifference = _component.Speed - _initialSpeed;
                    _component.DecreaseSpeed(speedDifference);
                }
                else
                {
                    float reciprocal = 1 / _speedIncreaseFactor;
                    _component.MultiplySpeed(reciprocal);
                }
                
                _isTicking = false;
                return;
            }
                
            _timer.Tick(Time.deltaTime);
        }
        
        internal void TemporaryMultiplySpeed(float duration, float speedIncreasingFactor, MovementComponent component)
        {
            component.MultiplySpeed(speedIncreasingFactor);
            _timer.SetDelayAndReset(duration);
            
            _component = component;
            _speedIncreaseFactor = speedIncreasingFactor;
            _initialSpeed = component.Speed;
            _isTicking = true;
        }
    }
}