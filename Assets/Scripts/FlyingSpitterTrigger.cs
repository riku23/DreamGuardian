﻿using UnityEngine;
using System.Collections;

public class FlyingSpitterTrigger : MonoBehaviour
{
    public FlyingSpitterAI flyingSpitterAI;

    void Start()
    {
        flyingSpitterAI = gameObject.GetComponentInParent<FlyingSpitterAI>();
    } 

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            flyingSpitterAI.Attack();
        }
    }
}