using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CharacterController characterController;
    public FixedJoystick joystick;
    public float speed = 2f;
    public float jumpForce = 15f;
    public float gravity = 2f;
    public float verticalInput;
    public float horizontalInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        joystick = FindFirstObjectByType<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = joystick.Vertical;
        horizontalInput = joystick.Horizontal;
        
        var movement = new Vector3(horizontalInput * speed, 0, verticalInput * speed);
        characterController.Move(movement * Time.deltaTime);
    }

    private void LateUpdate()
    {
        // lay gốc xoay
        var currentRotation = transform.eulerAngles;
        // khóa trục x, z, chỉ xoay y
        transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);
    }
    
    // bat tuong tac va cham cua nhan vat voi ...
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
}
