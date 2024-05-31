using UnityEngine;

public class MT : MonoBehaviour
{
    public Transform targetPos;
    public float speed;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        Debug.Log($"Speed: {speed}, Distance to Target: {Vector3.Distance(transform.position, targetPos.position)}");
    }
}
