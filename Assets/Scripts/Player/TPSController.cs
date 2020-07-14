using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    FPSController myFPSController;
    CharacterController myCC;
    // Start is called before the first frame update
    void Start()
    {
        myFPSController = GetComponent<FPSController>();
        myCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if(myFPSController.GetCanMove())
        {
            Vector3 Direction = new Vector3(Input.GetAxis("Horizontal") * myFPSController.walkingSpeed,0,
                                            Input.GetAxis("Vertical") * myFPSController.walkingSpeed);
            myCC.Move(Direction * Time.deltaTime);
        }
    }
}
