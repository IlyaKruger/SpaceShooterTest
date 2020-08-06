using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearByTime : MonoBehaviour
{
    public float timeLife;
    private void Start()
    {
        Destroy(gameObject, timeLife);
    }
}
