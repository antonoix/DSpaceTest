using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class Statistics : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private TextMeshProUGUI _text;

    public static List<float> Results { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Results == null)
            Results = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterTime(float time)
    {
        Results.Add(time);
    }

    public void ShowOrHide()
    {
        _window.SetActive(!_window.activeSelf);
        Debug.Log(Results.Count);
        if (_window.activeSelf)
        {
            StringBuilder stringB = new StringBuilder();
            foreach(var e in Results)
            {
                stringB.Append(e + "\n");
            }
            _text.text = stringB.ToString();
        }
    }
}
