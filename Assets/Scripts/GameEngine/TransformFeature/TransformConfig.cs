using UnityEngine;

namespace GameEngine.TransformFeature
{
    [CreateAssetMenu(fileName = "TransformConfig", menuName = "Configs/TransformConfig")]
    public sealed class TransformConfig : ScriptableObject
    {
        [field: SerializeField] 
        internal float MovementSpeed { get; private set; } = 5;
        
        [field: SerializeField]
        internal Vector3 Scale { get; private set; } = Vector3.one;
    }
}