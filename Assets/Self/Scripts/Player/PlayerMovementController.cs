using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviourPun
{ 
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private float diagonalSpeedSubtractor = 1.2f;

    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float _gravity = -30f;

    private CharacterController characterController;
    

    private float _yAxisVelocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            MoveWithInputs();
        }
    }

    private void MoveWithInputs()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3
        {
            x = horizontal,
            y = 0,
            z = vertical,
        }.normalized;

        if (horizontal == 1 && vertical == 1 || horizontal == 1 && vertical == -1 || horizontal == -1 && vertical == -1 || horizontal == -1 && vertical == 1)
        {
            movement /= diagonalSpeedSubtractor;
        }
        movement = movement.x * moveSpeed * Time.deltaTime * transform.right +
                    movement.z * moveSpeed * Time.deltaTime * transform.forward;

        if (characterController.isGrounded)
            _yAxisVelocity = -0.5f;

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            _yAxisVelocity = Mathf.Sqrt(jumpHeight * -2f * _gravity);

        _yAxisVelocity += _gravity * Time.deltaTime;
        movement.y = _yAxisVelocity * Time.deltaTime;

        characterController.Move(movement);
    }
}