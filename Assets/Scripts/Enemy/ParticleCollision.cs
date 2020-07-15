using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    [SerializeField]
    EnemyMovement em;
    void OnParticleCollision(GameObject other)
    {
        em.ImDead();
    }
}
