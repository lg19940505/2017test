// CSharpInvokeCPP.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"

extern "C" __declspec(dllexport) int Add(int x, int y)
{
	return x + y;
}
extern "C" __declspec(dllexport) int Sub(int x, int y)
{
	return x - y;
}
extern "C" __declspec(dllexport) int Multiply(int x, int y)
{
	return x * y;
}
extern "C" __declspec(dllexport) int Divide(int x, int y)
{
	return x / y;
}


