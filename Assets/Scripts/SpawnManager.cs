using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
   
    private Camera mainCamera;
    private readonly float spawnY = 0.7f;

    [Header("Pooling Options")]
    private static SpawnManager SharedInstance;
    private List<GameObject> pooledEnemies;
    [SerializeField]
    private GameObject[] enemiesToPool;
    [SerializeField]
    private int amountToPool;


    void Awake()
    {

        SharedInstance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        //initialize enemies pooler
        pooledEnemies = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(enemiesToPool[Random.Range(0,2)]);
            tmp.SetActive(false);
            pooledEnemies.Add(tmp);
        }


        mainCamera = Camera.main;

        InvokeRepeating("SpawnEnemy", 1.5f, 5f);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnEnemy() {

        GameObject enemy = GetPooledEnemy();


        if(enemy != null) { 

           

            float[] validChoices = new float[] { -0.5f,-0,4f,-0.3f,-0.2f,-0.1f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f };
            float[] randPos = new float[2]; 
        
            for (int i = 0; i < randPos.Length; i++) 
            {
                randPos[i] = validChoices[Random.Range(0, validChoices.Length)];

            }

            Vector3 v3Pos = mainCamera.ViewportToWorldPoint(new Vector3(randPos[0], randPos[1], 1));

            v3Pos.x = Mathf.Min(Mathf.Max(v3Pos.x,-23),23);
            v3Pos.z = Mathf.Min(Mathf.Max(v3Pos.z, -23), 23);

            Vector3 spawnPos = new Vector3(v3Pos.x,
            spawnY,
            v3Pos.z);

            enemy.transform.position = spawnPos;

            enemy.SetActive(true);
        }
    }

}
