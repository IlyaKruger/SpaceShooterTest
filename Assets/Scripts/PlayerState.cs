using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerState", menuName = "Player State", order = 51)]
public class PlayerState : ScriptableObject
{
    [SerializeField]
    private float angleMove = 4;
    [SerializeField]
    public float fireDelta = 0.25f;
    [SerializeField]
    public float nextFire = 0.25f;
    [SerializeField]
    private float minX = 4;
    [SerializeField]
    private float maxX = 4;
    [SerializeField]
    private float minZ = 0;
    [SerializeField]
    private float maxZ = 8;

    public float AngleMove
    {
        get
        {
            return angleMove;
        }
    }
    public float FireDelta
    {
        get
        {
            return fireDelta;
        }
    }
    public float NextFire
    {
        get
        {
            return nextFire;
        }
    }
    public float MinX
    {
        get
        {
            return minX;
        }
    }
    public float MaxX
    {
        get
        {
            return maxX;
        }
    }
    public float MinZ
    {
        get
        {
            return minZ;
        }
    }
    public float MaxZ
    {
        get
        {
            return maxZ;
        }
    }
}
