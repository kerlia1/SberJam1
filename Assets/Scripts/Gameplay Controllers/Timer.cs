using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject player;

    public float timerStart = 40f;
    public Text timerText;

    public bool Lose = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timerStart.ToString();
        
        StartCoroutine(mentalDmgPerSec());
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

    IEnumerator mentalDmgPerSec()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(3);
            player.GetComponent<Player>().MentalHealth -= 1;
        }
        yield return null;
    }
}
