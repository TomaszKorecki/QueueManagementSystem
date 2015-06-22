using System;

namespace QueueManagementSystem.Utils {
	class Configuration {
		
		private static int NUMBER_OF_QUEUES;
		private static int SIMULATION_SPEED_MULTIPLIER;
		
		public static void Initialize(int NumberOfQueues, int SimulationSpeedMultiplier) {
			NUMBER_OF_QUEUES = NumberOfQueues;
			SIMULATION_SPEED_MULTIPLIER = SimulationSpeedMultiplier;
		}
		
		public static float getTimeRatio() {
			return 1f / SIMULATION_SPEED_MULTIPLIER;
		}
		
		public static int getNumberOfQueues() {
			return NUMBER_OF_QUEUES;
		}
		
	}
}