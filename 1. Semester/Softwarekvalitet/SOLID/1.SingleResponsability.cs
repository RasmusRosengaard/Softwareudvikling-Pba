public class Repository
{
    public void Add(object entity)
    {
        // Code to add entity to the database
    }

    public void Update(object entity)
    {
        // Code to update entity in the database
    }

    public void Delete(object entity)
    {
        // Code to delete entity from the database
    }

    public void Log(string message)
    {
        // Code to log messages
    }
}
// Overholder ikke SRP, da Repository-klassen har flere ansvarsområder (databaseoperationer og logning). 
// Det ville være bedre at adskille logning i en separat klasse for at overholde Single Responsibility Principle.
// Derfor fjern Log-metoden fra Repository-klassen og opret en separat Logger-klasse, der håndterer logning.

public class Logger
{
    public void Log(string message)
    {
        // Code to log messages
    }
}