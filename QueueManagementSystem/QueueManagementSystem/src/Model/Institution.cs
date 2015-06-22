using System.Collections.Generic;
using System.Linq;
using System.Threading;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model {
	class Institution {
		
		private const int PERSON_TO_QUEUE_INTERVAL = 100;

		private Queue<Person> unassignedPeople = new Queue<Person>();
		private List<InstitutionQueue> queues = new List<InstitutionQueue>();
		private Thread institutionThread;

		public void AddUnassignedPerson(Person person) {
			unassignedPeople.Enqueue(person);
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
			if (!unassignedPeople.Any()) {
				return;
			}
			
			Person person = unassignedPeople.Dequeue();
			ChooseQueue(person).AddPersonToQueue(person);
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
			return queues[0];
		}
	}
}
