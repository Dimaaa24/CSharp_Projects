namespace RemoteLearning.GrandCircus.Animals
{
    internal class Elephant : AnimalBase
    {
        public override string SpeciesName { get; }

        public Elephant(string name):base(name)
        {
            SpeciesName = "Mammal";
        }

        public override string MakeSound()
        {
            return "Trumpet!";
        }
    }
}