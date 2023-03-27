using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private float _velocity;
    /// <summary>
    /// Moves player in the given direction.
    /// </summary>
    /// <param name="direction"></param>
    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_velocity * Time.deltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }
    /// <summary>
    /// Rotates player by the given quaternion.
    /// </summary>
    /// <param name="rotation"></param>
    public void Rotate(Quaternion rotation)
    {
       
    }
}
