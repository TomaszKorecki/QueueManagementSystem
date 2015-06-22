using System;

namespace QueueManagementSystem.Utils {
	class TimeUtils {
		
		private const int MORNING_MIN = 10;
		private const int MORNING_MAX = 600;
		private const int NOON_MIN = 30;
		private const int NOON_MAX = 1800;
		private const int AFTERNOON_MIN = 1;
		private const int AFTERNOON_MAX = 180;
		private const int EVENING_MIN = 30;
		private const int EVENING_MAX = 600;
		private const int NIGHT_MIN = 1800;
		private const int NIGHT_MAX = 3600;
		private const int MILISECONDS_MULTIPLIER = 1000;
		public static int EstimatePeopleProducingInterval() {
			int hour = DateTime.Now.Hour;
			
			int seconds;
			
			//to improve...
			if (hour >= 6 && hour <= 9) {
				seconds = RandomUtils.NextInt(MORNING_MIN, MORNING_MAX);
			} else if (hour >= 10 && hour <= 13) {
				seconds = RandomUtils.NextInt(NOON_MIN, NOON_MAX);
			} else if (hour >= 14 && hour <= 18) {
				seconds = RandomUtils.NextInt(AFTERNOON_MIN, AFTERNOON_MAX);
			} else if (hour >= 19 && hour <= 21) {
				seconds = RandomUtils.NextInt(EVENING_MIN, EVENING_MAX);
			} else {
				seconds = RandomUtils.NextInt(NIGHT_MIN, NIGHT_MAX);
			}
			
			return ApplySimulationSpeed(seconds * MILISECONDS_MULTIPLIER);
		}

		public static int ApplySimulationSpeed(int miliseconds) {
			return (int)Math.Round(miliseconds * Configuration.getTimeRatio());
		}

	}
}
