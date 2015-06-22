using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model.Sensors {
	class PregnantSensor : BoolSensor {
		public bool MeasurePerson(Person person) {
			if (RandomUtils.NextDouble() < 0.9) {
				return person.IsPregnant;
			}
			
			return !person.IsPregnant;
		}
	}
}
