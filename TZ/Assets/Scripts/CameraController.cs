using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _sensivity;
    [SerializeField] private float _maxYAngle;

    private float _rotationX = 0.0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * mouseX * _sensivity);

        _rotationX -= mouseY * _sensivity;
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
    }
}
