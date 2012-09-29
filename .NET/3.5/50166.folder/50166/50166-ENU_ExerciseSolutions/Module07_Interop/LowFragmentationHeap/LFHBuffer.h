// LowFragmentationHeap.h

#pragma once

namespace LowFragmentationHeap {

	public ref class LFHBuffer
	{
	private:
		System::Byte* _buf;
		int _size;
	public:
		static void InitializeLFH();
		
		LFHBuffer(int size);

		property System::Byte default[int]
		{
			System::Byte get(int index);
			void set(int index, System::Byte value);
		}
		
		property int Length
		{
			int get();
		}
		
		static LFHBuffer^ FromArray(array<System::Byte>^ buffer, int offset, int length);
		static LFHBuffer^ FromStream(System::IO::Stream^ stream, int length);
		
		void Read(array<System::Byte>^ buffer, int bufferOffset, int myOffset, int length);
		void Write(array<System::Byte>^ buffer, int bufferOffset, int myOffset, int length);
		
		~LFHBuffer();
		!LFHBuffer();
	};
}
