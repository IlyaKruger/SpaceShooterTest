using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody bolt;
    public float speed;
    private void Awake()
    {
        bolt = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        bolt.velocity = transform.forward * speed;

    }
}
