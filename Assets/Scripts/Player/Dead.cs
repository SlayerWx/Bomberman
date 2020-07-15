using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour 
{
    Vector3 startPosition;
    [SerializeField]
    int MaxLife = 2;
    int counLife = 2;
    public delegate void Perder();
    public static event Perder PlayerDead;
    float timeInvulnerable = 2.0f;
    bool vulnerable;

    void Start()
    {
        counLife = MaxLife;
        startPosition = transform.position;
        vulnerable = true;
    }
    void OnCollisionEnter(Collision col)
    {
        
        if(col.gameObject.tag == "Enemy")
        {
            Hitted();
        }
    }
    void OnParticleCollision(GameObject other)
    {
            Hitted();
    }
    void Hitted()
    {
        if (vulnerable)
        {
            vulnerable = false;
            counLife--;
            transform.position = startPosition;
            if (PlayerDead != null && counLife <= 0)
            {
                if (counLife < 0) counLife = 0;
                PlayerDead();
            }
            StartCoroutine("InvulnerableTime");
        }
    }
    IEnumerator InvulnerableTime()
    {
        yield return new  WaitForSeconds(timeInvulnerable);
        vulnerable = true;
    }
    public int GetLife()
    {
        return counLife;
    }
}
