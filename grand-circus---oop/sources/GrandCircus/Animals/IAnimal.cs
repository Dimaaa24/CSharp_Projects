namespace RemoteLearning.GrandCircus.Animals
{
    internal interface IAnimal
    {
        string Name { get; }

        string SpeciesName { get; }

        string MakeSound();
    }
}