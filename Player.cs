using System;

public class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
    public int Attack { get; set; }
    public int Armor { get; set; }
    public int Potions { get; set; }
    private static readonly Random random = new Random();

    public Player()
    {
        Health = 100;
        Gold = 50;
        Attack = 10;
        Armor = 5;
        Potions = 5;
    }

    public string GetStats()
    {
        return $"Zdrowie: {Health}\nZłoto: {Gold}\nAtak: {Attack}\nZbroja: {Armor}\nPotions: {Potions}";
    }

    public void DealDamage(Enemy enemy)
    {
        int attackValue = Attack + random.Next(5, 10);
        enemy.TakeDamage(attackValue);
    }

    public void TakeDamage(int damage)
    {
        int trueDamage = Math.Max(0, damage - Armor);
        Health = Math.Max(0, Health - trueDamage);
    }

    public void Heal()
    {
        if (Potions > 0)
        {
            int healAmount = 20;
            Health += healAmount;
            Potions--;
        }
    }

    public void Defend()
    {
        Armor += 5;
    }

    public void BuyWeapon(int cost, int attackIncrease)
    {
        if (Gold >= cost)
        {
            Gold -= cost;
            Attack += attackIncrease;
        }
    }

    public void BuyArmor(int cost, int armorIncrease)
    {
        if (Gold >= cost)
        {
            Gold -= cost;
            Armor += armorIncrease;
        }
    }

    public void BuyHealingPotion(int cost, int potions)
    {
        if (Gold >= cost)
        {
            Gold -= cost;
            Potions += potions;
        }
    }
    public void ResetHealth()
    {
        Health = 100;
    }

    public void AddGoldForWin()
    {
        Gold += 50;
    }

    public void AddGoldForLoss()
    {
        Gold += 10;
    }
}
