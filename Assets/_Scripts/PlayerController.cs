using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController S;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float force = 20.0f;
    [SerializeField]
    private float moveForce = 20.0f;

    public float jetSpeed = 10.0f;
    public bool skiing = false;

    public PhysicMaterial zeroFriction;
    Collider col;

    [SerializeField]
    private float lookSensitivity = 3f;

    [SerializeField]
    private LayerMask environmentMask;

    public Rigidbody rb;

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
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, Vector3.down, out _hit, 100f, environmentMask))
        {
            // Possible keep momentum? Might not need raycasting.
        }

        //Calculate movement velocity as a 3D vector
        /*
        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        // Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical) * speed;

        //Apply movement
        //motor.Move(_velocity);

        if (Input.GetKey(KeyCode.W))
            ForceMove(transform.forward, force);
        //rb.AddForce(Camera.main.transform.forward * force);

        if (Input.GetKey(KeyCode.S))
            ForceMove(transform.forward, -force);

        if (Input.GetKey(KeyCode.D))
            ForceMove(transform.right, force);

        if (Input.GetKey(KeyCode.A))
            ForceMove(transform.right, -force);
        */
        // Smooth non direct velocity control
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(xinput, 0, zinput);

        rb.AddRelativeForce(input.normalized * moveForce, ForceMode.Acceleration);

        if (skiing)
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 95);
        else
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 90);

        if (input == Vector3.zero && skiing == false)
            rb.velocity = Vector3.MoveTowards(rb.velocity, new Vector3(0, rb.velocity.y, 0), Time.deltaTime * 100);

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
            //rb.velocity = new Vector3(rb.velocity.x, jetSpeed, rb.velocity.z);
            rb.AddRelativeForce(transform.up * 10, ForceMode.Acceleration);
        }

        // Ski code: become frictionless when you hold the space bar.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            col.material.dynamicFriction = 0;
            col.material.staticFriction = 0;

            skiing = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            col.material.dynamicFriction = 0.6f;
            col.material.staticFriction = 0.6f;

            skiing = false;
        }

        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
