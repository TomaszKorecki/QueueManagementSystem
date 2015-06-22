using System;

namespace QueueManagementSystem.Launch {
	class ArgumentsParser {

		private static ArgumentsParser instance;
		
		public int NumberOfQueues { get; set; }
		public int SimulationSpeedMultiplier { get; set; }
		public bool AreArgumentsValid { get; set; }
		public bool IsInHelpMode { get; set; }
		
		private ArgumentsParser() {}
		
		public static ArgumentsParser Instance {
			get {
				if (instance == null) {
					instance = new ArgumentsParser();
				}
				return instance;
			}
		}
		
		public ArgumentsParser Initialize(string[] args) {
			if (args.Length == 1) {
				if (args[0].Equals("-h", StringComparison.CurrentCultureIgnoreCase)) {
					AreArgumentsValid = true;
					IsInHelpMode = true;
					Console.WriteLine("Queue Management System - intelligent and transparent system for managing queues in various institutions.\n\n" +
                		"Command line arguments:\n\n" +
		                "QMS.exe a b\n\n" +
		                "a - number of queues in institution\n" +
		                "b - simulation speed multiplier (1 -> normal, 5 -> 5 times accelerated, etc.)\n");
				} else {
					Console.WriteLine("Incorrect arguments list. Run program with -h option to see help.");
					AreArgumentsValid = false;
				}
			} else if (args.Length == 2) {
				try {
					NumberOfQueues = int.Parse(args[0]);
					SimulationSpeedMultiplier = int.Parse(args[1]);
					AreArgumentsValid = true;
					IsInHelpMode = false;
				} catch (Exception) {
					AreArgumentsValid = false;
					Console.WriteLine("Some of arguments are invalid. Run program with -h option to see help.");
				}
				return instance;
			} else {
				Console.WriteLine("Incorrect arguments list. Run program with -h option to see help.");
				AreArgumentsValid = false;
			}
			return instance;
		}
		
	}
}