using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Unit
{
    protected override void Start()
    {
        SpeedMaximum = Random.Range(3.0f, 6.0f);
        SpeedMinimum = Random.Range(1.5f, SpeedMaximum);

        RecalculateSpeed();
        base.Start();
    }

    protected override void Speak()
    {
        Debug.Log("Meow");
    }

    protected override void Move()
    {
        base.Move();
        if (m_IsOnGround)
            m_rigidBody.AddForce(Vector3.up, ForceMode.Impulse);
    }
}
