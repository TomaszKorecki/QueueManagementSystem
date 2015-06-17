using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using QueueManagementSystem.Model;
using QueueManagementSystem.src.Model;

namespace QueueManagementSystem.Threads {
	class PeopleProducer {
		public const int PEOPLE_PRODUCER_INTERVAL = 1000;

		private bool producerStarted = false;
		private Institution institution;

		public void StartProducer(Institution 
			institution) {
			this.institution = institution;
			
			Thread peopleProducerThread = new Thread(WorkThread);
			peopleProducerThread.Start();
		}

		 private void WorkThread() {
			 while (true) {
				 Console.WriteLine("Producing new guy...");
				 institution.AddUnassignedPerson(new Person());
				 Thread.Sleep(PEOPLE_PRODUCER_INTERVAL); 
			 }
		}
	}
}
