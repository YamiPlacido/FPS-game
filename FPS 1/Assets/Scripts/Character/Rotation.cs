using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    private Animator _anim => GetComponentInParent<Animator>();
    private float _rotationX;
    private float _rotationY;
    private float _senHor = 9.0f;
    private float _senVert = 9.0f;
    private float _minVert = -45.0f;
    private float _maxVert = 45.0f;
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _senHor, 0);
        }
        else if(axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _senVert;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);

            _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _senVert;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);

            _rotationY = Input.GetAxis("Mouse X") * -_senHor + transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }        

    }
}
