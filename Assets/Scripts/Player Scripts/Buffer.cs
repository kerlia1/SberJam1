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
        //3. Бахнуть энергос (DamagePerClick * 2, Timer = 10s, Cost = 25$)
        public void BuySolution() {
            if (player.Money >= 100) {
                player.Money -= 100;
                Debug.Log($"У игрока теперь денег: {player.Money}");
                StartCoroutine(BuffDPC(player.DamagePerClick,
                    player.DamagePerClick * 3, 10f, 0));
            }
            else {
                Debug.Log($"У тебя нет денег, лох");
            }
        }
        
        public void DrinkEnergy() {
            if (player.Money >= 25) {
                player.Money -= 25;
                Debug.Log($"У игрока теперь денег: {player.Money}");
                StartCoroutine(BuffDPC(player.DamagePerClick,
                    player.DamagePerClick * 2, 10f, 1));
            }
            else {
                Debug.Log($"У тебя нет денег, лох");
            }
        }

        public IEnumerator BuffDPC(float previous, float temporary, float seconds, int buttonIndex) {
            player.DamagePerClick = temporary;
            buttons[buttonIndex].GetComponent<Button>().interactable = false;
            Debug.Log($"Урон по клику: {player.DamagePerClick}");
            
            yield return new WaitForSeconds(seconds);

            player.DamagePerClick = previous;
            buttons[buttonIndex].GetComponent<Button>().interactable = true;
            Debug.Log($"Урон по клику {player.DamagePerClick}");
        }

        //2. Выпить пива (MentalHealth + 5, Cost = 30$)
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
            StartCoroutine(BuffDPC(player.DamagePerClick,
                player.DamagePerClick * 3, 10f, 3));
        }
        
        //5. Нанять индуса (DamagePerSecond + 0.5, Timer = 120s, Cost = 200$)
        public void HireIndus() {
            if (player.Money >= 200) {
                player.Money -= 200;
                StartCoroutine(BuffDPS(player.DamagePerSecond,
                    player.DamagePerSecond + 0.5f, 120));
            }
        }

        private IEnumerator BuffDPS(float previous, float temporary, float seconds) {
            player.DamagePerSecond = temporary;
            buttons[4].GetComponent<Button>().interactable = false;
            Debug.Log($"Пассивный дамаг: {player.DamagePerSecond}");
            
            yield return new WaitForSeconds(seconds);

            player.DamagePerSecond = previous;
            buttons[4].GetComponent<Button>().interactable = true;
            Debug.Log($"Пассивный дамаг: {player.DamagePerSecond}");
        }
        

        //6. Закрыть задачу (Закончить задачу??, Cost = 300$)
        public void BuyWin() {
            gameController.GetComponent<GameController>().ExitToHub("win");
        }
    }
}