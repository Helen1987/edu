using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.Threading.AsyncProgModel;
using System.IO.Pipes;

namespace Chapter27.ClientServer
{
	class PipeServerLib
	{
		private static IEnumerator<Int32> PipeServerAsyncEnumerator(AsyncEnumerator ae) {
			// Each server object performs asynchronous operation on this pipe
			using (var pipe = new NamedPipeServerStream(
				"Echo", PipeDirection.InOut, -1, PipeTransmissionMode.Message,
				PipeOptions.Asynchronous | PipeOptions.WriteThrough)) {
				// Asynchronously accept a client connection
				pipe.BeginWaitForConnection(ae.End(), null);
				yield return 1;

				// A client connected, let's accept another client
				var aeNewClient = new AsyncEnumerator();
				aeNewClient.BeginExecute(PipeServerAsyncEnumerator(aeNewClient),
					aeNewClient.EndExecute);

				// Accept the client connection
				pipe.EndWaitForConnection(ae.DequeueAsyncResult());

				// Asynchronously read a request from the client
				Byte[] data = new Byte[1000];
				pipe.BeginRead(data, 0, data.Length, ae.End(), null);
				yield return 1;

				// The client sent us a request, process it
				Int32 bytesRead = pipe.EndRead(ae.DequeueAsyncResult());

				// Just change to upper case
				data = Encoding.UTF8.GetBytes(
					Encoding.UTF8.GetString(data, 0, bytesRead).ToUpper().ToCharArray());

				// Asynchronously send the response back to the client
				pipe.BeginWrite(data, 0, data.Length, ae.End(), null);
				yield return 1;

				// The response was sent to the client, close our side of the connection
				pipe.EndWrite(ae.DequeueAsyncResult());
			} // Close happens in a finally block now!
		}
	}
}
