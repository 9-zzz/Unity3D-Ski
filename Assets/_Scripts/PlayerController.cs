using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController S;

    [SerializeField]
    private float speed = 5f;

    public float jetSpeed = 10.0f;
    public bool skiing = false;

    public PhysicMaterial zeroFriction;
    Collider col;

    [SerializeField]
    private float lookSensitivity = 3f;

    [SerializeField]
    private LayerMask environmentMask;

    Rigidbody rb;

    private PlayerMotor motor;

    void Awake()
    {
        S = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        /*
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, Vector3.down, out _hit, 100f, environmentMask))
        {
            // Possible keep momentum? Might not need raycasting.
        }
        */

        //Calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        // Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical) * speed;

        //Apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensitivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotationX);

        if (Input.GetMouseButton(1))
        {
            rb.velocity = new Vector3(rb.velocity.x, jetSpeed, rb.velocity.z);
        }

        // Ski code: become frictionless when you hold the space bar.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            col.material = zeroFriction;

            skiing = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            col.material = null;

            skiing = false;
        }

    }

}
