#include <iostream>
#include <Windows.h>

using namespace std;

void main() 
{
	cout << "===START OS03_02_2 ===" << endl;
	cout << "Child pid = " << GetCurrentProcessId() << endl;

	for (int i = 0; i < 125; i++) {

		Sleep(1000);
		cout << i << endl;
	}
}