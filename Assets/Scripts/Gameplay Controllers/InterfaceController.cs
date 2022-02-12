using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour {
    //Объекты, через которые проходит взаимодействие
    [SerializeField] Player player;
    [SerializeField] GameController gameController;


    //Объекты интерфейса, с которыми мы взаимодействуем
    [SerializeField] Text playerHp;
    [SerializeField] private Slider playerHpBar;

    [SerializeField] private Slider enemyHpBar;
    [SerializeField] private Image enemyHpBarFill;
    [SerializeField] private Text enemyNameText;

    [SerializeField] private TextMeshProUGUI moneyText;

    //Список цветов, в который красить Enemy Hp Bar
    private Color[] enemyColors = {
        new Color(1f, 0.99f, 0.71f),
        new Color(0.43f, 0.85f, 0.98f),
        new Color(1f, 0.65f, 0.35f),
        new Color(0.95f, 0.47f, 0.54f)
    };

    //Список названий тасков
    private string[] enemyNames = {
        "Прогаем проект...",
        "Фиксим баги...",
        "Тестируем...",
        "Деплоим на прод..."
    };

    private int enemyIndex;

    //Переменная, нужная для того, чтобы смотреть, когда сменился враг
    private int prevCount = 4;


    private void Start() {
        Init();
    }

    /// <summary>
    /// Инициализация всех параметров.
    /// </summary>
    public void Init() {
        playerHpBar.maxValue = player.MaxMentalHealth;
        enemyHpBar.maxValue = 48f;

        playerHp.text = $"{player.MentalHealth} / {player.MaxMentalHealth}";
        playerHpBar.value = player.MentalHealth;
        enemyHpBar.value = 48f;
        moneyText.text = $"<sprite asset=0> {player.Money}";
    }

    void Update() {
        
        playerHp.text = $"{player.MentalHealth} / {player.MaxMentalHealth}";
        playerHpBar.value = player.MentalHealth;
        if (gameController.enemies.Count != 0) {
            enemyHpBar.maxValue = gameController.enemies[0].GetComponent<Enemy>().MaxEnemyHealth;
            enemyHpBar.value =
                gameController.enemies[0].GetComponent<Enemy>().EnemyHealth;
        }

        if (prevCount != gameController.enemies.Count) {
            enemyIndex = (enemyIndex + 1) % 4;
            enemyHpBarFill.color = enemyColors[enemyIndex];
            enemyNameText.text = enemyNames[enemyIndex];
            prevCount = gameController.enemies.Count;
        }

        moneyText.text = $"<sprite index=0> {player.Money}";
    }
}