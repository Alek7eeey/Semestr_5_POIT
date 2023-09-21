#include <iostream>
#include <Windows.h>

using namespace std;

void main() 
{
	cout << "===START OS03_02_1 ===" << endl;
	cout << "Child pid = " << GetCurrentProcessId() << endl;

	for (int i = 0; i < 50; i++) {

		Sleep(1000);
		cout << i << endl;
	}
}