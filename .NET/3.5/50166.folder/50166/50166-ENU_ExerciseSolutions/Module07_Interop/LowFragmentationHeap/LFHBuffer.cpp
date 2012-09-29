// This is the main DLL file.

#include "stdafx.h"

#include "LFHBuffer.h"
using namespace LowFragmentationHeap;

#include <windows.h>

HANDLE g_LFH;

void LFHBuffer::InitializeLFH()
{
	g_LFH = HeapCreate(0, 0, 0);

	ULONG heapFragValue = 2;
	HeapSetInformation(g_LFH, HeapCompatibilityInformation, &heapFragValue, sizeof(heapFragValue));
}

LFHBuffer::LFHBuffer(int size)
{
	_buf = (System::Byte*)HeapAlloc(g_LFH, 0, size);
	_size = size;
}

System::Byte LFHBuffer::default::get(int index)
{
	//Add range check

	return _buf[index];
}

void LFHBuffer::default::set(int index, System::Byte value)
{
	//Add range check

	_buf[index] = value;
}

int LFHBuffer::Length::get()
{
	return _size;
}

LFHBuffer^ LFHBuffer::FromArray(array<System::Byte>^ buffer, int offset, int length)
{
	LFHBuffer^ lfhBuf = gcnew LFHBuffer(length);
	lfhBuf->Write(buffer, offset, 0, length);
	return lfhBuf;
}

LFHBuffer^ LFHBuffer::FromStream(System::IO::Stream^ stream, int length)
{
	LFHBuffer^ lfhBuf = gcnew LFHBuffer(length);
	array<System::Byte>^ buf = gcnew array<System::Byte>(length);
	stream->Read(buf, 0, length);
	lfhBuf->Write(buf, 0, 0, length);
	return lfhBuf;
}

void LFHBuffer::Read(array<System::Byte>^ buffer, int bufferOffset, int myOffset, int length)
{
	for (int i = 0; i < length; ++i)
		buffer[bufferOffset + i] = _buf[myOffset + i];
}

void LFHBuffer::Write(array<System::Byte>^ buffer, int bufferOffset, int myOffset, int length)
{
	for (int i = 0; i < length; ++i)
		_buf[myOffset + i] = buffer[bufferOffset + i];
}

LFHBuffer::~LFHBuffer()
{
	HeapFree(g_LFH, 0, _buf);
}

LFHBuffer::!LFHBuffer()
{
	HeapFree(g_LFH, 0, _buf);
}