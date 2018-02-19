using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPoint : MonoBehaviour
{

    public List<AudioClip> ohYeah;
    private bool mayDestroy = false;

    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying && mayDestroy)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "Player" && !mayDestroy)
        {
            GetComponent<AudioSource>().clip = ohYeah[Random.Range(0,ohYeah.Count)];
            GetComponent<AudioSource>().Play();
            mayDestroy = true;
        }
    }

}
