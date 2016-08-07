// analiz.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

void func();

int _tmain(int argc, _TCHAR* argv[])
{

	func();
	return 0;
}

void func()
{
	char mas[200];
	char mas2[200];

	for (int i0 = 0; i0 < 200; i0++)
		mas2[i0] = 0;

	cout << "Enter word" << endl;
	gets_s(mas);
	cout << "it`s your word: " << mas << endl << " length " << strlen(mas) << endl;
	float koef, full_koef, part_koef, naked_koef;

	

	full_koef = strlen(mas);
	part_koef = full_koef - 1;
	naked_koef = part_koef / 3;
	
	if ( ((int) naked_koef) ) { 
		cout << " wrong size of word ";
	}
	
	cout << endl << "full_koef " << full_koef << "; part_koef " << part_koef << "; naked koef " << naked_koef;
	int i = 0;
	for (i = 0; i < (naked_koef+1); i++)
	{
		mas2[i] = 'A';
	}

	for (int i2 = 0; i2 < naked_koef; i2++)
	{
		mas2[i] = 'B';
		i++;
	}

	for (int i3 = 0; i3 < naked_koef; i3++)
	{
		mas2[i] = 'C';
		i++;
	}

	if (!(strcmp(mas,mas2))) {
		cout << endl << endl << " mas " << mas << " mas2 " << mas2 << " ok ";
	}
	else 
	{cout << "no";}
	
	system("pause");
}
