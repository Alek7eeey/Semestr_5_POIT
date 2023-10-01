#include <iostream>
#include <thread>
#include <chrono>
#include <Windows.h>

// ������� ������ OS04_03_T1
void OS04_03_T1() {
    for (int i = 0; i < 50; i++) {
        // ��������� �������������� �������� �������� � ������
        DWORD processId = GetCurrentProcessId();
        DWORD threadId = GetCurrentThreadId();

        // ����� ��������������� �� �������
        std::cout << "ProcessT1 ID: " << processId << std::endl;
        std::cout << "ThreadT1 ID: " << threadId << std::endl;

        // �������� �� 1 �������
        std::this_thread::sleep_for(std::chrono::seconds(1));
    }
}

// ������� ������ OS04_03_T2
void OS04_03_T2() {
    for (int i = 0; i < 125; i++) {
        // ��������� �������������� �������� �������� � ������
        DWORD processId = GetCurrentProcessId();
        DWORD threadId = GetCurrentThreadId();

        // ����� ��������������� �� �������
        std::cout << "ProcessT2 ID: " << processId << std::endl;
        std::cout << "ThreadT2 ID: " << threadId << std::endl;

        // �������� �� 1 �������
        std::this_thread::sleep_for(std::chrono::seconds(1));
    }
}

int main() {
    // �������� � ������ �������
    std::thread thread1(OS04_03_T1);
    std::thread thread2(OS04_03_T2);

    for (int i = 0; i < 100; i++) {
        // ��������� �������������� �������� ��������
        DWORD processId = GetCurrentProcessId();

        // ����� �������������� �������� �� �������
        std::cout << "ProcessParent ID: " << processId << std::endl;

        // ������������ ������ ������ OS04_03_T2 �� 40-� ��������
        if (i == 40) {
            TerminateThread(thread2.native_handle(), 1);
        }

        // �������� �� 1 �������
        std::this_thread::sleep_for(std::chrono::seconds(1));
    }

    // ��������� ���������� �������
    thread1.join();
    thread2.join();

    return 0;
}