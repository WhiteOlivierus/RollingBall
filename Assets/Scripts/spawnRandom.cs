using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnRandom : MonoBehaviour
{

    public GameObject toSpawn;
    private GameObject spawned;
    private Vector3 t;
    private int score = 0;

    void Start()
    {
        createPoint();
    }

    void FixedUpdate()
    {
        if (!spawned)
        {
            createPoint();

            score++;
            GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
        }
    }
    void createPoint()
    {
        float x = Random.Range(transform.localScale.x / 2 - 0.5f, -transform.localScale.x / 2 + 0.5f);
        float z = Random.Range(transform.localScale.z / 2 - 0.5f, -transform.localScale.z / 2 + 0.5f);
        t = new Vector3(x, 0.55f, z);

        spawned = Instantiate(toSpawn, t, Quaternion.identity);
        spawned.name = toSpawn.name;
    }
}
