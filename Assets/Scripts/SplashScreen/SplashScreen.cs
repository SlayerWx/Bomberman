using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField]
    private float timer;
    [SerializeField]
    private GameObject empresa;
    [SerializeField]
    private GameObject juego;
    void Start()
    {
        StartCoroutine(Sequence());
    }
    IEnumerator Sequence()
    {
        empresa.SetActive(true);
        juego.SetActive(false);
        yield return new WaitForSeconds(timer);
        empresa.SetActive(false);
        juego.SetActive(true);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);


    }
}
