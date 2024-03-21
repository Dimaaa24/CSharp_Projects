namespace RemoteLearning.GrandCircus.Animals
{
    internal abstract class AnimalBase : IAnimal
    {
        public string Name { get; }

        public abstract string SpeciesName { get; }

        protected AnimalBase(string name)
        {
            Name = name;
        }

        public abstract string MakeSound();
    }
}