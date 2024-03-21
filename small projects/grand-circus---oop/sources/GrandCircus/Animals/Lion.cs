namespace RemoteLearning.GrandCircus.Animals
{
    internal class Lion : AnimalBase
    {
        public override string SpeciesName { get; }

        public Lion(string name) : base(name)
        {
            SpeciesName = "Feline";
        }

        public override string MakeSound()
        {
            return "Roaaar!";
        }
    }
}