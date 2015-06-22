using QueueManagementSystem.Model;
using QueueManagementSystem.Threads;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Launch {
	class Program {
		static void Main(string[] args) {
			
			//args[0] --> how many queues institution has
			//args[1] --> simulation speed (1 = normal, 5 = 5 times accelerated)

			ArgumentsParser argumentsParser = ArgumentsParser.Instance.Initialize(args);
			if (!argumentsParser.AreArgumentsValid || argumentsParser.IsInHelpMode) {
				return;
			}
			
			Configuration.Initialize(argumentsParser.NumberOfQueues, argumentsParser.SimulationSpeedMultiplier);

			Institution institution = new Institution();

			PeopleProducer peopleProducer = new PeopleProducer();
			peopleProducer.StartProducer(institution);
			
			for (int i = 1; i <= Configuration.getNumberOfQueues(); i++) {
				institution.AddQueue(new InstitutionQueue(i));
			}

			institution.StartInstitution();
		}
	}
}
