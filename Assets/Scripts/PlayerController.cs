﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float jumpHeight;
    public float turnSpeed;
    public float gravity;
    public float YcamOffset;
    public Camera cam;
    
    private CharacterController _controller;
    private Vector3 _movement;
    private Vector3 _velocity;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        readInput();
        movePlayer();
        updateCamera();
    }
    
    void readInput()
    {
        _movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
    }

    void movePlayer()
    {
        if(_movement != Vector3.zero)
        {
            this.transform.forward = _movement;
        }
        

        _movement.y -= gravity * Time.deltaTime;
        _controller.Move(_movement * Time.deltaTime * speed);

    }

    private void updateCamera()
    {
        cam.transform.position = this.transform.position;
        cam.transform.position += new Vector3(0, YcamOffset, 0);
    }
    
}
