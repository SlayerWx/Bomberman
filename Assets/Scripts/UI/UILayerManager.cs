using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UILayerManager : MonoBehaviour
{
    #region layer
    [SerializeField]
    GameObject endLayer;
    #endregion
    #region HP
    [SerializeField]
    TextMeshProUGUI HP;
    [SerializeField]
    Dead player;
    #endregion
    #region enemyCount
    [SerializeField]
    TextMeshProUGUI enemyDead;
    #endregion
    #region points
    [SerializeField]
    TextMeshProUGUI points;
    [SerializeField]
    SpawnBomb plPoints;
    [SerializeField]
    LevelManager lvlManager;
    #endregion
    #region time
    [SerializeField]
    TextMeshProUGUI time;
    float timerS;
    int timerM;
    const int OneMinuteInSeconds = 60;
    #endregion
    #region distance
    [SerializeField]
    TextMeshProUGUI bomb;
    [SerializeField]
    TextMeshProUGUI distance;
    #endregion
    [SerializeField]
    TextMeshProUGUI winLoss;
    void Start()
    {
        timerM = 0;
        timerS = 0.0f;
        LevelManager.EndThisLevel += ActiveEndLayer;
        MyDestroy.IncreasCoin +=PointIncreasDestroyingNormalObj;
    }

    void Update()
    {
        Life();
        EnemyDead();
        Points();
        MyTime();
    }
    void ActiveEndLayer()
    {
        if (player.GetLife() > 0) winLoss.text = "You Win!";
        else winLoss.text = "You Loss!";
        EnemyMovement.maxID = 0;
        EnemyMovement.deadNumber = 1;
        endLayer.SetActive(true);
    }
    void Life()
    {
        HP.text = player.GetLife().ToString();
    }
    void EnemyDead()
    {
        enemyDead.text = "0";
    }
    void Points()
    {
        points.text = "0";
    }
    void PointIncreasDestroyingNormalObj()
    {
        plPoints.SetPoints(plPoints.GetPoints()+lvlManager.NormalOBJPunctuation);
    }
    void PointIncreasDestroyEnemy()
    {

    }
    void PointIncreasDoorEntry()
    {

    }
    void MyTime()
    {
        timerS += Time.deltaTime;
        time.text = TimerToMinutes();
    }
    string TimerToMinutes()
    {
        if(timerS>=60.0f)
        {
            timerM++;
            timerS = 0;
        }
        if (timerS >= 10.0f) return timerM + ":" + (int)timerS;
        else return timerM + ":0" + (int)timerS;
    }
    void OnDisable()
    {
        LevelManager.EndThisLevel -= ActiveEndLayer;
    }


}
