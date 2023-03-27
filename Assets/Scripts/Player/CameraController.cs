using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Rotates camera.
    /// </summary>
    /// <param name="rotation"></param>
    public void RotateCamera(Vector3 rotation)
    {
        transform.localEulerAngles = rotation;
    }
}
