﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    [SerializeField]
    GameObject bombPrefab;
    public static int bombCount = 0;
    [SerializeField]
    private int bombLimit;
    private bool canSpawnAgain;
    [SerializeField]
    private float timeToWait;
    private int myPoints;
    void Start()
    {
        canSpawnAgain = true;
        bombCount = 0;
    }
    
    void Update()
    {
        Spawn();
    }
    void Spawn()
    {
        if((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Mouse0))
            && bombCount < bombLimit && canSpawnAgain && Time.timeScale != 0.0f)
        {
            bombCount++;
            int auxX = 0;
            int auxZ = 0;
            if ((int)transform.position.x % 2 != 0) auxX = -1;
            if ((int)transform.position.z % 2 != 0) auxZ = 1;
            Instantiate(bombPrefab).transform.position = 
            new Vector3((int)transform.position.x+ auxX, transform.position.y,(int)transform.position.z+ auxZ);
            
        }
    }
    public void SetPoints(int i)
    {
        myPoints = i;
    }
    public int GetPoints()
    {
        return myPoints;
    }
}
