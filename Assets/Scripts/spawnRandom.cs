﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class spawnRandom : MonoBehaviour
{
    public GameObject toSpawn;
    private GameObject spawned;
    private Vector3 t;
    private int score = 0;
    private Vector3 basePos;
    private Vector3 toGroundPos;

    void Start()
    {
        createPoint();
    }

    void FixedUpdate()
    {
        if (!spawned)
        {
            if (createPoint())
            {
                score++;
                GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
            }      
        }
    }

    bool createPoint()
    {
        float x = Random.Range(transform.localScale.x / 2 - 0.5f, -transform.localScale.x / 2 + 0.5f);
        float z = Random.Range(transform.localScale.z / 2 - 0.5f, -transform.localScale.z / 2 + 0.5f);

        RaycastHit hit;

        basePos = new Vector3(x, 20, z);
        toGroundPos = new Vector3(x, -20, z);

        Ray centerRay = new Ray(basePos, toGroundPos);

        if (Physics.Raycast(centerRay, out hit))
        {
            Vector3 posInst = new Vector3(x,hit.point.y + 0.5f, z);
            print(posInst);
            spawned = Instantiate(toSpawn, posInst, Quaternion.identity);
            spawned.name = toSpawn.name;
            return true;
        }
        return false;
    }

}
