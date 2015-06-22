using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using QueueManagementSystem.Utils;

namespace QueueManagementSystem.Model {
	class InstitutionQueue {
		
		private const int CLIENT_SERVICE_TIME_MEAN = 90000;
		private const int CLIENT_SERVICE_TIME_STDDEV = 15000;
		private const int CLIENT_SERVICE_TIME_MIN = 10000;
		private const int CLIENT_SERVICE_TIME_MAX = 600000;
		private const int CHECKING_INTERVAL = 100;
		
		public int queueID { get; private set; }
		private Queue<Person> peopleInQueue = new Queue<Person>();
		private bool isQueueWorking;
		private bool queueWorkingOrder = false;

		private Thread queueThread;

		public bool IsQueueWorking {
			get { return isQueueWorking; }
		}

		public int QueueOccupancy {
			get { return peopleInQueue.Count; }
		}

		public InstitutionQueue(int queueID) {
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
					Thread.Sleep(TimeUtils.ApplySimulationSpeed(CHECKING_INTERVAL));
				} else {
					Thread.Sleep(TimeUtils.ApplySimulationSpeed((int) RandomUtils.NextGaussian(CLIENT_SERVICE_TIME_MEAN, CLIENT_SERVICE_TIME_STDDEV, CLIENT_SERVICE_TIME_MIN, CLIENT_SERVICE_TIME_MAX)));
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
