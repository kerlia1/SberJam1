using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerStart = 40f;
    [SerializeField] Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timerStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timerStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timerStart).ToString();
        if(timerStart <= 0)
        {
            timerStart = 40;
        }
    }
}
