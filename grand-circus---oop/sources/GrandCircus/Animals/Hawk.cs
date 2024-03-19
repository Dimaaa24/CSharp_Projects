namespace RemoteLearning.GrandCircus.Animals
{
    internal class Hawk : AnimalBase
    {
        public override string SpeciesName { get; }

        public Hawk(string name) : base(name)
        {
            SpeciesName = "Bird";
        }

        public override string MakeSound()
        {
            return "Keee!";
        }
    }
}