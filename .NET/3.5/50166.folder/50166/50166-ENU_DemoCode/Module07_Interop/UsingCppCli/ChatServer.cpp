#include "StdAfx.h"
#include "ChatServer.h"

void ChatServer::SendMessage(System::String^ from, System::String^ message)
{
	MessageArrived(this, gcnew MessageArrivedEventArgs(from, message));
}
