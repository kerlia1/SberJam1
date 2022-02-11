using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject enemy;

    [SerializeField] List<GameObject> enemies;

    GameObject tempEnemy;

    private int playerDamagePerClick = 1;
    private int countOfEnemy = 0;
    // Начало игры
    public bool isGameStarted = false;



    private void Awake()
    {
        isGameStarted = true;
    }

    // Создаем самого первого врага.
    private void Start()
    {

    }


    private void Update()
    {

        // Создание врагов
        SpawnEnemy();
        // Запуск таймера
        gameObject.GetComponent<Timer>().StartTimer();

    }

    /// <summary>
    /// Спавн врагов
    /// запускается вместе с переходом на сцену
    /// по текущим параметрам врагов
    /// </summary>
    void SpawnEnemy()
    {
        if (isGameStarted)
        {
            if (enemy.GetComponent<Enemy>().EnemyHealth == 0 && countOfEnemy <= 3)
            {
                CreateEnemy();
            }
        }
        else
        {
            ExitToHub();
        }
    }

    /// <summary>
    /// Тут будем создавать врага после самого первого старта(повешу на условие позже)
    /// </summary>
    /// <param name="id"></param>
    void CreateEnemy()
    {
        countOfEnemy++;
        tempEnemy = Instantiate(enemy) as GameObject;
        enemies.Add(tempEnemy);
        Debug.Log($"Длина листа: {enemies.Count}");
    }





    public int count = 0;
    /// <summary>
    /// Наносит урон при клике
    /// </summary>
    public void DamageEnemyOnClick()
    {
        enemies[count].GetComponent<Enemy>().EnemyHealth -= playerDamagePerClick;
        Debug.Log($"Текущее здоровье врага: {enemies[count].GetComponent<Enemy>().EnemyHealth}");

        if (enemies[count].GetComponent<Enemy>().EnemyHealth == 0)
        {
            enemies.RemoveAt(0);
            if (enemies.Count == 0)
            {
                ExitToHub();
            }
        }
    }


    /// <summary>
    /// Принимаем состояние(победа/поражение)
    /// </summary>
    /// <param name="param"></param>
    public void ExitToHub(string param)
    {
        switch (param)
        {
            case "lose":
                Debug.Log("You loser!");
                break;
            case "win":
                break;
        }
        SceneManager.LoadScene("HubScene");
    }


    void ExitToHub()
    {
        SceneManager.LoadScene("HubScene");
        // Тут будет переход в хаб и смена переменных
    }
}
