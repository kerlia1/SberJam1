using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Диапазон здоровья врага, нужно посчитать, сейчас значения взяты от балды
    //Здоровье должно быть кратно 5, поэтому значения маленькие, при инициализации
    // они скалируются (200 + 10-15{%} для прогрессии)
    private int lowerHealthBound = 10;
    private int higherHealthBound = 80;

    private float enemyHealth;
    /// <summary>
    /// Здоровье дедлайна. Снижается при клике и пассивно от улучшений
    /// </summary>
    public float EnemyHealth { get => enemyHealth; set => enemyHealth = value; }


    // Зачем?
    private int timeToDo;
    /// <summary>
    /// Время, выдаваемое на то, чтобы сделать таску
    /// </summary>
    public int TimeToDo { get => timeToDo; set => timeToDo = value; }

    private string taskName;
    /// <summary>
    /// Название таска
    /// </summary>
    public string TaskName { get => taskName; set => taskName = value; }

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// Инициализация параметров при спавне врага
    /// </summary>
    public void Init()
    {
        EnemyHealth = 10;
    }

    private void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
