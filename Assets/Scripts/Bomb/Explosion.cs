using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float TimeToExplosion;
    [SerializeField]
    private float intervalTickColor;
    [SerializeField]
    private float timeInExplosion;
    private float timer;
    [SerializeField]
    private MeshRenderer myMesh;
    private Color startColor;
    [SerializeField]
    private GameObject[] particle;
    bool particleActivate;
    void Start()
    {
        startColor = myMesh.material.color;
        timer = 0;
        StartCoroutine("Secuence");
        particleActivate = false;
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].SetActive(false);
        }
    }
   
    IEnumerator Secuence()
    {
        while (timer<TimeToExplosion)
        {
            if (myMesh.material.color == Color.white) myMesh.material.color = startColor;
            else                                 myMesh.material.color = Color.white;
            timer += Time.deltaTime;
            yield return new WaitForSeconds(intervalTickColor);
        }
        if(myMesh.material.color == Color.white) myMesh.material.color = startColor;
        myMesh.enabled = false;
        particleActivate = true;
        for(int i = 0; i < particle.Length;i++)
        {
            particle[i].SetActive(true);
        }
        yield return new WaitForSeconds(timeInExplosion);
        SpawnBomb.bombCount--;
        Destroy(transform.gameObject);
    }
}
