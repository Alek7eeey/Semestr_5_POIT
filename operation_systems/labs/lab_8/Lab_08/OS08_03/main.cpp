#include <iostream>
#include <cstring>

//int main() {
//    const int pageSize = 4096; // ������ �������� � ������
//    const int numPages = 256;   // ���������� �������
//
//    // ��������� ������ ��� 256 �������
//    char* memory = new char[pageSize * numPages];
//
//    // ���������� ������� int, ����������� ��� 256 �������
//    int* intArray = reinterpret_cast<int*>(memory);
//
//    // ���������� ������� ����������� �������������������
//    for (int i = 0; i < pageSize * numPages / sizeof(int); ++i) {
//        intArray[i] = i + 1;
//    }
//
//    // ������ 3 ������ ���� ������� � 16-������ �������������
//    const char lastName[] = { 0xCA, 0xF0, 0xE0 }; // Kravchenko (russian letters)
//    // ����������� ���� � ������ (�������� �������� � �������� ������ ��������)
//    memcpy(memory, lastName, sizeof(lastName));
//
//    // ����������� ��������� ����������
//    std::cout << "OS06_03: Completed successfully." << std::endl;
//
//    // ������������ ������
//    delete[] memory;
//
//    return 0;
//}


#include <Windows.h>
using namespace std;
#define KB (1024)
#define MB (1024 * KB)
#define PG (4 * KB)


void saymem()
{
    MEMORYSTATUS ms;
    GlobalMemoryStatus(&ms);
    cout << "����� ���������� ������:      " << ms.dwTotalPhys / KB << " KB\n";
    cout << "�������� ���������� ������:   " << ms.dwAvailPhys / KB << " KB\n";
    cout << "����� ����������� ������:     " << ms.dwTotalVirtual / KB << " KB\n";
    cout << "�������� ����������� ������:  " << ms.dwAvailVirtual / KB << " KB\n\n";
}


/*
    � - 202(10) - 0xCA(16)
    � - 240(10) - 0xF0(16)
    � - 224(10) - 0xE0(16)
    �������� C2 = 202
    202 * 4096 = 827392(10) = 0xCA000 - �������� ��� �������� �� ��������
    �������� F0E = 3854(10) = 0x00000F0E
    ������� ��������: ������ ������� + 0xCA000 + 0x00000F0E
*/
int main()
{
    setlocale(LC_ALL, "ru");
    int pages = 256;
    int countItems = pages * PG / sizeof(int);
    SYSTEM_INFO system_info;
    GetSystemInfo(&system_info);

    cout << "\t    ���������� � �������\n";
    saymem();

    LPVOID xmemaddr = VirtualAlloc(NULL, pages * PG, MEM_COMMIT, PAGE_READWRITE);   // �������� 1024 KB ����������� ������
    cout << "\t�������� " << pages * PG / 1024 << " KB ����. ������\n";
    saymem();

    int* arr = (int*)xmemaddr;
    for (int i = 0; i < countItems; i++)
        arr[i] = i;

    int* byte = arr + 202 * 1024 + 3854;
    cout << "------  �������� ������ � �����: " << *byte << "  ------\n";

    VirtualFree(xmemaddr, NULL, MEM_RELEASE) ? cout << "\t����������� ������ �����������\n" : cout << "\t����������� ������ �� �����������\n";
    saymem();
}
