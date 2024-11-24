using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 0.125f;

    private void FixedUpdate()
    {
        Vector2 desiredPos = (Vector2)target.position;
        Vector2 smoothPos = Vector3.Lerp((Vector2)transform.position, desiredPos, smoothSpeed);
        transform.position = new Vector3(smoothPos.x, smoothPos.y, - 10);
    }
}
