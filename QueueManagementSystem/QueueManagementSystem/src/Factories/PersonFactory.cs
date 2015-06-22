using QueueManagementSystem.Model;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Factories {

	class PersonFactory {
		
		private const double WEIGHT_MEAN = 70d;
		private const double TEMPERATURE_MEAN = 36.6d;
		private const double PREGNANT_COEFFICIENT = 0.009770294d;
		
		private const double INVALID_COEFFICIENT = 0.16d;

		public static Person GetPerson() {
			Person person = new Person();
			
			//name
			person.Name = RandomNameGenerator.GetRandomName();
			
			//age
			if (RandomUtils.NextInt(100) < 40) {
				person.Age = (int) RandomUtils.NextGaussian(25, 3, 10, 100);
			} else {
				person.Age = (int) RandomUtils.NextGaussian(50, 10, 10, 100);
			}
			
			//weight
			person.Weight = RandomUtils.NextGaussian(WEIGHT_MEAN, 10, 25, 200);
			
			//isPregnant
			person.IsPregnant = RandomUtils.NextDouble() < PREGNANT_COEFFICIENT;
			
			//temperature
			person.Temperature = RandomUtils.NextGaussian(TEMPERATURE_MEAN, 0.3);
			
			//isInvalid
			person.IsInvalid = RandomUtils.NextDouble() < INVALID_COEFFICIENT;
				
			return person;
		}
	}
}
