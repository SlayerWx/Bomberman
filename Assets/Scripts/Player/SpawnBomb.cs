using System.Collections;
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
        if(Input.GetButtonDown("Jump") && bombCount < bombLimit && canSpawnAgain)
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
}
