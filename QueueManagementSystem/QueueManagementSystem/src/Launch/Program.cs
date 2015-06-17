using QueueManagementSystem.src.Model;
using QueueManagementSystem.Threads;

namespace QueueManagementSystem.Launch {
	class Program {
		static void Main(string[] args) {

			Institution institution = new Institution();

			PeopleProducer peopleProducer = new PeopleProducer();
			peopleProducer.StartProducer(institution);


		}
	}
}
