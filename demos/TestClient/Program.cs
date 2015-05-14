namespace TestClient {
	using System;
	using System.Threading;
	using Orwell.API.Client;

    class Program {
		static void Main() {
			var logClient = new LogClient();

			for (int i = 0; i < 200; i++) {
				logClient.LogEvent(
					string.Format("Current Event: {0}", i),
					Environment.MachineName,
					DateTime.UtcNow);

				Console.WriteLine("Current Event: {0}", i);
				Thread.Sleep(1500);
			}

			var events = logClient.GetEvents();
			foreach (var systemEvent in events) {
				Console.Write(systemEvent);
			}

			//logClient.Clear();

			Console.Write("Press any key to exit...");
			Console.ReadKey(true);
		}
	}
}
