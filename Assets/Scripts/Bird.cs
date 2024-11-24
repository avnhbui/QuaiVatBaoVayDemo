using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Player
{
    public override void Eat(string food)
    {
        if (food == "breadcrumb" || food == "berry" || food == "worm")
        {
            GainExperience(10); // hoặc giá trị exp tùy thuộc vào loại thức ăn
        }
        else
        {
            Debug.Log("Bird can't eat this!");
        }
    }
}
