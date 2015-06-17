using QueueManagementSystem.Model;
using QueueManagementSystem.Model.Sensors;

namespace QueueManagementSystem.src.Model.Sensors {
	class InvalidSensor : BoolSensor {
		public bool MeasurePerson(Person person) {
			return person.IsInvalid;
		}
	}
}
