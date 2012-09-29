#include "StdAfx.h"
#include "ChatClient.h"
#include "ChatServer.h"

void ChatClient::OnMessageArrived(System::Object^ sender, MessageArrivedEventArgs^ args)
{
	System::Console::WriteLine("[{0}] {1}> {2}", _name, args->From, args->Message);
}

ChatClient::ChatClient(System::String^ name, ChatServer^ server)
	: _name(name), _server(server)
{
	_server->MessageArrived += gcnew MessageArrivedEventHandler(this, &ChatClient::OnMessageArrived);
}

void ChatClient::SendMessage(System::String^ message)
{
	_server->SendMessage(_name, message);
}
