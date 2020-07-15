using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    Material myMteril;
    bool open;
    public delegate void Win();
    public static event Win Winner;
    void Start()
    {
        myMteril = GetComponent<MeshRenderer>().material;
        LevelGenerator.OpenedDoor += Open;
        open = false;
    }
    void Open()
    {
        if(EnemyMovement.maxID <= EnemyMovement.deadNumber)
        {
            open = true;
            myMteril.color = Color.gray;
        }
    }
    private void OnDisable()
    {
        LevelGenerator.OpenedDoor -= Open;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag + " " + other.gameObject.name);
        if(open && other.gameObject.tag == "Player")
        {
            Winner?.Invoke();
        }
         
    }
}
