﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.006f;
    public EnemyManager em;
    public float scale;
    private Vector3 destination;
    private float halfHeight = 0.1f;

    void Start()
    {
        destination = em.GetDestination() + (Vector3.up * halfHeight);
        halfHeight = scale / 2;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < 0.02f)
        {
            destination = em.GetDestination() + (Vector3.up * halfHeight);
        }
    }

    private void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed);
    }
}
