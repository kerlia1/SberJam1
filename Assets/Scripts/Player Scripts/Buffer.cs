using System;
using System.Collections;
using UnityEngine;

namespace Player_Scripts {
    public class Buffer : MonoBehaviour {

        private Player player;

        private void Awake() {
            player = GetComponent<Player>();
        }

        //1. Купить готовые решения (DamagePerClick * 3, Timer = 10s, Cost = 100$)
        //3. Бахнуть энергос (DamagePerClick * 2, Timer = 10s, Cost = 25$)
        public void BuySolution() {
            player.Money -= 100;
            Debug.Log($"У игрока теперь денег: {player.Money}");
            StartCoroutine(BuffDPC(player.DamagePerClick,
                player.DamagePerClick * 3, 10f));
        }
        
        public void DrinkEnergy() {
            player.Money -= 25;
            Debug.Log($"У игрока теперь денег: {player.Money}");
            StartCoroutine(BuffDPC(player.DamagePerClick,
                player.DamagePerClick * 2, 10f));
        }

        public IEnumerator BuffDPC(float previous, float temporary, float seconds) {
            player.DamagePerClick = temporary;
            Debug.Log($"Урон по клику: {player.DamagePerClick}");
            
            yield return new WaitForSeconds(seconds);

            player.DamagePerClick = previous;
            Debug.Log($"Урон по клику {player.DamagePerClick}");
        }

        //2. Выпить пива (MentalHealth + 5, Cost = 30$)
        public void DrinkBeer() {
            var mentalHealth = player.MentalHealth + 5;
            if (mentalHealth > player.MaxMentalHealth) {
                player.MentalHealth = player.MaxMentalHealth;
            }
            else {
                player.MentalHealth = mentalHealth;
            }
            Debug.Log($"Менталка: {player.MentalHealth}");
            
            player.Money -= 30;
            Debug.Log($"У игрока теперь денег: {player.Money}");
        }

        //4. ВОйти в HARDMODE (DamagePerClick * 3, Timer = 10s, Cost = MentalHealth - 7)
        public void HardMode() {
            player.MentalHealth -= 7;
            StartCoroutine(BuffDPC(player.DamagePerClick, player.DamagePerClick * 3, 10f));
        }
        
        //5. Нанять индуса (DamagePerSecond + 0.5, Timer = 120s, Cost = 200$)
        public void BuffDPS(int sum, float seconds, int cost) {
            
        }

        //6. Закрыть задачу (Закончить задачу??, Cost = 300$)
        public void BuyWin(int cost) {
            
        }
    }
}