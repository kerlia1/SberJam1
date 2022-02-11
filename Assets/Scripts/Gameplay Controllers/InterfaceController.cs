using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    //Объекты, через которые проходит взаимодействие
    GameObject player;
    GameObject enemy;
    [SerializeField] GameObject gameController;
    

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// Инициализация всех параметров.
    /// </summary>
    public void Init()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (gameController.GetComponent<GameController>().isGameStarted)
        {
            enemy = GameObject.FindWithTag("Enemy");
        }
    }



}