using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RespawnManager : MonoBehaviour
{
    [SerializeField] private Vector2 respawn;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void respawnPlayer()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Transform>().position = respawn;
    }

    public void setRespawn(Vector2 pos)
    {
        respawn = pos;
    }
}
