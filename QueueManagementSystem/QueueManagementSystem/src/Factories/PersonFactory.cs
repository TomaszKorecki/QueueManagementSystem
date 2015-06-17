using System.Security.Cryptography;
using QueueManagementSystem.Model;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Factories {

	class PersonFactory {

		public static Person GetPerson() {
			return new Person() {Name = RandomNameGenerator.GetRandomName()};
		}
	}
}
