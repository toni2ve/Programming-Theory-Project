using System.Drawing;

public class WeakEnemy : Enemy
{
    public WeakEnemy()
    {
        this.health = 1;
        this.color = Color.White;
        this.damage = 1;
    }
}
