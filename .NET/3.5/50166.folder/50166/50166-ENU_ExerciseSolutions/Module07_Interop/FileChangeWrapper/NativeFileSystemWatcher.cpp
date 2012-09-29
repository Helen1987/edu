// This is the main DLL file.

#include "stdafx.h"

#include "NativeFileSystemWatcher.h"

#include "FileSystemWatcherBridge.h"
#pragma unmanaged

NativeFileSystemWatcher::NativeFileSystemWatcher(const std::string& path)
{
	_bridge = new FileSystemWatcherBridge(path);
	_bridge->Register(this, &NativeFileSystemWatcher::OnCallback);
}

NativeFileSystemWatcher::~NativeFileSystemWatcher()
{
	delete _bridge;
}

void NativeFileSystemWatcher::OnCallback(void* state, const std::string& path, const std::string& change)
{
	NativeFileSystemWatcher* pThis = static_cast<NativeFileSystemWatcher*>(state);

	for (std::set<FS_NOTIFICATION_CALLBACK>::const_iterator i = pThis->_callbacks.begin();
		i != pThis->_callbacks.end(); ++i)
		(*i)(path, change);	//Notify
}

void NativeFileSystemWatcher::AddCallback(FS_NOTIFICATION_CALLBACK callback)
{
	_callbacks.insert(callback);
}

void NativeFileSystemWatcher::RemoveCallback(FS_NOTIFICATION_CALLBACK callback)
{
	_callbacks.erase(callback);
}