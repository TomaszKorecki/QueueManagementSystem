using System;

namespace QueueManagementSystem.Launch {
	class ArgumentsParser {

		private static ArgumentsParser instance;
		
		public int SimulationSpeedMultiplier { get; private set; }
		public int CurrentHour { get; private set; }
		public bool IsCurrentHourPassed { get; private set; }
		public bool AreArgumentsValid { get; private set; }
		public bool IsInHelpMode { get; private set; }
		
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
			if (args.Length == 1 && args[0].Equals("-h", StringComparison.CurrentCultureIgnoreCase)) {
				AreArgumentsValid = true;
				IsInHelpMode = true;
				printHelpInfo();
			} else if (args.Length == 1 || args.Length == 2) {
				try {
					SimulationSpeedMultiplier = int.Parse(args[0]);
					IsCurrentHourPassed = args.Length == 2;
					if (IsCurrentHourPassed) {
						CurrentHour = int.Parse(args[1]);
					}
					
					printWelcomeInfo(IsCurrentHourPassed);
					
					AreArgumentsValid = true;
					IsInHelpMode = false;
				} catch (Exception) {
					AreArgumentsValid = false;
					Console.WriteLine("Some of arguments are invalid. Run program with -h option to see help.");
				}
			} else {
				Console.WriteLine("Incorrect arguments list. Run program with -h option to see help.");
				AreArgumentsValid = false;
			} 
			return instance;
		}
		
		private void printHelpInfo() {
			Console.WriteLine("Queue Management System - intelligent and transparent system for managing queues in various institutions.\n\n" +
            		"Command line arguments:\n\n" +
	                "QMS.exe a [b]\n\n" +
	                "a - simulation speed multiplier (1 -> normal, 5 -> 5 times accelerated, etc.)\n" + 
					"[b] - aktualna godzina (argument opcjonalny)");
		}
		
		private void printWelcomeInfo(bool isCurrentHourPassed) {
			Console.WriteLine("---------------------------------------------------------------------\n" + 
				"Welcome in Queue Management System!\n" +
				"---------------------------------------------------------------------\n" + 
				"Configuration in use:\n" +
                "Simulation Speed Multiplier = {0}", SimulationSpeedMultiplier);
				
			if (isCurrentHourPassed) {
				Console.WriteLine("Current Hour = {0}\n", CurrentHour);
			}
			Console.WriteLine("---------------------------------------------------------------------\n");
		}
		
	}
}