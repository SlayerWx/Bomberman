using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void EndLevel();
    public static event EndLevel EndThisLevel;
    [SerializeField]
    private int normalOBJPoint;
    [SerializeField]
    private int enemyPoint;
    [SerializeField]
    private int doorPoint;

    public int NormalOBJPoint { get => normalOBJPoint; set => normalOBJPoint = value; }
    public int EnemyPoint { get => enemyPoint; set => enemyPoint = value; }
    public int DoorPoint { get => doorPoint; set => doorPoint = value; }

    void Start()
    {
        Dead.PlayerDead += LossCondition;   
    }
    void LossCondition()
    {
        Time.timeScale = 0.0f;
        EndThisLevel?.Invoke();

    }
    private void OnDisable()
    {
        Dead.PlayerDead -= LossCondition;
    }
}
