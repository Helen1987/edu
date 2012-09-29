using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Pipes;
using System.Threading;

namespace Chapter27.ClientServer
{
	internal sealed class PipeServer {
		// Each server object performs asynchronous operation on this pipe
		private readonly NamedPipeServerStream m_pipe = new NamedPipeServerStream(
			"Echo", PipeDirection.InOut, -1, PipeTransmissionMode.Message,
			PipeOptions.Asynchronous | PipeOptions.WriteThrough);

		public PipeServer() {
			// Asynchronously accept a client connection
			m_pipe.BeginWaitForConnection(ClientConnected, null);
		}

		private void ClientConnected(IAsyncResult result) {
			// A client connected, let's accept another client
			new PipeServer();

			// Accept the client connection
			m_pipe.EndWaitForConnection(result);

			// Asynchronously read a request from the client
			Byte[] data = new Byte[1000];
			m_pipe.BeginRead(data, 0, data.Length, GotRequest, data);
		}

		private void GotRequest(IAsyncResult result) {

			var bytesRead = m_pipe.EndRead(result);
			var data = result.AsyncState as Byte[];

			// Just change to upper case
			Thread.Sleep(1000);
			data = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data, 0, bytesRead).ToUpper().ToCharArray());

			// Asynchronously send the response back to the client
			m_pipe.BeginWrite(data, 0, data.Length, WriteDone, null);
		}

		private void WriteDone(IAsyncResult result) {
			// The response was sent to the client, close our side of the connection
			m_pipe.EndWrite(result);
			m_pipe.Close();
		}
	}
}
