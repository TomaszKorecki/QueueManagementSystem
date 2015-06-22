using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model.Sensors {
	class InvalidSensor : BoolSensor {
		public bool MeasurePerson(Person person) {
			if (RandomUtils.NextDouble() < 0.9) {
				return person.IsInvalid;
			}
			
			return !person.IsInvalid;
		}
	}
}
