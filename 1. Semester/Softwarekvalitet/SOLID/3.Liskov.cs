class Bird
{
    
}
class FlyingBird : Bird
{
    public void Fly()
    {
        Console.WriteLine("Flying..."); 
    }
}
class Sparrow : FlyingBird
{
    // Sparrow can fly, so it inherits from FlyingBird
    public virtual void Fly()
    {
        Console.WriteLine("Sparrow is flying...");
    }
}
class Ostrich : Bird
{
    // Ostrich cannot fly, so it does not inherit from FlyingBird, but bird
}

Bird bird = new Ostrich();
FlyingBird flyingBird = new Sparrow();
flyingBird.Fly(); // Output: Sparrow is flying...

// Overholder Liskov Substitution Principle, da både Sparrow da erstatte dens superklasse "FlyingBird". 
// Overholder Liskov Substitution Principle, da både Sparrow da Ostrich kan erstatte deres superklasse "Bird".
