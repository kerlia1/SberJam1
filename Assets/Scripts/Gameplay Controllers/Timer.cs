using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timerStart = 40f;
    public Text timerText;

    public bool Lose = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timerStart.ToString();
    }

    public void StartTimer()
    {
        timerStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timerStart).ToString();
        if (timerStart <= 0)
        {
            gameObject.GetComponent<GameController>().ExitToHub("lose");
            Lose = true;
        }
    }
}
