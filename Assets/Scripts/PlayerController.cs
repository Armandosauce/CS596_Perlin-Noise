using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float jumpHeight;
    public float turnSpeed;
    public float distToGround;
    public float gravity;
    public LayerMask ground;
    public Transform checkGround;

    private CharacterController _controller;
    private Vector3 _movement;
    private Vector3 _velocity;
    private bool _isGrounded;
    private bool _jump;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        resetPlayer();
        readInput();
        movePlayer();
    }

    void resetPlayer()
    {
        _isGrounded = Physics.CheckSphere(checkGround.position, distToGround, ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }
    }
    void readInput()
    {
        _movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void movePlayer()
    {
        _controller.Move(_movement * Time.deltaTime * speed);
        if(_movement != Vector3.zero)
        {
            this.transform.forward = _movement;
        }
        
        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

    }
    
}
