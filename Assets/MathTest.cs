using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTest : MonoBehaviour
{
    public float magnitude, speed;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, PingPongAmount(), 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(startPos, 0.25f);
    }

    public float PingPongAmount()
    {
        return Mathf.PingPong(Time.time * speed, magnitude);
    }

    public float SineAmount()
    {
        return Mathf.Sin(Time.time * speed);
    }

    //Vector3.lerp
    //Vector3.MoveTowards
}
