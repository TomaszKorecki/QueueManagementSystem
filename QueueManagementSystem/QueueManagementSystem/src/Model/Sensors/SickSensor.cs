using QueueManagementSystem.Model;
using QueueManagementSystem.Model.Sensors;

namespace QueueManagementSystem.src.Model.Sensors {
	class SickSensor : NumericSensor {
		public float MeasurePerson(Person person) {
			return person.SickDegreee;
		}
	}
}
