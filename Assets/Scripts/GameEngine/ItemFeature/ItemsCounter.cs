using System;
using JetBrains.Annotations;

namespace GameEngine.ItemFeature
{
    [UsedImplicitly]
    public sealed class ItemsCounter
    {
        public event Action OnItemsRunOut;
        public int Count { get; private set; }

        internal void IncrementItem()
        {
            Count++;
        }

        internal void DecrementItem()
        {
            Count--;

            if (Count <= 0) 
                OnItemsRunOut?.Invoke();
        }
    }
}