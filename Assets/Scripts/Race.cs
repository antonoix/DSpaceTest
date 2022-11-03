using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Race : MonoBehaviour
{
    [SerializeField] StartButton _startButton;
    [SerializeField] EndButton _endButton;

    private Statistics _stats;
    private float _startTime;

    private PlayerInput _input;

    public void Init(Statistics stats, PlayerInput input)
    {
        _input = input;
        _stats = stats;
        _input.Player.ShowStats.performed += callback => _stats.ShowOrHide();
        _startButton.OnPushed += StartRace;
        _startButton.Init(input);
        _endButton.OnPushed += EndRace;
        _endButton.Init(input);
    }

    private void StartRace()
    {
        Debug.Log("start");
        _startTime = Time.time;
    }

    private void EndRace()
    {
        Debug.Log("end");
        _stats.RegisterTime(Time.time - _startTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        _input.Player.ShowStats.performed -= callback => _stats.ShowOrHide();
        _startButton.OnPushed -= StartRace;
        _endButton.OnPushed -= EndRace;
    }
}
