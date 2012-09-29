#pragma once

#ifdef NFSW_EXPORTS
#define NFSW_API __declspec(dllexport)
#else
#define NFSW_API __declspec(dllimport)
#endif

#pragma unmanaged

#include <string>
#include <set>

typedef void (*FS_NOTIFICATION_CALLBACK)(const std::string& path, const std::string& change);

class FileSystemWatcherBridge;	//Forward declaration

class NFSW_API NativeFileSystemWatcher
{
private:
	std::set<FS_NOTIFICATION_CALLBACK> _callbacks;
	FileSystemWatcherBridge* _bridge;

	static void OnCallback(void* state, const std::string& path, const std::string& change);
public:
	NativeFileSystemWatcher(const std::string& path);
	~NativeFileSystemWatcher();
	void AddCallback(FS_NOTIFICATION_CALLBACK callback);
	void RemoveCallback(FS_NOTIFICATION_CALLBACK callback);
};