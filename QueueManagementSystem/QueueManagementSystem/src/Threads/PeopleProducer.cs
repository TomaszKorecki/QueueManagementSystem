using System;
using System.Threading;
using QueueManagementSystem.Factories;
using QueueManagementSystem.Model;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Threads {
	class PeopleProducer {
		
		private Institution institution;

		public void StartProducer(Institution institution) {
			this.institution = institution;
			
			Thread peopleProducerThread = new Thread(WorkThread);
			peopleProducerThread.Start();
		}

		 private void WorkThread() {
			 while (true) {
				 Person newPerson = PersonFactory.GetPerson();
				 //Console.WriteLine("Producing new guy: {0}", newPerson.Name);
				 institution.AddUnassignedPerson(newPerson);
				 Thread.Sleep(TimeUtils.EstimatePeopleProducingInterval()); 
			 }
		}
	}
}
