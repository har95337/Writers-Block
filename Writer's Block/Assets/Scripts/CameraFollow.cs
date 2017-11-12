using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;

    public float smoothSpeed = 0.1f;
    public Vector3 offset;
    public Vector3 velocity = Vector3.zero;
    void LateUpdate()
    {
		Vector3 desiredPos = player.position + offset;
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity,smoothSpeed);
		transform.position = player.position + offset;
    }
}
