using System;

namespace QueueManagementSystem.Utils {
	class Constants {
		public const float TIME_RATIO = 0.1f;

		public static int GetTimeSpan(int miliseconds) {
			return (int)Math.Round(miliseconds*TIME_RATIO);
		}
	}
}
