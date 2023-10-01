#include <iostream>
#include <Windows.h>

void main() {

	for (short i = 0; i < 10000; i++)
	{
		std::cout << "Process ID: " << GetCurrentProcessId() << std::endl;
		std::cout << "Thread ID: " << GetCurrentThreadId() << std::endl;
		Sleep(1000);
	}
}