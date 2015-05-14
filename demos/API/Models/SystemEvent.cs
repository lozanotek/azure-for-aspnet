namespace Orwell.API.Models {
    using System;

    public class SystemEvent {
		public DateTime Date { get; set; }
		public string Message { get; set; }
		public string User { get; set; }
	}
}
