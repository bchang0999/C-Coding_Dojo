class Ninja : Human
{
    public Ninja(string name): base (name){
        Dexterity = 175; 
    }

    public override int Attack (Human target){
        target.Health = target.Health -(5 * Dexterity);
        Random rand = new Random();
        int chance = rand.Next(0, 5);
        return target.Health;
    }

    public int steal (Human target)
    {
        target.Health = target.Health = 5;
        this.Health = this.Health +5;
        return this.Health;
    }
}