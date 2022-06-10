using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Unit
{
    protected override void Start()
    {
        SpeedMaximum = Random.Range(1.0f, 4.0f);
        SpeedMinimum = Random.Range(0.5f, SpeedMaximum);

        RecalculateSpeed();
        base.Start();
    }

    protected override void Speak()
    {
        Debug.Log("Woof");
    }
}
