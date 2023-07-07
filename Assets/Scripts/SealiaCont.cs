using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealiaCont : MonoBehaviour
{
    public Transform target;
    public float delay = 1f;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        targetPosition = target.position;
        targetPosition.z = -0.999f;
    }

    void Update()
    {
        targetPosition = Vector3.Lerp(targetPosition, target.position, Time.deltaTime / delay);
        targetPosition.z = -0.999f;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
    }

}
