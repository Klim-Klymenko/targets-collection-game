using UnityEngine;

namespace GameEngine.TransformFeature
{
    public sealed class ScaleComponent
    {
       private readonly Transform _transform;
       private readonly Vector3 _initialScale;

       internal ScaleComponent(Transform transform, Vector3 initialScale)
       {
           _transform = transform;
           _initialScale = initialScale;
       }

       internal void SetInitialScale()
       {
           _transform.localScale = _initialScale;
       }

       public void MultiplyScale(float factor)
       {
           _transform.localScale *= factor;
       }
    }
}