using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsContainer : MonoBehaviour
{
    public static List<float> Results { get; private set; }

    void Awake()
    {
        Results = new List<float>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
