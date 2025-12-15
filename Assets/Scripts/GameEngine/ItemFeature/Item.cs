using UnityEngine;

namespace GameEngine.ItemFeature
{
    internal sealed class Item : MonoBehaviour
    {
        [field: SerializeField]
        internal string Id { get; private set; }

        private void Reset()
        {
            Id = name;
        }
    }
}