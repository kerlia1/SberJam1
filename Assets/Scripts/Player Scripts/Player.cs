using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private int mentalHealth = 50;
    /// <summary>
    /// Здоровье персонажа. Оно будет снижаться после каждого проекта и
    /// увеличиваться после прохождения ментального лечения.
    /// </summary>
    public int MentalHealth { get => mentalHealth; set { mentalHealth = value; } }

    
    private float damagePerClick = 1;
    /// <summary>
    /// Урон за клик по "дедлайну"
    /// </summary>
    public float DamagePerClick { get => damagePerClick; set { damagePerClick = value; } }


    // Валера пока считает.
    private float damagePerSecond = 0;
    /// <summary>
    /// Ежесекундный урон по "дедлайну"
    /// </summary>
    public float DamagePerSecond { get => damagePerSecond; set { damagePerSecond = value; } }


    // Тут будут апгрейды персонажа.

}
