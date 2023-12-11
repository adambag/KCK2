using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Enemy
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Armor { get; set; }

        public Player player;

        public Enemy(Player player)
        {
            this.player = player;
        }

        public Enemy()
        {
            Health = 100;
            Attack = 10;
            Armor = 5;
        }
        public void DealDamage(Player player)
        {
            Random random = new Random();
            int attack = Attack + random.Next(5, 10);
            player.TakeDamage(attack);
        }

        public void TakeDamage(int damage)
        {
            if (Armor > 0)
            {
                int trueDamage = damage - Armor;
                if (trueDamage < 0)
                {
                    trueDamage = 0;
                }
                Health -= trueDamage;
            }
            else
            {
                Health -= damage;
            }
        }
        public void EnemyHeal()
        {
            Random random = new Random();
            int healing = new Random().Next(5, 15);
            Health += healing;
        }
        public void EnemyDefend()
        {
            Random random = new Random();
            int defense = new Random().Next(5, 10);
            Armor += defense;
        }
    }

