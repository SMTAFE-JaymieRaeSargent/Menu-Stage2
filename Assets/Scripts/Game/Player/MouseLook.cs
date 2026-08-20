using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera _playerCamera;

    [Header("Mouse Look")]
    [SerializeField] private float _mouseSensitivity = 2f;
    [SerializeField] private float _maxLookAngle = 80f;
    [SerializeField] private bool _isYInverted = false;
    private float _totalVerticalRotation = 0f;
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    float _finalVerticalRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_playerCamera == null)
        {
            _playerCamera = GetComponentInChildren<Camera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
            CameraControl();
        
       
    }
    void CameraControl()
    {
        _horizontalInput = Input.GetAxis("Mouse X") * _mouseSensitivity;
        transform.Rotate(Vector3.up * _horizontalInput);
        _verticalInput = Input.GetAxis("Mouse Y") * _mouseSensitivity;
        _totalVerticalRotation += _verticalInput;
        _totalVerticalRotation = Mathf.Clamp(_totalVerticalRotation, -_maxLookAngle, _maxLookAngle);
        if (_isYInverted == true)
        {
            _finalVerticalRotation = _totalVerticalRotation;
        }
        else
        {
            _finalVerticalRotation = -_totalVerticalRotation;
        }
        _playerCamera.transform.localRotation = Quaternion.Euler(_finalVerticalRotation, 0f, 0f);

    }
}
