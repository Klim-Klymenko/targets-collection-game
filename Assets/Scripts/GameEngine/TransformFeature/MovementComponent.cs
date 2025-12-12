using UnityEngine;

namespace GameEngine.TransformFeature
{
    public sealed class MovementComponent
    {
        private readonly Rigidbody _rigidbody;
        private float _speed;

        internal MovementComponent(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
        
        internal void Move(Vector3 direction)
        {
            Vector3 nextPosition = _rigidbody.position + direction * (_speed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(nextPosition);
        }
    }
}