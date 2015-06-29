using System;
namespace QueueManagementSystem.Model {
	public class Person {

		public String Name { get; set; }
		public int Age { get; set; }
		public double Weight { get; set; }
		public bool IsPregnant { get; set; }
		public double Temperature { get; set; }
		public bool IsInvalid { get; set; }

		public override String ToString() {
			return Name + ": " + (IsPregnant ? "Pregnant" : "Not pregnant") + ", " + (IsInvalid ? "Invalid" : "Not invalid") +
					", " + Age + " years, " + (int)Weight + " kg, " + (int)Temperature + " st. C";

		}
	}
}

