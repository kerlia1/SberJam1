using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HubController : MonoBehaviour {
    [SerializeField] private Slider healthBar;
    [SerializeField] private Text playerHp;
    [SerializeField] private TextMeshProUGUI moneyText;

    public void Start() {
        healthBar.value = DataHolder.playerMentalHealth;
        playerHp.text = $"{DataHolder.playerMentalHealth}/50";
        moneyText.text = $"<sprite index=0>{DataHolder.playerMoney}";
    }

    public void StartGame() {
        SceneManager.LoadScene("GameplayScene");
    }
}