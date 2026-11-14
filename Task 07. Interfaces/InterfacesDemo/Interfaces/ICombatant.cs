using InterfacesDemo.Interfaces;
namespace InterfacesDemo.Interfaces;

public interface ICombatant : ICharacter
{
    int AttackPower { get; set; }

    void Attack();
    void Defend();
}