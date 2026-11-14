using InterfacesDemo.Interfaces;
using InterfacesDemo.Classes;

IAnimal[] animals =
{
    new Dog(),
    new Cat()
};

foreach (var animal in animals)
{
    animal.Speak();
}

Warrior warrior = new Warrior
{
    Name = "Aragorn",
    Health = 100,
    AttackPower = 25
};

warrior.Attack();
warrior.Defend();
warrior.TakeDamage(10);

ICombatant[] fighters =
{
    new Warrior { Name = "Aragorn", Health = 100, AttackPower = 25 },
    new Mage { Name = "Merlin", Health = 80, AttackPower = 40 }
};

foreach (var fighter in fighters)
{
    fighter.Attack();
    fighter.Defend();
}

Mage mage = fighters[1] as Mage;
mage.Heal(30);

if (mage is not null)
{
    mage.Heal(30);
}

Knight knight = new Knight();

IAttack attack = knight;
attack.Attack();

IDefend defend = knight;
defend.Attack();