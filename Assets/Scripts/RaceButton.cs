using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaceButton : MonoBehaviour
{
    public event Action OnPushed;

    private bool _playerIsNear;

    public void Init(PlayerInput input)
    {
        input.Player.ButtonPush.performed += callback => CheckClick();
    }

    private void CheckClick()
    {
        if (_playerIsNear)
            OnPushed?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mover>(out var mover))
        {
            _playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Mover>(out var mover))
        {
            _playerIsNear = false;
        }
    }

    private void OnDisable()
    {
        _playerIsNear = false;
    }
}
