using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float Speed 
    {
        get => m_Speed;
        set
        {
            if (value < m_SpeedMinimum || value > m_SpeedMaximum)
                Debug.Log("Invalid speed value");
            else
                m_Speed = value;
        }
    }
    protected float SpeedMinimum
    {
        get => m_SpeedMinimum;
        set
        {
            if (value < 0.0f || value > m_SpeedMaximum)
                Debug.Log("Invalid minimum speed value");
            else
                m_SpeedMinimum = value;
        }
    }
    protected float SpeedMaximum
    {
        get => m_SpeedMaximum;
        set
        {
            if (value < 0.0f || value < m_SpeedMinimum)
                Debug.Log("Invalid maximum speed value");
            else
                m_SpeedMaximum = value;

        }
    }


    protected Rigidbody m_rigidBody;
    protected bool m_IsOnGround;

    private float m_Speed = 0.0f;
    private float m_SpeedMinimum = 0.0f;
    private float m_SpeedMaximum = 0.0f;

    protected virtual void Start()
    {
        m_rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            m_IsOnGround = true;
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            transform.Rotate(Vector3.up, Random.Range(150.0f, 210.0f));
            RecalculateSpeed();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            m_IsOnGround = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Speak();
        }
    }

    protected void RecalculateSpeed()
    {
        Speed = Random.Range(SpeedMinimum, SpeedMaximum);
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    protected abstract void Speak();
}
