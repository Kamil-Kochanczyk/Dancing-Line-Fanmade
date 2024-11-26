using System;
using UnityEngine;

public class DancingHeadController : MonoBehaviour
{
    private Rigidbody _rb;

    private bool _xDirection = true;
    private const float _speed = 10.0f;
    private Vector3 _xDirectionVelocity = _speed * Vector3.right;
    private Vector3 _zDirectionVelocity = _speed * Vector3.forward;
    private Vector3 _velocity = Vector3.zero;

    public Action OnChangeDirection;  // <=> OnTurn

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _velocity;
    }

    private void OnTurn()
    {
        if (_xDirection)
        {
            _velocity = _xDirectionVelocity;
        }
        else
        {
            _velocity = _zDirectionVelocity;
        }

        OnChangeDirection?.Invoke();
        _xDirection = !_xDirection;
    }
}
