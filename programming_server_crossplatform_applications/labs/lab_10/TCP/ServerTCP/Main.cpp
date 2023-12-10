
#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <string>
#include <time.h>
#include "Winsock2.h"

#pragma comment(lib, "WS2_32.lib")

std::string  GetErrorMsgText(int code)
{
	switch (code)
	{
	case WSAEINTR:			return "������ ������� �������� ";
	case WSAEACCES:			return "���������� ����������";
	case WSAEFAULT:			return "��������� �����";
	case WSAEINVAL:			return "������ � ���������";
	case WSAEMFILE:			return "������� ����� ������ �������";
	case WSAEWOULDBLOCK:	return "������ �������� ����������";
	case WSAEINPROGRESS:	return "�������� � �������� ��������";
	case WSAEALREADY:		return "�������� ��� �����������";
	case WSAENOTSOCK:		return "����� ����� �����������";
	case WSAEDESTADDRREQ:	return "��������� ����� ������������";
	case WSAEMSGSIZE:		return "��������� ������� �������";
	case WSAEPROTOTYPE:		return "������������ ��� ��������� ��� ������";
	case WSAENOPROTOOPT:	return "������ � ����� ���������";
	case WSAEPROTONOSUPPORT: return "�������� �� ��������������";
	case WSAESOCKTNOSUPPORT: return "��� ������ �� ��������������";
	case WSAEOPNOTSUPP:		return "�������� �� ��������������";
	case WSAEPFNOSUPPORT:	return "��� ���������� �� ��������������";
	case WSAEAFNOSUPPORT:	return "��� ������� �� �������������� ����������";
	case WSAEADDRINUSE:		return "����� ��� ������������";
	case WSAEADDRNOTAVAIL:	return "����������� ����� �� ����� ���� �����������";
	case WSAENETDOWN:		return "���� ���������";
	case WSAENETUNREACH:	return "���� �� ���������";
	case WSAENETRESET:		return "���� ��������� ����������";
	case WSAECONNABORTED:	return "����������� ����� �����";
	case WSAECONNRESET:		return "����� �������������";
	case WSAENOBUFS:		return "�� ������� ������ ��� �������";
	case WSAEISCONN:		return "����� ��� ���������";
	case WSAENOTCONN:		return "����� �� ���������";
	case WSAESHUTDOWN:		return "������ ��������� send : ����� �������� ������";
	case WSAETIMEDOUT:		return "���������� ���������� ��������  �������";
	case WSAECONNREFUSED:	return "���������� ���������";
	case WSAEHOSTDOWN:		return "���� � ����������������� ���������";
	case WSAEHOSTUNREACH:	return "��� �������� ��� �����";
	case WSAEPROCLIM:		return "������� ����� ���������";
	case WSASYSNOTREADY:	return "���� �� ��������";
	case WSAVERNOTSUPPORTED: return "������ ������ ����������";
	case WSANOTINITIALISED:	return "�� ��������� ������������� WS2_32.DLL";
	case WSAEDISCON:		return "����������� ����������";
	case WSATYPE_NOT_FOUND: return "����� �� ������";
	case WSAHOST_NOT_FOUND:	return "���� �� ������";
	case WSATRY_AGAIN:		return "������������������ ���� �� ������";
	case WSANO_RECOVERY:	return "��������������  ������";
	case WSANO_DATA:		return "��� ������ ������������ ����";
	case WSA_INVALID_HANDLE: return "��������� ���������� �������  � �������";
	case WSA_INVALID_PARAMETER: return "���� ��� ����� ���������� � �������";
	case WSA_IO_INCOMPLETE:	return "������ ����� - ������ �� � ���������� ���������";
	case WSA_IO_PENDING:	return "�������� ���������� �����";
	case WSA_NOT_ENOUGH_MEMORY: return "�� ���������� ������";
	case WSA_OPERATION_ABORTED: return "�������� ����������";
	case WSASYSCALLFAILURE: return "��������� ���������� ���������� ������";
	default:				return "**ERROR**";
	};
};

std::string  SetErrorMsgText(std::string msgText, int code)
{
	return  msgText + GetErrorMsgText(code);
};

int main()
{
	setlocale(LC_CTYPE, "rus");

	WSADATA wsaData;
	SOCKET sS;

	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
		{
			throw  SetErrorMsgText("Startup:", WSAGetLastError());
		}
		if ((sS = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET)
		{
			throw  SetErrorMsgText("socket:", WSAGetLastError());
		}

		SOCKADDR_IN serv;
		serv.sin_family = AF_INET;
		serv.sin_port = htons(4000);
		serv.sin_addr.s_addr = INADDR_ANY;

		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
		{
			throw  SetErrorMsgText("bind:", WSAGetLastError());
		}
		if (listen(sS, SOMAXCONN) == SOCKET_ERROR)
		{
			throw  SetErrorMsgText("listen:", WSAGetLastError());
		}

		SOCKET cS;
		SOCKADDR_IN clnt;
		memset(&clnt, 0, sizeof(clnt));
		int lclnt = sizeof(clnt);

		while (true)
		{
			std::cout << std::endl << "Waiting to connection...";

			if ((cS = accept(sS, (sockaddr*)&clnt, &lclnt)) == INVALID_SOCKET)
			{
				throw  SetErrorMsgText("accept:", WSAGetLastError());
			}

			std::cout << std::endl << "������ �����������!";
			std::cout << std::endl << "IP-�����: " << inet_ntoa(clnt.sin_addr);
			std::cout << std::endl << "Port: " << htons(clnt.sin_port);

			try
			{
				int sizeLastMessage = 1;
				char message[] = "Hello from Client";

				while (sizeLastMessage != 0)
				{
					if ((sizeLastMessage = recv(cS, message, sizeof(message), NULL)) == SOCKET_ERROR)
					{
						throw  SetErrorMsgText("recv:", WSAGetLastError());
					}

					if (sizeLastMessage == 0)
						break;

					char newMessage[25] = "";
					strcat_s(newMessage, "ECHO: ");
					strcat_s(newMessage, message);

					if ((send(cS, newMessage, strlen(newMessage) + 1, NULL)) == SOCKET_ERROR)
					{
						throw  SetErrorMsgText("send:", WSAGetLastError());
					}

					std::cout << std::endl << "�������� ���������: " << message;

				}

			}
			catch (std::string errorMsgText)
			{
				std::cout << std::endl << "����� � �������� ���������!";
			}
		}

		if (closesocket(cS) == SOCKET_ERROR)
		{
			throw  SetErrorMsgText("closesocket:", WSAGetLastError());
		}

		if (WSACleanup() == SOCKET_ERROR)
		{
			throw  SetErrorMsgText("Cleanup:", WSAGetLastError());
		}
	}
	catch (std::string errorMsgText)
	{
		std::cout << std::endl << errorMsgText;
	}

	std::cout << std::endl;
	system("pause");
	return 0;
}