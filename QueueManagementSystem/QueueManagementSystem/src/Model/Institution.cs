using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model {
	class Institution {
		private const int PERSON_TO_QUEUE_INTERVAL = 1000;

		private Queue<Person> unassignedPeople = new Queue<Person>();
		private List<InstitutionQueue> queues = new List<InstitutionQueue>();
		private Random random = new Random();

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
			//Take first unassigned person and add it to the random queue
			//queues[random.Next(0, GetWorkingQueues() - 1)].AddPersonToQueue(unassignedPeople.Dequeue());
			if (!unassignedPeople.Any()) return;
			var workingQueues = GetWorkingQueues().ToList();
			if (workingQueues.Any()) {
				workingQueues[random.Next(workingQueues.Count)].AddPersonToQueue(unassignedPeople.Dequeue());
			}
		}

		private void InstitutionWorker() {
			while (true) {
				Thread.Sleep(Constants.GetTimeSpan(PERSON_TO_QUEUE_INTERVAL));
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
	}
}
