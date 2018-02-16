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
            createPoint();

            score++;
            GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
        }
        Debug.DrawLine(basePos, toGroundPos, Color.red);
    }
    void createPoint()
    {


        float x = Random.Range(transform.localScale.x / 2 - 0.5f, -transform.localScale.x / 2 + 0.5f);
        float z = Random.Range(transform.localScale.z / 2 - 0.5f, -transform.localScale.z / 2 + 0.5f);

        RaycastHit hit;
        basePos = new Vector3(x, 20, z);
        toGroundPos = new Vector3(x, -20, z);
        Ray ray = new Ray(basePos, toGroundPos);
        if(Physics.Raycast(ray, out hit))
        {
            print(hit.point);
            spawned = Instantiate(toSpawn, hit.point + new Vector3(0,0.5f,0), Quaternion.identity);
            spawned.name = toSpawn.name;
        }
        else
        {
            print("fail");
        }


    }
}
