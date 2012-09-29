#pragma once

ref class MessageArrivedEventArgs : System::EventArgs
{
private:
	System::String^ _message;
	System::String^ _from;
public:
	MessageArrivedEventArgs(System::String^ from, System::String^ message)
	{
		_from = from;
		_message = message;
	}
	property System::String^ Message
	{
		System::String^ get() { return _message; }
	}
	property System::String^ From
	{
		System::String^ get() { return _from; }
	}
};

delegate void MessageArrivedEventHandler(System::Object^ sender, MessageArrivedEventArgs^ e);

ref class ChatServer
{
public:
	void SendMessage(System::String^ from, System::String^ message);
	event MessageArrivedEventHandler^ MessageArrived;
};
