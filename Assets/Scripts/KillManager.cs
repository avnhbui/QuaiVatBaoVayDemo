using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager Instance; 
    private int killCounter = 0;
    public TextMeshProUGUI killText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKill()
    {
        killCounter += 1;
        killText.text = "Kill: " + killCounter.ToString();
    }
}
