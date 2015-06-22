using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model.Sensors {
	class WeightSensor : NumericSensor {
		public double MeasurePerson(Person person) {
			double rand = RandomUtils.NextDouble();
			
			if (rand < 0.95) {
				return person.Weight;
			} else if (rand > 0.98) {
				return person.Weight + (rand * RandomUtils.NextInt(3));
			} else {
				return person.Weight - (rand * RandomUtils.NextInt(3));
			}
		}
	}
}
