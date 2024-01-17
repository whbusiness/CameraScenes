using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    /*
      
     FIX FALLING IN SLOW MOTION, ADD A FLAG SO THAT IT ONLY WORKS WHEN JUMPING

    */
    //public bool Rotate = false;

    //private Quaternion _cameraTargetRot;
    private Rigidbody _rb;
    public float ChangeValue;
    [SerializeField] private float _speed;
    [SerializeField] private float _JumpForce;
    public bool AllowInput = true;
    public static bool Pause = false;
    private bool Sprint = true;
    public bool FreezeConstraints = false;
    PlayerController controls;
    Vector3 move;
    //Vector3 EulerAngleVelocity;
    public bool SlowTime = false;
    public bool Nogravity = true;
    [Header("Gravity Change")]
    [Tooltip("Changes the gravity on k press, Original gravity is -9.81")]
    public float ChangeInGravity;
    public float originalMass = 1f;
    public float massChange = 0.7f;
    public float rotationSpeed = 100f;
    public Transform MovePosition;
    //public Transform PlayersBack;
    // Start is called before the first frame update
    Vector3 look;
    float RotateX;
    float RotateY;
    public float sensX;
    public float sensY;
    public new Transform camera;
    [SerializeField] Transform PlayerCam;
    public Transform Player;
    [SerializeField] float xClamp = 85f;
    public bool OutOfWater = true;
    public float WaterGravity;
    public static bool EscapeIsPressed = false;
    public Canvas pauseMenuUI;
    private Vector3 mousePos;
    public float maxDistance;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //_cameraTargetRot = CameraTransform.rotation;
        //EulerAngleVelocity = new Vector3(0, look.x, 0);
    }
    private void Awake()
    {
        pauseMenuUI.enabled = false;
        //Physics.gravity = new Vector3(0f, -100f, 0);
        controls = new PlayerController();
        //controls.Newactionmap.Enable();
        controls.Movement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Movement.Move.canceled += ctx => move = Vector2.zero;
        controls.Movement.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.Movement.Look.canceled += ctx => look = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Movement.Enable();
    }
    private void OnDisable()
    {
        controls.Movement.Disable();
    }

    private void Update()
    {
        print(EscapeIsPressed);
        if (!EscapeIsPressed)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            float LookingX = look.x * Time.deltaTime * sensX;
            float LookingY = look.y * Time.deltaTime * sensY;
            RotateY += LookingX;
            RotateX -= LookingY;
            transform.Rotate(Vector3.up, LookingX);
            RotateX = Mathf.Clamp(RotateX, -xClamp, xClamp);
            Vector3 YRotation = transform.eulerAngles;
            YRotation.x = RotateX;
            camera.eulerAngles = YRotation;
        }
        if (EscapeIsPressed)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Keyboard keyboard = Keyboard.current;
        if (keyboard.shiftKey.wasPressedThisFrame)
        {
            _speed *= 2;
        }
        if (keyboard.shiftKey.wasReleasedThisFrame)
        {
            _speed /= 2;
        }
        if (Pause)
        {
            pauseMenuUI.enabled = true;
            Time.timeScale = 0;
        }
        else if (!Pause)
        {
            pauseMenuUI.enabled = false;
            Time.timeScale = 1;
        }
    }
    private void FixedUpdate()
    {
        
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;
            forward.y = 0;
            right.y = 0;
            forward = forward.normalized;
            right = right.normalized;
            Vector3 forwardrelativeverticalmovement = move.y * forward;
            Vector3 forwardrelativehorizontalmovement = move.x * right;
            Vector3 camerarelativemovement = forwardrelativeverticalmovement + forwardrelativehorizontalmovement;
            _rb.AddForce(_speed * Time.fixedDeltaTime * camerarelativemovement, ForceMode.Force);
            if (camerarelativemovement == Vector3.zero)
            {
                return;
            }
            if(move.x == 0 && move.y == 0)
            {
                _rb.velocity = Vector3.zero;
            }

    }
    public void OnPause()
    {
        if (Pause)
        {
            Pause = false;
        }
        else
        {
            Pause = true;
        }
    }
    /* public void OnSprint()
     {
         if (Sprint)
         {
             _speed *= 2;
             Sprint = false;
         }
         else
         {
             _speed /= 2;
             Sprint = true; 
         }
     }*/

    public void OnEscape()
    {
        if (EscapeIsPressed)
        {
            EscapeIsPressed = false;
        }
        else
        {
            EscapeIsPressed = true;
        }
    }
    /*void HandleRotation()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(move.x, 0, move.y);
        Vector3 positionToLookAt = currentPosition + newPosition;
        transform.LookAt(PlayersBack);
    }*/
    public void OnJump()
    {
        //Jump = true;

        if (Mathf.Abs(_rb.velocity.y) < 0.01f)
        {
            Vector3 Jump = new(0f, _JumpForce);
            _rb.AddForce(Jump);
        }
    }
}
