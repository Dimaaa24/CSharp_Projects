namespace RemoteLearning.GrandCircus.Animals
{
    internal class Snake : AnimalBase
    {
        public override string SpeciesName { get; }

        public Snake(string name) : base(name)
        {
            SpeciesName = "Reptile";
        }

        public override string MakeSound()
        {
            return "Ssss!";
        }
    }
}