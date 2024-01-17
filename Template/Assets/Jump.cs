using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody _rb;
    public float _JumpForce = 5;
    public float _speed = 5;
    Vector3 move;
    PlayerControls controls;
    public float rotationSpeed = 100f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Newactionmap.Enable();
        controls.Newactionmap.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Newactionmap.Move.canceled += ctx => move = Vector2.zero;
    }

    private void FixedUpdate()
    {
        //_rb.velocity = (transform.forward * move.y) * _speed * Time.fixedDeltaTime;
        /*if (move != Vector3.zero)
        {
            transform.forward = move;
        }*/
        //_rb.AddForce(new Vector3(move.x, 0f, move.y) * _speed * Time.fixedDeltaTime);
        _rb.velocity = (transform.forward * move.y) * _speed * Time.fixedDeltaTime;
        transform.Rotate((transform.up * move.x) * rotationSpeed * Time.fixedDeltaTime);

    }
    public void OnJump()
    {
        print("Jump");
        if (Mathf.Abs(_rb.velocity.y) < 0.001f)
        {
            //_rb.AddForce(new Vector3(0f, _JumpForce, 0f), ForceMode.Impulse); //ForceMode.Impulse);
            _rb.AddForce(Vector3.up * _JumpForce);
        }
    }
}
