using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPoint : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "Player")
        { 
            Destroy(gameObject);
        }
    }

}
