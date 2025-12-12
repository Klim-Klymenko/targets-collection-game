using System;
using UnityEngine;

namespace Common.Time
{
    public sealed class Timer
    {
        public event Action<float> OnTimeChanged; 
        
        public float Progress => _currentTime / _delay;
        public float ElapsedTime => _currentTime;

        private const byte StartTime = 0;
        private float _currentTime;
        
        private readonly float _delay;
        
        public Timer(float delay)
        {
            _delay = delay;
            _currentTime = delay;
        }
        
        public void Tick(float deltaTime)
        {
            _currentTime = Mathf.Clamp(_currentTime + deltaTime, StartTime, _delay);
            OnTimeChanged?.Invoke(_currentTime);
        }

        public void Reset()
        {
            _currentTime = StartTime;
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