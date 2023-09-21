#include <iostream>
#include <Windows.h>

using namespace std;

void main() {

	cout << "Pid12 = " << GetCurrentProcessId() << endl;

	for (int i = 0; i < 1000; i++) {

		Sleep(1000);

		cout << i << endl;
	}
}