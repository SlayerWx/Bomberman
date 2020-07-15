using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    int myID;
    public static int turnID;
    public static int maxID = 0;
    public static int deadNumber;
    Vector3 nextPosition;
    int totalDirections = 4;
    [SerializeField]
    ObstacleDetection front;
    [SerializeField]
    ObstacleDetection back;
    [SerializeField]
    ObstacleDetection left;
    [SerializeField]
    ObstacleDetection right;
    Rigidbody myRigid;
    [SerializeField]
    float speed;
    bool firstTime;
    [SerializeField]
    float distanceNextPosition;
    Vector3 dir = Vector3.zero;
    float corrector = 0.4f;
    float WaitForCheck = 10.0f;
    Vector3 oldPos;
    bool myMoving;
    public delegate void PerderE();
    public static event PerderE EnemyDead;
    bool imAlive;
    float trashZone = 1000;
    void Start()
    {
        deadNumber = 1;
        turnID = 0;
        myRigid = GetComponent<Rigidbody>();
        firstTime = true;
        imAlive = true;
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (myID==turnID && imAlive)
        {
            if(firstTime)
            {
                firstTime = false;
                StartCoroutine("Moving");
            }
        }
        else if(!imAlive)
        {
            StopCoroutine("Moving");
        }
    }
    public void SetID()
    {
        myID = maxID;
        maxID += 1;
    }
    public int GetID()
    {
        return myID;
    }
    void ChangeTurn()
    {
        turnID++;
        if (turnID >= maxID)
        {
            turnID = 0;
        }
    }
    Vector3 MovingTo()
    {
        Vector3 w = Vector3.zero;
        switch(Random.Range(0,totalDirections))
        {
            case 0:
                if(!right.IsObstacle)
                w = Vector3.right;
                break;
            case 1:
                if (!left.IsObstacle)
                    w = Vector3.left;
                break;
            case 2:
                if (!front.IsObstacle)
                    w = Vector3.forward;
                break;
            case 3:
                if (!back.IsObstacle)
                    w = Vector3.back;
                break;
            default:
                Debug.LogError("Custom Error: Extra Direction not Implemented",gameObject);
                break;
        }
        return w;
    }
    IEnumerator CheckNextPos()
    {
        yield return new WaitForSeconds(WaitForCheck);
        if(transform.localPosition != nextPosition)
        {
            /*dir =(oldPos - transform.localPosition).normalized;
            nextPosition = oldPos;*/
            transform.localPosition = oldPos;
            nextPosition = oldPos;
            dir = Vector3.zero;
            
        }
    }
    IEnumerator Moving()
    {
        float timer = 0;
        myRigid.position = transform.position;
        dir = MovingTo();
        nextPosition = myRigid.position + (dir * distanceNextPosition);
        oldPos = myRigid.position;
        myMoving = true;
        while (myMoving)
        {
            myRigid.position = Vector3.Lerp(oldPos,nextPosition,timer);
            timer += Time.deltaTime;
            if(timer>1.0f)
            {
                myMoving = false;
            }
          yield return null;
        }
        firstTime = true;
        ChangeTurn();
    }
    public void ImDead()
    {
        EnemyDead?.Invoke();
        imAlive = false;
        deadNumber++;
        transform.position *= trashZone;
    }
}
