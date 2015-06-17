using System.Collections.Generic;
using QueueManagementSystem.Model;

namespace QueueManagementSystem.src.Model {
	class Institution {

		private List<Person> unassignedPeoples;

		public Institution() {
			unassignedPeoples = new List<Person>();
		}

		public void AddUnassignedPerson(Person person) {
			unassignedPeoples.Add(person);
		}
	}
}
