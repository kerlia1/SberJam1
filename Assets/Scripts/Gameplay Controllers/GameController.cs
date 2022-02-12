using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] GameObject enemy;

    [SerializeField] public List<GameObject> enemies;

    GameObject tempEnemy;

    private int playerDamagePerClick = 1;
    private int countOfEnemy = 0;
    // Начало игры
    public bool isGameStarted = false;



    private void Awake()
    {
        isGameStarted = true;
        ChangePlayerParams();
    }



    private void Update()
    {
        // Создание врагов
        SpawnEnemy();
        // Запуск таймера
        gameObject.GetComponent<Timer>().StartTimer();
    }

    void SavePlayerParams()
    {
        Debug.Log("Сохраняем данные");
        DataHolder.playerMentalHealth = player.GetComponent<Player>().MentalHealth;
        DataHolder.playerMoney = player.GetComponent<Player>().Money;
    }

    void ChangePlayerParams()
    {
        player.GetComponent<Player>().MentalHealth = DataHolder.playerMentalHealth;
        player.GetComponent<Player>().Money = DataHolder.playerMoney;
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
            if (enemy.GetComponent<Enemy>().EnemyHealth <= 0 && countOfEnemy <= 3)
            {
                CreateEnemy();
            }
        }
        else
        {
            ExitToHub("win");
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
        enemies[count].GetComponent<Enemy>().EnemyHealth -= player.GetComponent<Player>().DamagePerClick;
        Debug.Log($"Текущее здоровье врага: {enemies[count].GetComponent<Enemy>().EnemyHealth}");

        if (enemies[count].GetComponent<Enemy>().EnemyHealth <= 0)
        {
            enemies.RemoveAt(0);
            if (enemies.Count == 0)
            {
                ExitToHub("win");
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
                player.GetComponent<Player>().MentalHealth -= 10;
                break;
            case "win":
                player.GetComponent<Player>().Money += 100;
                int mentalHealth = player.GetComponent<Player>().MentalHealth + 5;
                if (mentalHealth > player.GetComponent<Player>().MaxMentalHealth)
                {
                    player.GetComponent<Player>().MentalHealth = player.GetComponent<Player>().MaxMentalHealth;
                }
                else
                {
                    player.GetComponent<Player>().MentalHealth = mentalHealth;
                }
                break;
        }
        SavePlayerParams();
        SceneManager.LoadScene("HubScene");
    }

}


