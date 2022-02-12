using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts {
    public class Buffer : MonoBehaviour {
        [SerializeField] private List<GameObject> buttons;
        [SerializeField] private GameObject gameController;

        private Player player;

        private void Awake() {
            player = GetComponent<Player>();
        }

        //1. Купить готовые решения (DamagePerClick * 3, Timer = 10s, Cost = 100$)
        public void BuySolution() {
            if (player.Money >= 100) {
                player.Money -= 100;
                Debug.Log($"У игрока теперь денег: {player.Money}");
                StartCoroutine(BuffDPC(3, 10f, 0));
            }
            else {
                Debug.Log($"У тебя нет денег, лох");
            }
        }
        
        //2. Бахнуть энергос (DamagePerClick * 2, Timer = 10s, Cost = 25$)
        public void DrinkEnergy() {
            if (player.Money >= 25) {
                player.Money -= 25;
                Debug.Log($"У игрока теперь денег: {player.Money}");
                StartCoroutine(BuffDPC(2, 10f, 1));
            }
            else {
                Debug.Log($"У тебя нет денег, лох");
            }
        }

        //3. Выпить пива (MentalHealth + 5, Cost = 30$)
        public void DrinkBeer() {
            if (player.Money >= 30) {
                player.Money -= 30;
                var mentalHealth = player.MentalHealth + 5;
                if (mentalHealth > player.MaxMentalHealth) {
                    player.MentalHealth = player.MaxMentalHealth;
                }
                else {
                    player.MentalHealth = mentalHealth;
                }

                Debug.Log($"Менталка: {player.MentalHealth}");
                Debug.Log($"У игрока теперь денег: {player.Money}");
            }
            else {
                Debug.Log($"У тебя нет денег, лох");
            }
        }

        //4. Войти в HARDMODE (DamagePerClick * 3, Timer = 10s, Cost = MentalHealth - 7)
        public void HardMode() {
            player.MentalHealth -= 7;
            StartCoroutine(BuffDPC(3, 10f, 3));
        }
        
        //5. Нанять индуса (DamagePerSecond + 0.5, Timer = 120s, Cost = 200$)
        public void HireIndus() {
            if (player.Money >= 200) {
                player.Money -= 200;
                StartCoroutine(BuffDPS(player.DamagePerSecond,
                    player.DamagePerSecond + 0.5f, 120));
            }
        }

        //6. Закрыть задачу (Закончить задачу??, Cost = 300$)
        public void BuyWin() {
            if (player.Money >= 300) {
                player.Money -= 300;
                DataHolder.playerMoney -= 300;
                gameController.GetComponent<GameController>().ExitToHub("win");
            }
            else {
                Debug.Log($"У тебя нет денег, лох");
            }
        }
        
        //Корутина, которая умножает урон по клику на multiplier, после чего возвращает его в исходное значение
        private IEnumerator BuffDPC(float multiplier, float seconds, int buttonIndex) {
            player.DamagePerClick *= multiplier;
            buttons[buttonIndex].GetComponent<Button>().interactable = false;
            Debug.Log($"Урон по клику: {player.DamagePerClick}");
            
            yield return new WaitForSeconds(seconds);

            player.DamagePerClick /= multiplier;
            buttons[buttonIndex].GetComponent<Button>().interactable = true;
            Debug.Log($"Урон по клику {player.DamagePerClick}");
        }
        
        //Корутина, которая увеличивает пассивный урон в секунду на какое-то значение, потом возвращает назад
        private IEnumerator BuffDPS(float previous, float temporary, float seconds) {
            player.DamagePerSecond = temporary;
            Debug.Log($"Пассивный дамаг: {player.DamagePerSecond}");
            
            yield return new WaitForSeconds(seconds);

            player.DamagePerSecond = previous;
            Debug.Log($"Пассивный дамаг: {player.DamagePerSecond}");
        }
    }
}