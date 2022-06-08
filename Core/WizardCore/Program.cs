// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Human human1 = new Human("Hiyaw");
Samurai samurai1 = new Samurai("Kai");
Wizard wizard1 = new Wizard("Dumbledore");
samurai1.Attack(human1);
wizard1.Attack(samurai1);
System.Console.WriteLine(human1.Name +" "+ human1.Health+ " "+human1.Intelligence);
System.Console.WriteLine(samurai1.Name +" "+ samurai1.Health+ " "+samurai1.Intelligence);
samurai1.Meditate();
System.Console.WriteLine(samurai1.Name +" "+ samurai1.Health+ " "+samurai1.Intelligence);
samurai1.Attack(human1);
System.Console.WriteLine(human1.Name +" "+ human1.Health+ " "+human1.Intelligence);
samurai1.Attack(human1);
System.Console.WriteLine(human1.Name +" "+ human1.Health+ " "+human1.Intelligence);
samurai1.Attack(human1);
System.Console.WriteLine(human1.Name +" "+ human1.Health+ " "+human1.Intelligence);