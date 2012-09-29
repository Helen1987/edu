#pragma once

#pragma managed

#include <vcclr.h>
#include <string>

typedef void (*BRIDGE_FS_NOTIFICATION_CALLBACK)(void* state, const std::string& path, const std::string& change);

class FileSystemWatcherBridge
{
private:
	friend ref class EventMiddleman;

	gcroot<System::IO::FileSystemWatcher^> _watcher;
	BRIDGE_FS_NOTIFICATION_CALLBACK _callback;
	void* _state;

	void OnEvent(System::Object^ sender, System::IO::FileSystemEventArgs^ args);
public:
	FileSystemWatcherBridge(const std::string& path);
	~FileSystemWatcherBridge();
	void Register(void* state, BRIDGE_FS_NOTIFICATION_CALLBACK callback);
};
