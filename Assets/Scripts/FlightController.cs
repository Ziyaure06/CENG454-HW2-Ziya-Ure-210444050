using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 45f;
    [SerializeField] private float rollSpeed = 45f;
    [SerializeField] private float thrustSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        float pitchInput = 0f;
        if (Input.GetKey(KeyCode.E)) pitchInput = 1f;
        if (Input.GetKey(KeyCode.Q)) pitchInput = -1f;
        float pitchRotation = pitchInput * pitchSpeed * Time.deltaTime;

        float yawInput = Input.GetAxis("Horizontal");
        float yawRotation = yawInput * yawSpeed * Time.deltaTime;

        float rollInput = 0f;
        if (Input.GetKey(KeyCode.W)) rollInput = 1f;
        if (Input.GetKey(KeyCode.S)) rollInput = -1f;
        float rollRotation = rollInput * rollSpeed * Time.deltaTime;

        transform.Rotate(Vector3.right, pitchRotation);
        transform.Rotate(Vector3.up, yawRotation);
        transform.Rotate(Vector3.forward, rollRotation);
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.left * thrustSpeed * Time.deltaTime);
        }
    }
}