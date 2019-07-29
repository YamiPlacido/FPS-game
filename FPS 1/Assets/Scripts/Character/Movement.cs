using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _charc;
    private Animator _anim;

    private float _xInput;
    private float _zInput;
    public float _gravity = -9.8f;
    public float speed = 6.0f;

    void Start ()
    {
        _charc = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        Vector3 movement = Vector3.zero;
        _xInput = Input.GetAxis("Horizontal") * speed;
        _zInput = Input.GetAxis("Vertical")* speed;

        if(_xInput != 0 || _zInput != 0)
        {
            movement = new Vector3(_xInput, 0, _zInput);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement.y = _gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charc.Move(movement);
        }

        _anim.SetFloat("speed", movement.sqrMagnitude);
        _anim.SetFloat("x", _xInput);
        _anim.SetFloat("y", _zInput);

    }
}
