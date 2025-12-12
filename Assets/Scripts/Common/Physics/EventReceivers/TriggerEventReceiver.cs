using UnityEngine;

namespace Common.Physics
{
    internal sealed class TriggerEventReceiver : EventReceiver<Collider, IColliderCondition, IColliderAction>
    {
        private void OnTriggerEnter(Collider other)
        {
            OnEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnExit(other);
        }
    }
}