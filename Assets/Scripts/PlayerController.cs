using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Physics")] public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float accelTimeFlying = .4f;
    public float accelTimeAir = .2f;
    public float accelTimeGround = .1f;
    public float moveSpeed = 6;
    public float moveSpeedFlying = 16;

    public Vector2 maxSpeed;

    private float _gravity;
    private float _jumpVelocity;

    public Vector2 velocity;
    public float velocityXSmoothing;
    public float velocityYSmoothing;

    private Controller2D _controller;
    [SerializeField] private Vector2 input;

    private float _targetVelocityX;

    private float _targetVelocityFlyingX;
    private float _targetVelocityFlyingY;

    private Quaternion _oldRotation;

    [Header("Camera")] public Camera cam;
    public float camSpeed = .6f;


    private PlayerInput _playerInput;

    private void Awake()
    {
        _controller = GetComponent<Controller2D>();
    }



    private void Start()
    {
        _gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        _jumpVelocity = Mathf.Abs(_gravity * timeToJumpApex);
        _playerInput = new PlayerInput();
        cam = Camera.main;
        _playerInput = InputManager.PlayerInput;

    }

    private void FixedUpdate()
    {


        //Update Settings When Changed In Scene Editor
        _gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        _jumpVelocity = Mathf.Abs(_gravity * timeToJumpApex);

        UpdatePhysics();

        UpdateCamera();
    }

    private void UpdatePhysics()
    {

        input = _playerInput.Movement;

        if (_playerInput.JumpPressed && _controller.collisions.Below)
        {
            velocity.y = _jumpVelocity;
        }

        _targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, _targetVelocityX, ref velocityXSmoothing,
            (_controller.collisions.Below) ? accelTimeGround : accelTimeAir);
        velocity.y += _gravity * Time.fixedDeltaTime;


        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed.x, maxSpeed.x);
        velocity.y = Mathf.Clamp(velocity.y, -maxSpeed.y, maxSpeed.y);

        _controller.Move(velocity * Time.fixedDeltaTime);

        if (_controller.collisions.Above || _controller.collisions.Below)
        {
            velocity.y = 0;
        }

        if (Mathf.Abs(velocity.x) < 0.01)
            velocity.x = 0;


        if ((_controller.collisions.Left && velocity.x < 0) || (_controller.collisions.Right && velocity.x > 0))
        {
            velocity.x = 0;
            velocityXSmoothing = 0;
        }
    }


    private void UpdateCamera()
    {
        var disX = transform.position.x - cam.transform.position.x;
        disX *= camSpeed;
        var disY = transform.position.y - cam.transform.position.y;
        disY *= camSpeed;
        cam.transform.position = new Vector3(cam.transform.position.x + disX, cam.transform.position.y + disY, -10);
        cam.transform.rotation = transform.rotation;
    }
}