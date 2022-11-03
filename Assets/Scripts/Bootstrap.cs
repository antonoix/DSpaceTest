using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] Race _race;
    [SerializeField] Mover _player;
    [SerializeField] Statistics _stats;

    private PlayerInput _input;

    // Start is called before the first frame update
    void Awake()
    {
        _input = new PlayerInput();
        _input.Enable();
        _race.Init(_stats, _input);
        _player.Init(_input);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
