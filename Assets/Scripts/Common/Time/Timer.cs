using System;
using UnityEngine;
using Zenject;

namespace Common.Time
{
    public sealed class Timer
    {
        public event Action<float> OnTimeChanged; 
        
        public float Progress => _currentTime / _delay;
        public float ElapsedTime => _currentTime;

        private const byte StartTime = 0;
        private float _currentTime;
        
        private float _delay;
        
        [Inject]
        public Timer(float delay)
        {
            _delay = delay;
            _currentTime = delay;
        }

        public Timer() { }

        public void Tick(float deltaTime)
        {
            _currentTime = Mathf.Clamp(_currentTime + deltaTime, StartTime, _delay);
            OnTimeChanged?.Invoke(_currentTime);
        }

        public void Reset()
        {
            _currentTime = StartTime;
        }
        
        public void SetDelay(float delay)
        {
            _delay = delay;
        }
        
        public void SetDelayAndReset(float delay)
        {
            _delay = delay;
            Reset();
        }
        
        public void SetMax()
        {
            _currentTime = _delay;
        }
        
        public bool IsPlaying()
        {
            return _currentTime < _delay;
        }

        public bool IsFinished()
        {
            return _currentTime >= _delay;
        }
    }
}