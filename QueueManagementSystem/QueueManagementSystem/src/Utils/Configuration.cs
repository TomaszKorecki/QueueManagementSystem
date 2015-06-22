using System;

namespace QueueManagementSystem.Utils {
	class Configuration {
		
		private static int SIMULATION_SPEED_MULTIPLIER;
		private static bool IS_CURRENT_HOUR_SET;
		private static int CURRENT_HOUR;
		
		public static void Initialize(int SimulationSpeedMultiplier) {
			SIMULATION_SPEED_MULTIPLIER = SimulationSpeedMultiplier;
			IS_CURRENT_HOUR_SET = false;
		}
		
		public static void Initialize(int SimulationSpeedMultiplier, int CurrentHour) {
			SIMULATION_SPEED_MULTIPLIER = SimulationSpeedMultiplier;
			IS_CURRENT_HOUR_SET = true;
			CURRENT_HOUR = CurrentHour;
		}
		
		public static float getTimeRatio() {
			return 1f / SIMULATION_SPEED_MULTIPLIER;
		}
		
		public static bool IsCurrentHourSet() {
			return IS_CURRENT_HOUR_SET;
		}
		
		public static int GetCurrentHour() {
			return CURRENT_HOUR;
		}
	}
}