using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController _characterController;
    [Header("Movement Speeds")]
    [SerializeField] private float _walkSpeed = 6f;
    [SerializeField] private float _sprintSpeed = 10f;
    [SerializeField] private float _crouchSpeed = 3f;
    [SerializeField] private float _movementSpeed;
    [Header("Jump / Gravity")]
    [SerializeField] private float _jumpSpeed = 8f;
    [SerializeField] private float _gravity = -20f;
    private Vector3 _movementDirection = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_characterController == null)
        {
            _characterController = GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementUpdate();
    }

    void PlayerMovementUpdate()
    {
        if (_characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _movementSpeed = _sprintSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                _movementSpeed = _crouchSpeed;
            }
            else
            {
                _movementSpeed = _walkSpeed;
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            _movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
            _movementDirection *= _movementSpeed;
            _movementDirection = transform.TransformDirection(_movementDirection);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movementDirection.y = _jumpSpeed;
            }
        }

        _movementDirection.y += _gravity * Time.deltaTime;
        _characterController.Move(_movementDirection * Time.deltaTime);
    }

}
