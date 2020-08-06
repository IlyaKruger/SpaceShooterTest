using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    public float tumble;
    Rigidbody asteroid;

    private void Awake()
    {
        tumble = 5;
        asteroid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        asteroid.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
