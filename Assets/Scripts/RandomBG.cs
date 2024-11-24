using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBG : MonoBehaviour
{
    // Start is called before the first frame update
    public Image img; 
    public Color[] colors = new Color[4];
    void Start()
    {
        colors[0] = Color.blue;
        colors[1] = Color.red;
        colors[2] = Color.magenta;
        colors[3] = Color.yellow;
        Color randomColor = colors[Random.Range(0, colors.Length)];
        img.color = randomColor;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
}
