using UnityEngine;

namespace GameEngine.CameraFeature
{
    internal sealed class CameraFollowingComponent
    {
        private Vector3 _offset;
        
        private readonly Transform _cameraTransform;
        private readonly Transform _targetTransform;
        private readonly float _followingStep;
        
        internal CameraFollowingComponent(Transform cameraTransform, Transform targetTransform, float followingStep)
        {
            _cameraTransform = cameraTransform;
            _targetTransform = targetTransform;
            _followingStep = followingStep;
        }
        
        internal void CalculateOffset()
        {
            _offset = _cameraTransform.position - _targetTransform.position;
        }
        
        internal void FollowTarget()
        {
            Vector3 targetPosition = _targetTransform.position;
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, targetPosition + _offset, _followingStep);
        }
    }
}