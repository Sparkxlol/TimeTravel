using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float deletionTime = 1f;

    private void Start()
    {
        StartCoroutine(deletion());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //
        }
    }

    private IEnumerator deletion()
    {
        yield return new WaitForSeconds(deletionTime);
        Destroy(this.gameObject);
    }
}
