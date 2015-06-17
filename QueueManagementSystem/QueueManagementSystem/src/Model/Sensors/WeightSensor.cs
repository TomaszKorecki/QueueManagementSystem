namespace QueueManagementSystem.Model.Sensors {
	class WeightSensor : NumericSensor {
		public float MeasurePerson(Person person) {
			return person.Weight;
		}
	}
}
