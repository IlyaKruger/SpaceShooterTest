using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerState playerState;

    protected Joystick joystick;
    protected JoyButton joyButton;
    private float speed;
    Rigidbody player;
    private float angle;
    private float minX, maxX, minZ, maxZ;
    public GameObject shot;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public float fireDelta;
    private float nextFire;
    private void Awake()
    {

        player = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<JoyButton>();
        speed = 8.0f;
        angle = playerState.AngleMove;
        fireDelta = playerState.fireDelta;
        nextFire = playerState.nextFire;
        minX = -playerState.MinX;
        maxX = playerState.MinX;
        minZ = playerState.MinZ;
        maxZ = playerState.MaxZ;
    }
    private void FixedUpdate()
    {

        player = GetComponent<Rigidbody>();
        player.velocity = new Vector3(joystick.Horizontal * 5f, 0, joystick.Vertical * 5f);
        player.position = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), 0, Mathf.Clamp(player.position.z, minZ, maxZ));
        player.rotation = Quaternion.Euler(0, 0, player.velocity.x * -angle);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if (moveX != 0 || moveY != 0)
        {
            Vector3 move = new Vector3(moveX, 0, moveY);
            player.velocity = move * speed;
            player.position = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), 0, Mathf.Clamp(player.position.z, minZ, maxZ));
            player.rotation = Quaternion.Euler(0, 0, player.velocity.x * -angle);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireDelta;
            Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        }

        if (joyButton.pressed == true && Time.time > nextFire)
        {
            nextFire = Time.time + fireDelta;
            Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        }
    }
}
