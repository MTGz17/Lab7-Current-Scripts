using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float FollowSpeed = 3f;
    public Transform target;
    

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, 20f, target.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
