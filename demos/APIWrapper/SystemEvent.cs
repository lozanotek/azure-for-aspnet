namespace Orwell.API.Client {
    using System;

    public class SystemEvent {
		public DateTime Date { get; set; }
		public string Message { get; set; }
		public string User { get; set; }

		public override string ToString() {
			return string.Format("Date: {0}\r\nMessage: {1}\r\nUser: {2}\r\n",
								 Date, Message, User);
		}
	}
}