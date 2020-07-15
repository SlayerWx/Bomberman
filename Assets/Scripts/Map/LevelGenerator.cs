﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour // asAS
{
    [SerializeField]
    GameObject wallPrefab;
    [SerializeField]
    Transform destructibleWallContainer;
    [SerializeField]
    int row = 1;
    [SerializeField]
    int col = 1;
    [SerializeField]
    int spawnAreaDistance = 2;
    int scaleWall = 2;
    [SerializeField]
    int probDestructiveWallSpawn = 1;
    List<GameObject> map;
    [SerializeField]
    GameObject door;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    int cantEnemyMax;
    int enemycount;
    [SerializeField]
    int probEnemyApearHere;
    [SerializeField]
    int rangeApearEnemy;
    float floorDifToDoor = 0.5f;
    void Start()
    {
        map = new List<GameObject>();
        for(int i = 0; i < col;i++)
        {
            for(int t = 0; t < row;t++)
            {
                if ((t%2==0 || i%2==0))
                {
                    TargetGenerator(i,t);
                }
                
            }
        }
        Vector3 aux = map[Random.Range(0,map.Count)].transform.position;
        aux.y = floorDifToDoor;
        Instantiate(door,aux, Quaternion.identity,transform); 
    }

    private GameObject TargetGenerator(int i,int t)
    {
        GameObject w = new GameObject();
        if (probDestructiveWallSpawn > Random.Range(0, 100) &&
                                          (!(i > col - spawnAreaDistance - 1 && t < spawnAreaDistance) &&
                                           !(i > col - spawnAreaDistance - 1 && t > row - spawnAreaDistance - 1) &&
                                           !(i < spawnAreaDistance && t > row - spawnAreaDistance - 1) &&
                                           !(i < spawnAreaDistance && t < spawnAreaDistance)))
        {
            w = Instantiate(wallPrefab, destructibleWallContainer);
            w.transform.position = new Vector3(destructibleWallContainer.position.x + (i * scaleWall),
                                               destructibleWallContainer.position.y,
                                               destructibleWallContainer.position.z + (t * -scaleWall));
            w.name = "Wall:" + i + "-" + t;
            map.Add(w);
        }
        else if (Random.Range(0, 100) < probEnemyApearHere && cantEnemyMax > enemycount &&
                               i > col / rangeApearEnemy && t > row / rangeApearEnemy &&
                              (!(i > col - 1 && t < spawnAreaDistance) &&
                               !(i > col - 1 && t > row - 1) &&
                               !(i < spawnAreaDistance && t > row - 1) &&
                               !(i < spawnAreaDistance && t < spawnAreaDistance)))
        {
            enemycount++;
            w = Instantiate(enemyPrefab, destructibleWallContainer);
            w.transform.position = new Vector3(destructibleWallContainer.position.x + (i * scaleWall),
                                               destructibleWallContainer.position.y,
                                               destructibleWallContainer.position.z + (t * -scaleWall));
            Debug.Log("enemy");
        }

        return w;
    }
}
