using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using QueueManagementSystem.Model.Sensors;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model {
	class Institution {
		
		private const int PERSON_TO_QUEUE_INTERVAL = 30000;

		private Queue<Person> unassignedPeople = new Queue<Person>();
		private List<InstitutionQueue> queues = new List<InstitutionQueue>();
		private Thread institutionThread;

		private AgeSensor ageSensor = new AgeSensor();
		private InvalidSensor invalidSensor = new InvalidSensor();
		private PregnantSensor pregnantSensor = new PregnantSensor();
		private TemperatureSensor temperatureSensor = new TemperatureSensor();
		private WeightSensor weightSensor = new WeightSensor();

		public void AddUnassignedPerson(Person person) {
			lock (unassignedPeople) {
				unassignedPeople.Enqueue(person);
			}
			
			DebugInstituteStatus();
		}

		private void RunAllQueues() {
			foreach (InstitutionQueue queue in queues) {
				queue.EnableQueue(true);
			}
		}

		private IEnumerable<InstitutionQueue> GetWorkingQueues() {
			return queues.Where(a => a.IsQueueWorking);
		}

		private void HandleNextPerson() {
			lock (unassignedPeople) {
				if (!unassignedPeople.Any()) {
					return;
				}

				Person person = unassignedPeople.Dequeue();
				ChooseQueue(person).AddPersonToQueue(person);
			}
			
			DebugInstituteStatus();
		}

		private void InstitutionWorker() {
			while (true) {
				Thread.Sleep(TimeUtils.ApplySimulationSpeed(PERSON_TO_QUEUE_INTERVAL));
				HandleNextPerson();
			}
		}

		public void StartInstitution() {
			RunAllQueues();
			institutionThread = new Thread(InstitutionWorker);
			institutionThread.Start();
		}

		public void AddQueue(InstitutionQueue instituteQueue) {
			queues.Add(instituteQueue);
		}
		
		private InstitutionQueue ChooseQueue(Person person) {
			bool isPersonInvalid = invalidSensor.MeasurePerson(person);
			bool isPersonPregnant = pregnantSensor.MeasurePerson(person);

			double personTemperature = temperatureSensor.MeasurePerson(person);
			double personWeight = weightSensor.MeasurePerson(person);
			double personAge = ageSensor.MeasurePerson(person);

			if (isPersonInvalid|| isPersonPregnant) {
				return queues.SingleOrDefault(a => a.queueID == 1);
			}

			if (personTemperature > 37 || personWeight > 100 || personAge > 60) {
				return queues.SingleOrDefault(a => a.queueID == 2);
			}

			return queues.SingleOrDefault(a => a.queueID == 3);
		}

		public void DebugInstituteStatus() {
			Console.Clear();

				foreach (var person in unassignedPeople) {
					Console.WriteLine(person);
				}


				foreach (var institutionQueue in queues) {
					Console.WriteLine(institutionQueue);
				}
			}
	}
}
