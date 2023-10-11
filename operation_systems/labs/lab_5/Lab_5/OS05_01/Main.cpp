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

    std::cout << "Идентификатор текущего процесса: " << processId << std::endl;
    std::cout << "Идентификатор текущего (main) потока: " << threadId << std::endl;
    std::cout << "Приоритет текущего процесса: " << processPriority << std::endl;
    std::cout << "Приоритет текущего потока: " << threadPriority << std::endl;
    std::cout << "Маска (affinity mask) доступных процессу процессоров в двоичном виде: " << std::bitset<sizeof(DWORD_PTR) * 8>(processAffinityMask) << std::endl;
    std::cout << "Количество процессоров доступных процессу: " << numProcessors << std::endl;
    std::cout << "Процессор, назначенный текущему потоку: " << std::bitset<sizeof(DWORD_PTR) * 8>(threadAffinityMask) << std::endl;

    return 0;
}
