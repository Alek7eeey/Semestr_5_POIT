#include <iostream>
#include <chrono>
#include <thread>

void main()
{
    while (true) {
        std::cout << "OS06_02: Running long loop..." << std::endl;
        std::this_thread::sleep_for(std::chrono::seconds(1));
    }
}