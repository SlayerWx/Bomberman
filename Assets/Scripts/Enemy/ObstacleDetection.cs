using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    public bool IsObstacle { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        IsObstacle = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire" || other.gameObject.tag == "Map" || other.gameObject.tag == "Enemy")
        {
            IsObstacle = true;
        }
        else
        {
            IsObstacle = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.tag == "Fire" || other.gameObject.tag == "Map" || other.gameObject.tag == "Enemy")
        {
            IsObstacle = false;
        }
        
    }
}
