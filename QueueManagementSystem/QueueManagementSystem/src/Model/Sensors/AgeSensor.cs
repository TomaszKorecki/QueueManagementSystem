using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model.Sensors {
	class AgeSensor : NumericSensor {
		public double MeasurePerson(Person person) {
			double rand = RandomUtils.NextDouble();
			
			if (rand <= 0.7) {
				return person.Age;
			} else if (rand > 0.85 ) {
				return person.Age + RandomUtils.NextInt(5);
			} else {
				return person.Age - RandomUtils.NextInt(5);
			}
			
		}
	}
}