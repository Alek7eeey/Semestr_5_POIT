#include <iostream>
#include <Windows.h>
#include <thread>
#include <chrono>

using namespace std;

void OS04_04_T1()
{
	for (short i = 0; i < 50; i++)
	{
        // Получение идентификатора текущего процесса и потока
        DWORD processId = GetCurrentProcessId();
        DWORD threadId = GetCurrentThreadId();

        // Вывод идентификаторов на консоль
        std::cout << "ProcessT1 ID: " << processId << std::endl;
        std::cout << "ThreadT1 ID: " << threadId << std::endl;
        std::this_thread::sleep_for(std::chrono::seconds(1));

        // Задержка на 1 секунду
        std::this_thread::sleep_for(std::chrono::seconds(1));

        if (i == 25) {
            std::this_thread::sleep_for(std::chrono::seconds(10));
        }
	}
}

void OS04_04_T2()
{
    for (short i = 0; i < 125; i++)
    {
        // Получение идентификатора текущего процесса и потока
        DWORD processId = GetCurrentProcessId();
        DWORD threadId = GetCurrentThreadId();

        // Вывод идентификаторов на консоль
        std::cout << "ProcessT2 ID: " << processId << std::endl;
        std::cout << "ThreadT2 ID: " << threadId << std::endl;
        std::this_thread::sleep_for(std::chrono::seconds(1));

        // Задержка на 1 секунду
        std::this_thread::sleep_for(std::chrono::seconds(1));

        if (i == 80) {
            std::this_thread::sleep_for(std::chrono::seconds(15));
        }
    }
}

void main() 
{
    thread thread1(OS04_04_T1);
    thread thread2(OS04_04_T2);

    for (short i = 0; i < 100; i++)
    {
        DWORD processId = GetCurrentProcessId();
        DWORD threadId = GetCurrentThreadId();

        // Вывод идентификаторов на консоль
        std::cout << "ProcessParent ID: " << processId << std::endl;
        std::cout << "ThreadParent ID: " << threadId << std::endl;
        std::this_thread::sleep_for(std::chrono::seconds(1));

        if (i == 30) {
            std::this_thread::sleep_for(std::chrono::seconds(10));
        }
    }

    thread1.join();
    thread2.join();
}