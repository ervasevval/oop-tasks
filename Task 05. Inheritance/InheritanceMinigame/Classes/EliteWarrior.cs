namespace InheritanceMinigame.Classes;

public class EliteWarrior : Warrior
{
    public EliteWarrior(string name) : base($"Elite Member {name}")

    {
        //base always calls the parent constructor first

        AttackPower *= 2;// AtttackPower is inherited from Warrior, and we are doubling it for EliteWarrior
        ShieldBlock *= 2;
    }

    /*public override void PerformAttack(Character target)
     {
         Console.WriteLine($"{Name} swings a heavy greatsword at {target.Name}!");
         target.TakeDamage(AttackPower);
     }*/
}