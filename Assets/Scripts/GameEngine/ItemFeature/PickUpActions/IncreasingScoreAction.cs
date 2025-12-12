using System;
using Common.Physics;
using GameEngine.Character;
using UnityEngine;

namespace GameEngine.ItemFeature
{
    [Serializable]
    internal sealed class IncreasingScoreAction : IColliderAction
    {
        [SerializeField]
        private int _increaseAmount = 1;
        
        private Score _score;

        internal void Construct(Score score)
        {
            _score = score;
        }
        
        void IAction<Collider>.Invoke(Collider _)
        {
            _score.Add(_increaseAmount);
        }
    }
}