#include <iostream>
#include <thread>
#include <chrono>
#include <windows.h>

using namespace std;

int _counter = 0;

int getCurrentCounter()
{
    	return _counter;
}

void main()
{
	auto startTime = std::chrono::steady_clock::now();
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    bool fiveSec = true, tenSec = true, fifteenSec = true;

	while (true)
	{
		auto currentTime = std::chrono::steady_clock::now();
		auto elapsedTime = std::chrono::duration_cast<std::chrono::seconds>(currentTime - startTime).count();

        if (elapsedTime >= 5 && fiveSec) {
            std::cout << "�������� �������� ����� 5 ������: " << getCurrentCounter() << std::endl;
            fiveSec = false;
        }
        if (elapsedTime >= 10 && tenSec) {
            std::cout << "�������� �������� ����� 10 ������: " << getCurrentCounter() << std::endl;
            tenSec = false;
        }

        if (elapsedTime >= 15 && fifteenSec) {
            std::cout << "������ 15 ������. ��������� ������." << std::endl;
            std::cout << "�������� �������� ��������: " << getCurrentCounter() << std::endl;
            break;
        }

		_counter++;
	}
}