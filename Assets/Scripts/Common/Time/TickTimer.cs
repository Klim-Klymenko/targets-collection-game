using System;
using ApplicationEngine.GameCycle;

namespace Common.Time
{
    public sealed class TickTimer : IUpdatable
    {
        public event Action<float> OnTimeChanged; 
        public float ElapsedTime { get; private set; }

        void IUpdatable.OnUpdate()
        {
            ElapsedTime += UnityEngine.Time.deltaTime;
            OnTimeChanged?.Invoke(ElapsedTime);
        }

        public void Reset()
        {
            ElapsedTime = 0;
        }
    }
}