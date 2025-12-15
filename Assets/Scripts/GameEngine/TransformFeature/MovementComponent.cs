using UnityEngine;

namespace GameEngine.TransformFeature
{
    public sealed class MovementComponent
    {
        private readonly Rigidbody _rigidbody;
        public float Speed { get; private set; }

        internal MovementComponent(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;
        }

        public void MultiplySpeed(float factor)
        {
            Speed *= factor;
        }

        public void DecreaseSpeed(float value)
        {
            Speed -= value;
        }
        
        internal void Move(Vector3 direction)
        {
            Vector3 nextPosition = _rigidbody.position + direction * (Speed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(nextPosition);
        }
    }
}