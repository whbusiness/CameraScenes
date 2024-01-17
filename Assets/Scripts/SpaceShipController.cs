using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipController : MonoBehaviour
{
    private Rigidbody rb;
    PlayerController controls;
    Vector3 move;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Awake()
    {
        controls = new PlayerController();
        //controls.Newactionmap.Enable();
    }
    private void OnEnable()
    {
        controls.Movement.Enable();
    }
    private void OnDisable()
    {
        controls.Movement.Disable();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard.wKey.isPressed)
        {
            rb.AddForce(Vector3.forward * speed * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        if (keyboard.aKey.isPressed)
        {
            rb.AddForce(Vector3.left * speed * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        if (keyboard.dKey.isPressed)
        {
            rb.AddForce(Vector3.right * speed * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        if (keyboard.sKey.isPressed)
        {
            rb.AddForce(Vector3.back * speed * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }
}
