using UnityEngine;

namespace Common.Physics
{
    internal sealed class CollisionEventReceiver : EventReceiver<Collision, ICollisionCondition, ICollisionAction>
    {
        private void OnCollisionEnter(Collision collision)
        {
            OnEnter(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            OnStay(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            OnExit(collision);
        }
    }
}