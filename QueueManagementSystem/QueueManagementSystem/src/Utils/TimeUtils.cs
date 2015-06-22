using System;

namespace QueueManagementSystem.Utils {
	class TimeUtils {
		
		private static Random random = new Random((int) DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
		
		public static int EstimatePeopleProducingInterval() {
			int hour = DateTime.Now.Hour;
			
			int seconds;
			
			//to improve...
			if (hour >= 6 && hour <= 9) {
				seconds = random.Next(10, 600);
			} else if (hour >= 10 && hour <= 13) {
				seconds = random.Next(30, 1800);
			} else if (hour >= 14 && hour <= 18) {
				seconds = random.Next(1, 180);
			} else if (hour >= 19 && hour <= 21) {
				seconds = random.Next(30, 600);
			} else {
				seconds = random.Next(1800, 3600);
			}
			
			return ApplySimulationSpeed(seconds * 1000);
		}

		public static int ApplySimulationSpeed(int miliseconds) {
			return (int)Math.Round(miliseconds * Configuration.getTimeRatio());
		}

	}
}
