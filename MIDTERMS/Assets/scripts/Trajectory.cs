using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private float speedMotion;
    [SerializeField] private float incline;
    [SerializeField] private float increment;
    [SerializeField] private LineRenderer path;
    [SerializeField] private Transform startPoint;
    [SerializeField] private TextMeshProUGUI congratsMessage;
    [SerializeField] private float congratsDisplayDuration = 2f;

    private void Start()
    {
        path.enabled = true;
        congratsMessage.gameObject.SetActive(false);
    }

    private void Update()
    {
        float angleInRadians = incline * Mathf.Deg2Rad;
        TrajectoryLine(speedMotion, angleInRadians, increment);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            StartCoroutine(ThrowPaper(speedMotion, angleInRadians));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ResetThrow();
        }

        HandleControls();
    }

    private void ResetThrow()
    {
        path.enabled = true;
        transform.position = startPoint.position;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void TrajectoryLine(float velocity, float angle, float step)
    {
        step = Mathf.Max(0.01f, step);
        float totalDuration = 10f;
        int positionCount = (int)(totalDuration / step) + 1;
        path.positionCount = positionCount;
        Vector3[] positions = new Vector3[positionCount];
        float time = 0f;

        for (int i = 0; i < positionCount; i++)
        {
            float x = velocity * time * Mathf.Cos(angle);
            float y = velocity * time * Mathf.Sin(angle) - 0.5f * Physics.gravity.magnitude * Mathf.Pow(time, 2);
            positions[i] = startPoint.position + new Vector3(x, y, 0);
            time += step;
        }
        path.SetPositions(positions);
    }

    private IEnumerator ThrowPaper(float velocity, float angle)
    {
        yield return null;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        float xVelocity = velocity * Mathf.Cos(angle);
        float yVelocity = velocity * Mathf.Sin(angle);
        rb.velocity = new Vector3(xVelocity, yVelocity, 0);
    }

    private void HandleControls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speedMotion += 6 * Time.deltaTime;
        }

        if (speedMotion > 20)
        {
            speedMotion = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            incline += 20 * Time.deltaTime;
        }

        if (incline > 88)
        {
            incline = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("score"))
        {
            StopAllCoroutines();
            Debug.Log("Point");
            InstantiateNewBall();
            StartCoroutine(ShowCongratsMessage());
        }

        if (collision.gameObject.CompareTag("Collidable"))
        {
            path.enabled = false;
        }
    }

    private IEnumerator ShowCongratsMessage()
    {
        congratsMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(congratsDisplayDuration);
        congratsMessage.gameObject.SetActive(false);
    }

    private void InstantiateNewBall()
    {
        GameObject newBall = Instantiate(gameObject, startPoint.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
