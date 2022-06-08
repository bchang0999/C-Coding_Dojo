class Samurai : Human{
    public Samurai (string name): base (name){
        Health = 200;
    }

    public override int Attack(Human Target)
    {
        base.Attack(Target);
        if (Target.Health < 50)
        {
            Target.Health = 0;
            Console.WriteLine( Name +  " assassinated " + Target.Name);
        }
        return Target.Health;

        }
    
    public void Meditate(){
        Health = 200;
    }
    }
