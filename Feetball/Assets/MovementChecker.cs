using UnityEngine;
using System;

public class MovementChecker : MonoBehaviour
{
    public event System.Action OnMove;
    public event System.Action OnStopMove;

    public bool moving = false;

    public Rigidbody2D rb;

    private void Start()
    {
        moving = false;
    }

    private void Update()
    {
        float smallValue = 0.7f;
        if (rb.linearVelocity.magnitude < smallValue && moving)
        {
            OnStopMove?.Invoke();
            moving = false;
        }
        else if (rb.linearVelocity.magnitude > smallValue && !moving)
        {
            OnMove?.Invoke();
            moving = true;
        }
    }
}
