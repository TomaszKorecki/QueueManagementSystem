using System;

namespace QueueManagementSystem.Utils {
	class TimeUtils {
		
		public static int EstimatePeopleProducingInterval() {
			int hour = DateTime.Now.Hour;
			
			int seconds;
			
			//to improve...
			if (hour >= 6 && hour <= 9) {
				seconds = RandomUtils.NextInt(10, 600);
			} else if (hour >= 10 && hour <= 13) {
				seconds = RandomUtils.NextInt(30, 1800);
			} else if (hour >= 14 && hour <= 18) {
				seconds = RandomUtils.NextInt(1, 180);
			} else if (hour >= 19 && hour <= 21) {
				seconds = RandomUtils.NextInt(30, 600);
			} else {
				seconds = RandomUtils.NextInt(1800, 3600);
			}
			
			return ApplySimulationSpeed(seconds * 1000);
		}

		public static int ApplySimulationSpeed(int miliseconds) {
			return (int)Math.Round(miliseconds * Configuration.getTimeRatio());
		}

	}
}
