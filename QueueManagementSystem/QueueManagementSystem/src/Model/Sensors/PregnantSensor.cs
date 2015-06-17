namespace QueueManagementSystem.Model.Sensors {
	class PregnantSensor : BoolSensor {
		public bool MeasurePerson(Person person) {
			return person.IsPregnant;
		}
	}
}
