using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject enemy;

    // Начало игры
    public bool isGameStarted = false;

    private void Awake()
    {
        isGameStarted = true;
    }

    private void Start()
    {
        if (isGameStarted)
        {
            CreateFirstEnemy();
        }
    }


    void CreateFirstEnemy()
    {
        Instantiate(enemy);
    }

    /// <summary>
    /// Тут будем создавать врага после самого первого старта(повешу на условие позже)
    /// </summary>
    /// <param name="id"></param>
    void CreateEnemy(int id)
    {
        Instantiate(enemy);
    }

}
