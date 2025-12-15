using UnityEngine;

namespace GameEngine.ItemFeature
{
    [CreateAssetMenu(fileName = "ItemsSpawnConfig", menuName = "Configs/ItemsSpawnConfig")]
    internal sealed class ItemsSpawnConfig : ScriptableObject
    {
        [field: SerializeField]
        internal int ItemsCount { get; private set; }
        
        [field: SerializeField]
        internal Vector2 Area { get; private set; }
    }
}