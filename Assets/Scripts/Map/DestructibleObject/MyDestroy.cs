using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDestroy : MonoBehaviour
{
    public delegate void CoinIncreas();
    public static event CoinIncreas IncreasCoin;
    private void OnParticleCollision(GameObject other)
    {
        IncreasCoin();
        Destroy(transform.gameObject);
    }
}
