using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerMenu : MonoBehaviour
{
    [SerializeField]
    GameObject showThisLayer;
    [SerializeField]
    GameObject hideThisLayer;

    public void ChangeLayer()
    {
        showThisLayer.SetActive(true);
        hideThisLayer.SetActive(false);
    }
}
