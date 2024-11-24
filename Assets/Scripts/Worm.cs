using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Player
{
    public override void Eat(string food)
    {
        if (food == "breadcrumb" || food == "berry")
        {
            Debug.Log("here");
            GainExperience(10); // hoặc giá trị exp tùy thuộc vào loại thức ăn
        }
        else
        {
            Debug.Log("Worm can't eat this!");
        }
    }
}
