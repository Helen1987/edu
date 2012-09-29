#include "StdAfx.h"
#include "FileSystemWatcherBridge.h"

#include <msclr\marshal.h>
using namespace msclr::interop;

ref class EventMiddleman
{
private:
	FileSystemWatcherBridge* _bridge;
public:
	EventMiddleman(FileSystemWatcherBridge* bridge) : _bridge(bridge)
	{
	}
	void OnEvent(System::Object^ sender, System::IO::FileSystemEventArgs^ args)
	{
		_bridge->OnEvent(sender, args);
	}
};

void FileSystemWatcherBridge::OnEvent(System::Object^ sender, System::IO::FileSystemEventArgs^ args)
{
	marshal_context ctx;
	_callback(_state, ctx.marshal_as<const char*>(args->FullPath),
		ctx.marshal_as<const char*>(args->ChangeType.ToString()));
}

FileSystemWatcherBridge::FileSystemWatcherBridge(const std::string& path)
{
	_watcher = gcnew System::IO::FileSystemWatcher(marshal_as<System::String^>(path.c_str()));
	
	EventMiddleman^ middleMan = gcnew EventMiddleman(this);
	_watcher->Changed += gcnew System::IO::FileSystemEventHandler(middleMan, &EventMiddleman::OnEvent);

	_watcher->EnableRaisingEvents = true;
}

FileSystemWatcherBridge::~FileSystemWatcherBridge()
{
	_watcher->EnableRaisingEvents = false;
}

void FileSystemWatcherBridge::Register(void* state, BRIDGE_FS_NOTIFICATION_CALLBACK callback)
{
	_state = state;
	_callback = callback;
}