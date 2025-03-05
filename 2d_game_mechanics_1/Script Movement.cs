using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float _speed;
    [SerializeField] private float _gravity = -9.81f;
    private Vector3 _velocity;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        Debug.Log("the script is enabled");
    }

    private void Update()
    {
        Move();
        Debug.Log("the script is enabled");
    }
    void awake()
    {
        _speed= 2f;
        
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            _controller.Move(moveDirection * _speed * Time.deltaTime);
        }

        // Apply gravity
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}

