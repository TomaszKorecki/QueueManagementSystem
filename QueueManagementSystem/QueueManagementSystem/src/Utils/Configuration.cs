using System;

namespace QueueManagementSystem.Utils {
	class Configuration {
		
		private static int SIMULATION_SPEED_MULTIPLIER;
		
		public static void Initialize(int SimulationSpeedMultiplier) {
			SIMULATION_SPEED_MULTIPLIER = SimulationSpeedMultiplier;
		}
		
		public static float getTimeRatio() {
			return 1f / SIMULATION_SPEED_MULTIPLIER;
		}
	}
}