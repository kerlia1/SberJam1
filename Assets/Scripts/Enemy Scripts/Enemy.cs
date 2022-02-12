using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float enemyHealth;
    /// <summary>
    /// Здоровье дедлайна. Снижается при клике и пассивно от улучшений
    /// </summary>
    public float EnemyHealth { get => enemyHealth; set => enemyHealth = value; }

    private float maxEnemyHealth;

    /// <summary>
    /// Максимальное здоровье дедлайна.
    /// </summary>
    public float MaxEnemyHealth { get => maxEnemyHealth; set => maxEnemyHealth = value; }

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// Инициализация параметров при спавне врага
    /// </summary>
    public void Init()
    {
        EnemyHealth = Random.Range(40f, 48f);
        MaxEnemyHealth = EnemyHealth;
    }

    private void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);

        }
    }
}
