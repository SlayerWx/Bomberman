using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Destroy(transform.gameObject);
    }
    
}