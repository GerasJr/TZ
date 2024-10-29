using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _speed = 5f;
    private Vector3 _moveVector;
    private CharacterController _controller;
    float _gravityScale = 9.81f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _moveVector = transform.forward * verticalInput + transform.right * horizontalInput;
        _moveVector.y -= _gravityScale * Time.fixedDeltaTime; 
        _controller.Move(_moveVector * _speed * Time.fixedDeltaTime);
    }
}

