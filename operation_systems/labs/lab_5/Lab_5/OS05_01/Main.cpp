#include <iostream>
#include <Windows.h>
#include <bitset>

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    DWORD processId = GetCurrentProcessId();
    DWORD threadId = GetCurrentThreadId();
    int processPriority = GetPriorityClass(GetCurrentProcess());
    int threadPriority = GetThreadPriority(GetCurrentThread());

    DWORD_PTR processAffinityMask, systemAffinityMask;
    GetProcessAffinityMask(GetCurrentProcess(), &processAffinityMask, &systemAffinityMask);

    int numProcessors = 0;
    for (int i = 0; i < sizeof(DWORD_PTR) * 8; i++) {
        if (processAffinityMask & (1ull << i)) {
            numProcessors++;
        }
    }

    DWORD_PTR threadAffinityMask = SetThreadAffinityMask(GetCurrentThread(), 1ull << 0);

    std::cout << "������������� �������� ��������: " << processId << std::endl;
    std::cout << "������������� �������� (main) ������: " << threadId << std::endl;
    std::cout << "��������� �������� ��������: " << processPriority << std::endl;
    std::cout << "��������� �������� ������: " << threadPriority << std::endl;
    std::cout << "����� (affinity mask) ��������� �������� ����������� � �������� ����: " << std::bitset<sizeof(DWORD_PTR) * 8>(processAffinityMask) << std::endl;
    std::cout << "���������� ����������� ��������� ��������: " << numProcessors << std::endl;
    std::cout << "���������, ����������� �������� ������: " << std::bitset<sizeof(DWORD_PTR) * 8>(threadAffinityMask) << std::endl;

    return 0;
}
