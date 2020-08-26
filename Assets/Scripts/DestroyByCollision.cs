using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject hitPlayer;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(hitPlayer, transform.position, transform.rotation);
            Instantiate(explosion, transform.position, transform.rotation);
            //минус хп
            gameController.LifeMinus();
            Destroy(gameObject);
            return;
        }
        if (other.tag == "Border")
        {

            Destroy(gameObject);
            return;
        }
        gameController.ScorePlus();
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
