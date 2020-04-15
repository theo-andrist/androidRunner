﻿using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public CharacterController characterController;
    public Animator myAnimator;

    public float moveSpeed;
    public float sprintSpeedMultiplier = 2f;

    public float jumpHeight = 3f;
    public float _gravity = -30f;

    private float _yAxisVelocity;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        myAnimator.SetFloat("horizontal", horizontal);
        myAnimator.SetFloat("vertical", vertical);

        if (Input.GetKey(KeyCode.LeftShift))
            vertical *= sprintSpeedMultiplier;

        Vector3 movement = horizontal * moveSpeed * Time.deltaTime * transform.right +
                           vertical * moveSpeed * Time.deltaTime * transform.forward;

        if (characterController.isGrounded)
            _yAxisVelocity = -0.5f;


        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            _yAxisVelocity = Mathf.Sqrt(jumpHeight * -2f * _gravity);

        _yAxisVelocity += _gravity * Time.deltaTime;
        movement.y = _yAxisVelocity * Time.deltaTime;

        characterController.Move(movement);
    }
}