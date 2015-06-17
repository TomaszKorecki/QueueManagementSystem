using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model {
	class InstitutionQueue {
		private const int DEFAULT_WAITING_TIME = 100;

		private int queueID;

		private Queue<Person> peopleInQueue = new Queue<Person>();
		private int serviceTime;
		private bool isQueueWorking;
		private bool queueWorkingOrder = false;

		private Thread queueThread;

		public bool IsQueueWorking {
			get { return isQueueWorking; }
		}

		public int QueueOccupancy {
			get { return peopleInQueue.Count; }
		}

		public InstitutionQueue(int serviceTime, int queueID) {
			this.serviceTime = serviceTime;
			this.queueID = queueID;
			queueThread = new Thread(QueueWorker);
		}

		private void RunQeueue() {
			if (!queueWorkingOrder) {
				queueWorkingOrder = true;
				isQueueWorking = true;
				queueThread.Start();
			}
		}

		private void StopQueue() {
			queueWorkingOrder = false;
		}

		private void QueueWorker() {
			while (queueWorkingOrder) {
				if (!peopleInQueue.Any()) {
					Thread.Sleep(Constants.GetTimeSpan(DEFAULT_WAITING_TIME));
				} else {
					Thread.Sleep(Constants.GetTimeSpan(serviceTime));
					Person person = peopleInQueue.Dequeue();
					Console.WriteLine("Queue {0} handle person {1}", queueID, person.Name);
				}
			}

			isQueueWorking = false;
		}

		public void EnableQueue(bool enable) {
			if (enable) {
				RunQeueue();
			} else {
				StopQueue();
			}
		}

		public void AddPersonToQueue(Person person) {
			peopleInQueue.Enqueue(person);
		}
	}
}
