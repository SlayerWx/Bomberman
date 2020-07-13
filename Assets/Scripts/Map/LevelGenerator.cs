using System.Collections;
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

    void Start()
    {
        for(int i = 0; i < col;i++)
        {
            for(int t = 0; t < row;t++)
            {
                if ((t%2==0 || i%2==0) && probDestructiveWallSpawn > Random.Range(0.0f,100.0f) &&
                                           (!(i>col-spawnAreaDistance-1 && t< spawnAreaDistance) && 
                                           !(i>col-spawnAreaDistance-1 && t>row- spawnAreaDistance-1) && 
                                           !(i< spawnAreaDistance && t>row-spawnAreaDistance-1) && 
                                           !(i< spawnAreaDistance && t< spawnAreaDistance)))
                {
                    GameObject w = Instantiate(wallPrefab, destructibleWallContainer);
                    w.transform.position = new Vector3(destructibleWallContainer.position.x + (i * scaleWall),
                                                       destructibleWallContainer.position.y,
                                                       destructibleWallContainer.position.z + (t * -scaleWall));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
