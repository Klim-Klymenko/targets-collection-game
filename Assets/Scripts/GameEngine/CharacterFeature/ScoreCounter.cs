using System;
using JetBrains.Annotations;

namespace GameEngine.Character
{
    [UsedImplicitly]
    public sealed class ScoreCounter
    {
        public event Action<int> OnScoreChanged; 
        public int Score { get; private set; }
        
        public void AddScore(int value)
        {
            Score += value;
            OnScoreChanged?.Invoke(Score);
        }
    }
}