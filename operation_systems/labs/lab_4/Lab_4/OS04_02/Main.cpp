#include <thread>
#include <iostream>
#include <chrono>
#include <Windows.h>

// Функция потока OS04_02_T1
void OS04_02_T1() {
    for (int i = 0; i < 50; i++) {
        // Получение идентификатора текущего процесса и потока
        DWORD processId = GetCurrentProcessId();
        DWORD threadId = GetCurrentThreadId();

        // Вывод идентификаторов на консоль
        std::cout << "ProcessT1 ID: " << processId << std::endl;
        std::cout << "ThreadT1 ID: " << threadId << std::endl;

        std::this_thread::sleep_for(std::chrono::seconds(1));
    }
}

// Функция потока OS04_02_T2
void OS04_02_T2() {
    for (int i = 0; i < 125; i++) {
        // Получение идентификатора текущего процесса и потока
        DWORD processId = GetCurrentProcessId();
        DWORD threadId = GetCurrentThreadId();

        // Вывод идентификаторов на консоль
        std::cout << "ProcessT2 ID: " << processId << std::endl;
        std::cout << "ThreadT2 ID: " << threadId << std::endl;

        std::this_thread::sleep_for(std::chrono::seconds(1));
    }
}

int main() {
    // Создание и запуск потоков
    std::thread thread1(OS04_02_T1);
    std::thread thread2(OS04_02_T2);

    // Задержка главного потока на 100 итераций
    for (int i = 0; i < 100; i++) {
        // Получение идентификатора текущего процесса
        DWORD processId = GetCurrentProcessId();

        // Вывод идентификатора процесса на консоль
        std::cout << "ProcessParent ID: " << processId << std::endl;

        std::this_thread::sleep_for(std::chrono::seconds(1));
    }

    // Дождитесь завершения потоков
    thread1.join();
    thread2.join();

    return 0;
}