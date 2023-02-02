using UCl;


Bags bags = new Bags();
DrawManager drawManager = new DrawManager();
FixtureManager fixtureManager = new FixtureManager();
var result = drawManager.DrawForGroupStage(bags);
fixtureManager.CreateFixture(result);

while (true)
{
    Console.WriteLine("Choose one option:(1,2)");
    Console.WriteLine("1.See match results.");
    Console.WriteLine("2.See last 16");
    Console.WriteLine("3.See Groups");
    Console.WriteLine("4.Exit");
    int a = Convert.ToInt32(Console.ReadLine());
    if (a == 1)
    {
        Console.WriteLine(fixtureManager.PrepareMatchResults(fixtureManager.PlayedMatches));
    }
    else if (a == 2)
    {
        Console.WriteLine(fixtureManager.PrepareLast16(fixtureManager.GetLast16(result)));
    }
    else if (a == 3)
    {
        Console.WriteLine(fixtureManager.PrepareGroups(result));
    }
    else if (a == 4)
    {
        Console.WriteLine("Goodbye");
        break;
    }
    else
    {
        Console.WriteLine("Wrong choice. Please choose again.");
    }
}



