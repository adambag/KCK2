using System.Windows;

public class Store
{
    public Player Player { get; private set; }

    public Store(Player player)
    {
        this.Player = player;
    }

    public void BuyWeapon()
    {
        Player.BuyWeapon(20, 10);
    }

    public void BuyArmor()
    {
        Player.BuyArmor(15, 5);
    }

    public void BuyHealingPotion()
    {
        Player.BuyHealingPotion(10, 1);
        
    }

    private void ShowNotEnoughGoldMessage()
    {
        MessageBox.Show("Nie masz wystarczająco złota!", "Błąd zakupu");
    }

    private void ShowSuccessfulPurchaseMessage(string item)
    {
        MessageBox.Show($"Zakupiono {item} pomyślnie!", "Zakup udany");
    }
}
