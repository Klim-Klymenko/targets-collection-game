using System;
using JetBrains.Annotations;

namespace GameEngine.Character
{
    [UsedImplicitly]
    public sealed class Score
    {
        public event Action<int> OnScoreChanged; 
        private int _score;
        
        public void Add(int value)
        {
            _score += value;
            OnScoreChanged?.Invoke(_score);
        }
        
        public int Get()
        {
            return _score;
        }
    }
}