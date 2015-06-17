using QueueManagementSystem.Model;
using QueueManagementSystem.Threads;

namespace QueueManagementSystem.Launch {
	class Program {
		static void Main(string[] args) {

			Institution institution = new Institution();

			PeopleProducer peopleProducer = new PeopleProducer();
			peopleProducer.StartProducer(institution);

			InstitutionQueue queue1 = new InstitutionQueue(20000, 1);
			InstitutionQueue queue2 = new InstitutionQueue(25000, 2);
			InstitutionQueue queue3 = new InstitutionQueue(30000, 3);

			institution.AddQueue(queue1);
			institution.AddQueue(queue2);
			institution.AddQueue(queue3);

			institution.StartInstitution();
		}
	}
}
