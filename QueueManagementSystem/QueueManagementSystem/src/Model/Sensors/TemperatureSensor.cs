using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model.Sensors {
	class TemperatureSensor : NumericSensor {
		public double MeasurePerson(Person person) {
			double rand = RandomUtils.NextDouble();
			
			if (rand < 0.75) {
				return person.Temperature;
			} else if (rand > 0.88) {
				return person.Temperature + RandomUtils.NextDouble();
			} else {
				return person.Temperature - RandomUtils.NextDouble();
			}
		}
	}
}
