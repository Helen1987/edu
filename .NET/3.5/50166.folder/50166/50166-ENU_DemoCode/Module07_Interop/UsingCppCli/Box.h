#pragma once

class NativeBox
{
public:
	NativeBox() {}
	NativeBox(int) {}

	void Boxify() {}
};

ref class ManagedBox
{
public:
	int InTheBox;

	ManagedBox() {}
	ManagedBox(int) {}

	void Boxify() {}
};
