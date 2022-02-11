using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    //Объекты, через которые проходит взаимодействие
    [SerializeField] GameObject player;
    GameObject enemy;
    [SerializeField] GameObject gameController;
    [SerializeField] Text playerHp;
    

    private void Awake()
    {        
        Init();
        //playerHp.text = PlayerPrefs.GetInt("MentalHealt").ToString();
    }

    /// <summary>
    /// Инициализация всех параметров.
    /// </summary>
    public void Init()
    {
        //player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        playerHp.text = player.GetComponent<Player>().MentalHealth.ToString();
    }

    void Update()
    {
        playerHp.text = player.GetComponent<Player>().MentalHealth.ToString();
    }



}