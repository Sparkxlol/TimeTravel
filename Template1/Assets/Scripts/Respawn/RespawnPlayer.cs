using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private RespawnManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<RespawnManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            manager.setRespawn(transform.position);
        }
    }
}
