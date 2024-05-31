using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LERP : MonoBehaviour
{
    public Transform targetDestination;
    public float speed;
    private Vector3 startPosition;
    private float startTime;

    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        float fractionOfJourney = (Time.time - startTime) * speed / Vector3.Distance(startPosition, targetDestination.position);
        transform.position = Vector3.Lerp(startPosition, targetDestination.position, fractionOfJourney);
        Debug.Log($"Speed: {speed}, Distance to target: {Vector3.Distance(transform.position, targetDestination.position)}");
    }
}
