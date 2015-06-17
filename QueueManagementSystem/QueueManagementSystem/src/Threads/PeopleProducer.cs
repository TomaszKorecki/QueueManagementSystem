using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using QueueManagementSystem.Factories;
using QueueManagementSystem.Model;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Threads {
	class PeopleProducer {
		//10 seconds
		public const int PEOPLE_PRODUCER_INTERVAL = 10000;

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
				 Person newPerson = PersonFactory.GetPerson();
				 Console.WriteLine("Producing new guy: {0}", newPerson.Name);
				 institution.AddUnassignedPerson(newPerson);
				 Thread.Sleep(Constants.GetTimeSpan(PEOPLE_PRODUCER_INTERVAL)); 
			 }
		}
	}
}
