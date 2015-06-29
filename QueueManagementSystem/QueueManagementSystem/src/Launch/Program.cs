using QueueManagementSystem.Model;
using QueueManagementSystem.Threads;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Launch {
	class Program {
		static void Main(string[] args) {
			//args[0] --> simulation speed (1 = normal, 5 = 5 times accelerated)
			//args[1] --> current hour (optional)

			ArgumentsParser argumentsParser = ArgumentsParser.Instance.Initialize(args);
			if (!argumentsParser.AreArgumentsValid || argumentsParser.IsInHelpMode) {
				return;
			}
			
			if (argumentsParser.IsCurrentHourPassed) {
				Configuration.Initialize(argumentsParser.SimulationSpeedMultiplier, argumentsParser.CurrentHour);
			} else {
				Configuration.Initialize(argumentsParser.SimulationSpeedMultiplier);
			}

			Institution institution = new Institution();

			PeopleProducer peopleProducer = new PeopleProducer();
			peopleProducer.StartProducer(institution);
			
			institution.AddQueue(new InstitutionQueue(1, institution));
			institution.AddQueue(new InstitutionQueue(2, institution));
			institution.AddQueue(new InstitutionQueue(3, institution));

			institution.StartInstitution();
		}
	}
}
