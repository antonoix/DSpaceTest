using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private int _speed;

    private PlayerInput _input;
    private Rigidbody _rb;
    private Animator _animator;

    // Start is called before the first frame update
    public void Init(PlayerInput input)
    {
        Debug.Log("PlayerInit");
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _input = input;
        _input.Player.Jump.performed += callback => Jump();
    }

    // Update is called once per frame
    void Update()
    {
        Move(_input.Player.Run.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        _rb.velocity = new Vector3(direction.x, 0, direction.y) * _speed + Vector3.up * _rb.velocity.y;
        _animator.SetBool("Run", _rb.velocity.magnitude > 0.2f);
    }

    private void Jump()
    {
        _animator.SetTrigger("Jump");
        _rb.AddForce(Vector3.up * 200);
    }

    private void OnDestroy()
    {
        _input.Player.Jump.performed -= callback => Jump();
    }
}
