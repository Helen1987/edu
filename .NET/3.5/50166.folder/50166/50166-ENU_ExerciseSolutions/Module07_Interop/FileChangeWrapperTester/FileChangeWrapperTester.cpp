// FileChangeWrapperTester.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include "..\\FileChangeWrapper\\NativeFileSystemWatcher.h"
#pragma comment(lib, "..\\Debug\\FileChangeWrapper.lib")

#include <iostream>

void ChangeCallback(const std::string& path, const std::string& change)
{
	std::cout << path << " " << change << std::endl;
}

int _tmain(int argc, _TCHAR* argv[])
{
	getchar();

	NativeFileSystemWatcher watcher("C:\\Windows");
	watcher.AddCallback(ChangeCallback);

	getchar();

	return 0;
}

