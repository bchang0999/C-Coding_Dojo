class Wizard : Human
{
    public Wizard(string name): base(name){
        Health = 50;
        Intelligence = 25;
    }

    public override int Attack(Human target)
    {
        int dmg = Intelligence * 5;
        target.Health -= dmg;
        Health += dmg;
        return target.Health;
    }

    public int Heal(Human target)
    {
        int heal = Intelligence * 10;
        target.Health += heal;
        return target.Health;
    }
}