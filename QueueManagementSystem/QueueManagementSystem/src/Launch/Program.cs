using QueueManagementSystem.Model;
using QueueManagementSystem.Threads;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Launch {
	class Program {
		static void Main(string[] args) {
			//args[0] --> simulation speed (1 = normal, 5 = 5 times accelerated)

			ArgumentsParser argumentsParser = ArgumentsParser.Instance.Initialize(args);
			if (!argumentsParser.AreArgumentsValid || argumentsParser.IsInHelpMode) {
				return;
			}
			
			Configuration.Initialize(argumentsParser.SimulationSpeedMultiplier);

			Institution institution = new Institution();

			PeopleProducer peopleProducer = new PeopleProducer();
			peopleProducer.StartProducer(institution);
			
			institution.AddQueue(new InstitutionQueue(1));
			institution.AddQueue(new InstitutionQueue(2));
			institution.AddQueue(new InstitutionQueue(3));

			institution.StartInstitution();
		}
	}
}
