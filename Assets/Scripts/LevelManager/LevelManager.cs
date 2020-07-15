using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void EndLevel();
    public static event EndLevel EndThisLevel;
    [SerializeField]
    private int normalOBJPunctuation;
    [SerializeField]
    private int enemyPunctuation;
    [SerializeField]
    private int doorPunctuation;

    public int NormalOBJPunctuation { get => normalOBJPunctuation; set => normalOBJPunctuation = value; }
    public int EnemyPunctuation { get => enemyPunctuation; set => enemyPunctuation = value; }
    public int DoorPunctuation { get => doorPunctuation; set => doorPunctuation = value; }

    void Start()
    {
        Dead.PlayerDead += LossCondition;
        OpenTheDoor.Winner += WinCondition;
        Time.timeScale = 1.0f;
    }
    void LossCondition()
    {
        Time.timeScale = 0.0f;
        EndThisLevel?.Invoke();

    }
    void WinCondition()
    {
        Time.timeScale = 0.0f;
        EndThisLevel?.Invoke();
    }
    private void OnDisable()
    {
        Dead.PlayerDead -= LossCondition;
        OpenTheDoor.Winner -= WinCondition;
    }
}
