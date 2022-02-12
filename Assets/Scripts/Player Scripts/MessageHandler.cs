using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MessageHandler : MonoBehaviour {
    [SerializeField] private Text bubbleText;

    private string[] startMessages = {
        "Солнце уже встает, а я пока не собираюсь. А дедлайны то не спят!!!",
        "Опять работать на дядю! А мог бы открыть стартап и в ус не дуть.",
        "Правильный тайм-менеджмент - основа успеха. Видимо успех это не моё."
    };

    private string[] codingMessages = {
        "Давай, Ержан, работай, завтра будет поздно.",
        "Это не баг, а фича!",
        "Bugs, hex & source control!",
        "Если что-то может сломаться, оно должно сломаться именно сейчас...",
        "Как два байта переслать!",
        "Глаза болят, а руки делают!",
        "Работать, работать! Завтра будет уже поздно!"
    };

    private string[] buffMessages = {
        "Деньги нужны для того чтоб их тратить! И что, что я трачу их на работу, главное - продуктивность.",
        "Энергетики - это буквально читы в реальной жизни!",
        "Выпил пива и жить стало прямо приятнее!",
        "Ладно, пора по-настоящему сконцентрироваться!",
        "Умные люди говорят, что знакомства - ключ к успеху. Абсолютно с ними согласен."
    };

    private string[] phaseMessages = {
        "Опять кучу багов фиксить...",
        "Тааакс, с багфиксом покончено.",
        "Хорошее тестирование хороший прод не гарантирует!"
    };

    private IEnumerator GenerateRandomMessage() {
        yield return new WaitForSeconds(3f);
        while (true) {
            bubbleText.text = codingMessages[Random.Range(0, codingMessages.Length)];
            yield return new WaitForSeconds(4f);
        }
    }

    public void Start() {
        bubbleText.text = startMessages[Random.Range(0, startMessages.Length)];
        StartCoroutine(GenerateRandomMessage());
    }

    public void GenerateBuffMessage(int index) {
        bubbleText.text = buffMessages[index];
    }

    public void GeneratePhaseMessage(int index) {
        bubbleText.text = phaseMessages[index];
    }
}