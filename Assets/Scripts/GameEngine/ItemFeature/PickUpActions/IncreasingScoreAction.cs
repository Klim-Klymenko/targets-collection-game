using System;
using Common.Physics;
using GameEngine.Character;
using UnityEngine;
using Zenject;

namespace GameEngine.ItemFeature
{
    [Serializable]
    internal sealed class IncreasingScoreAction : IAction
    {
        [SerializeField]
        private int _increaseAmount;
        
        private ScoreCounter _scoreCounter;

        [Inject]
        internal void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }

        void IAction.Invoke()
        {
            _scoreCounter.AddScore(_increaseAmount);
        }
    }
}