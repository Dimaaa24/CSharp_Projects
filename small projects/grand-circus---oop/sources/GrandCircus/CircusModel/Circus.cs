using RemoteLearning.GrandCircus.Animals;
using RemoteLearning.GrandCircus.Presentation;
using System.Collections.Generic;

namespace RemoteLearning.GrandCircus.CircusModel
{
    internal class Circus
    {
        private readonly Arena arena;

        private List<IAnimal> animals;

        public Circus(Arena arena)
        {
            animals = new List<IAnimal> { new Snake("Pythonel"), new Elephant("Dumbo"), new Lion("Simba"), new Hawk("Hawky") };
            this.arena = arena;
        }

        public void Perform()
        {
            arena.PresentCircus("Grand Circus");
            foreach (IAnimal animal in animals)
            {
                arena.AnnounceAnimal(animal.Name, animal.SpeciesName);
                arena.DisplayAnimalPerformance(animal.MakeSound());
            }
        }
    }
}