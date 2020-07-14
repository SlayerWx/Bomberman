using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    Collider myCollider;
    // Start is called before the first frame update
    private const int layerMask = 9;
    private float mapYHeight = 1.5f;
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myCollider.isTrigger = true;
        transform.position = new Vector3(transform.position.x,mapYHeight,transform.position.z);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer ==  layerMask)
        {
            myCollider.isTrigger = false;
        }
    }
}
