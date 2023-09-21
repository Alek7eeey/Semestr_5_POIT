#include <iostream>
#include <Windows.h>

using namespace std;

int main() {

    STARTUPINFO sti = { 0 };
    PROCESS_INFORMATION pi = { 0 };
    DWORD excode;

    //���� �� �� � ����� �����!
    wstring ApplicationName1(L"D:\\studing\\5_semestr\\operation_systems\\labs\\lab_3\\OS03\\Debug\\OS03_02_1.exe");
    LPWSTR lpwAppName1 = &ApplicationName1[0];

    wstring ApplicationName2(L"D:\\studing\\5_semestr\\operation_systems\\labs\\lab_3\\OS03\\Debug\\OS03_02_2.exe");
    LPWSTR lpwAppName2 = &ApplicationName2[0];

    //� ����� �����
    wstring CommandLine(L"OS03_02_1.exe");
    LPWSTR lpwCmdLine = &CommandLine[0];

    //� ����� �����
    wstring CommandLine2(L"OS03_02_2.exe");
    LPWSTR lpwCmdLine2 = &CommandLine2[0];

    cout << "=== Start parent process OS03_02 ===" << endl;

    if (!CreateProcess(
        NULL, //��� ������������ ������
        lpwCmdLine, //cmd
        NULL,   //pointer to struct SECURITY_ATTRIBUTES
        NULL,   //pointer to struct SECURITY_ATTRIBUTES
        TRUE,   //���� ������������ ������������ �������� ��������
        NULL,   //����� �������� �������� ��������
        NULL,   //��������� �� ���� �����
        NULL,   //������� ���� ��� �������
        &sti,   //��������� �� ��������� STARTUPINFO
        &pi     //��������� �� ��������� PROCESS_INFORMATION
    )) {
        cout << "Error during the create process number 1" << endl;
        return -1;
    }

    cin.get();
    if (!CreateProcess(NULL, //��� ������������ ������
        lpwCmdLine2, //cmd
        NULL,   //pointer to struct SECURITY_ATTRIBUTES
        NULL,   //pointer to struct SECURITY_ATTRIBUTES
        TRUE,   //���� ������������ ������������ �������� ��������
        NULL,   //����� �������� �������� ��������
        NULL,   //��������� �� ���� �����
        NULL,   //������� ���� ��� �������
        &sti,   //��������� �� ��������� STARTUPINFO
        &pi     //��������� �� ��������� PROCESS_INFORMATION
    )) {
        cout << "Error during the create process number 2" << endl;
        return -1;
    }

    for (int i = 0; i < 100; i++) {

        Sleep(1000);
        cout << i << endl;
    }
    
    return 0;
}