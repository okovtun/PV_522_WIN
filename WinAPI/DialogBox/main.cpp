#include<Windows.h>
#include"resource.h"

CONST CHAR g_sz_INVITE[] = "Введите имя пользователя";
//g_sz_ - Global StringZero;

BOOL CALLBACK DlgProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
/*
--------------------------------------------------------------------------
Окно, сообщение и параметры сообщения.
hwnd - окно;
uMsg - сообщение;
wParam, lParam - параметры сообщения;
----------------
HWND - Handler to Window (Дескриптор, описатель окна);
WPARAM и LPARAM - это самые обычные значения типа DWORD (INT).
Эти параметры часто делят на HIWORD и LOWORD
0 kb
--------------------------------------------------------------------------
*/

INT WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInst, LPSTR lpCmdLine, INT nCmdShow)
{
	DialogBoxParam(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), NULL, (DLGPROC)DlgProc, 0);
	"Button", "Edit";
	return 0;
}

BOOL CALLBACK DlgProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch (uMsg)
	{
	case WM_INITDIALOG:	//Инициализация окна диалога. Эта секция отрабатывает 1 раз - при запуске окна.
	{
		HICON hIcon = LoadIcon(GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_ICON1));
		SendMessage(hwnd, WM_SETICON, 0, (LPARAM)hIcon);

		HWND hEditLogin = GetDlgItem(hwnd, IDC_EDIT_LOGIN);
		SendMessage(hEditLogin, WM_SETTEXT, 0, (LPARAM)g_sz_INVITE);
	}
	break;
	case WM_COMMAND:	//В этой секции обраьатываеются нажатия кнопок, клавиш и другие события
		switch (LOWORD(wParam))
		{
		case IDC_EDIT_LOGIN:
		{
			CONST INT SIZE = 256;
			CHAR sz_buffer[SIZE] = {};
			HWND hEditLogin = GetDlgItem(hwnd, IDC_EDIT_LOGIN);
			//hwnd - родительское окно;
			//IDC_EDIT_LOGIN - ResourceID элемента, дескриптор которого мы хотим получить
			SendMessage(hEditLogin, WM_GETTEXT, SIZE, (LPARAM)sz_buffer);

			if (HIWORD(wParam) == EN_SETFOCUS)
			{
				if (strcmp(sz_buffer, g_sz_INVITE) == 0)
					SendMessage(hEditLogin, WM_SETTEXT, 0, (LPARAM)"");
			}
			if (HIWORD(wParam) == EN_KILLFOCUS)
			{
				if (strcmp(sz_buffer, "") == 0)
					SendMessage(hEditLogin, WM_SETTEXT, 0, (LPARAM)g_sz_INVITE);
			}
		}
		break;
		case IDC_BUTTON_COPY:
		{
			CONST INT SIZE = 256;
			CHAR sz_buffer[SIZE] = {};
			HWND hEditLogin = GetDlgItem(hwnd, IDC_EDIT_LOGIN);
			HWND hEditPassword = GetDlgItem(hwnd, IDC_EDIT_PASSWORD);
			//Функция GetDlgItem() позволяет получить HWND элемента окна 'hwnd', 
			//по RESOURCE_ID нужного элемента.
			//RESOURCE_ID - это самое обычное значение типа 'INT'
			//----------------------------------------
			//WM_- WindowMessage (такое сообщение можно отправить любому окну)
			SendMessage(hEditLogin, WM_GETTEXT, SIZE, (LPARAM)sz_buffer);
			SendMessage(hEditPassword, WM_SETTEXT, 0, (LPARAM)sz_buffer);
		}
		break;
		case IDOK:		MessageBox(hwnd, "Была нажата кнопка OK", "Info", MB_OK | MB_ICONINFORMATION); break;
		case IDCANCEL:	EndDialog(hwnd, 0); break;
		}
		break;
	case WM_CLOSE:		//Отрабатывает й раз при закрытии окна
		EndDialog(hwnd, 0);
	}
	return FALSE;
}