// diary_vector.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>
#include <windows.h>
#include <vector>
#include <algorithm>

using namespace std;

void showVec(vector<int> v);

int _tmain(int argc, _TCHAR* argv[])
{
	vector<int> v(100);

	//exmp1 works quicker because - [index] method do not check bounds
	//and do not show acception when index out of bounds
	/*
	for (int i = 0; i < 10; i++)
	{
		v[i] = i;
		cout << v[i] << " ";
	}
	cout << " example 1 " << GetTickCount() << endl;
	*/
	//res of gettickcount() 61795468
	
	//exmp 2. method at() throw exceoption because check bounds(if index>bound)
	//therefore it is slower
	for (int i = 0; i < 10; i++)
	{
		v.at(i) = i;
		cout << v[i] << " ";
	}
	cout << " example 2 " << GetTickCount() << endl;
	//res of gettickcount() 61856531

	//C-style of getting elem. method data() returns a pointer to the raw memory
	//of vector. Vectors are always store elems in contiguous memory
	
	/*
	cout << " example 3 " << endl;
	int* pElem = v.data();
	*pElem = 6;
	++pElem;
	*pElem = 6;

	for (int i = 0; i < 10; i++)
	{
		cout << v[i] << " ";
	}
	*/
	//exmp 4. instead method data() I use front() and the same get addr of first

	/*
	int* ptr = &(v.front());
	*ptr = 666;
	showVec(v);
	*/

	/*
	//example 5. initializing vector v2
	vector<int> v2(v); //v2 becomes equal to vecotor v
	cout << " v2 : ";
	showVec(v2);
	*/

	/*
	//example 6. initializing vector v3 = exmpl 5
	vector<int> v3 = v2;
	cout << "--------- v3 : "; 
	showVec(v3);
	*/

	//example 7. initializing vector v4
	vector<int> v4(3, 6);
	cout << " v4 : ";
	showVec(v4);
	

	//example 8. Initialinig vector v5. I move all from vector v4 to v5
	vector<int> v5(move(v4));
	//now vector v4 is empty 
	cout << endl << " v4 : ";
	showVec(v4);
	cout << endl << " v5 : ";
	showVec(v5);

	int val = 1;
	cout << endl << " v5 : ";
	v5[1] = 222;
	v5[2] = 333;
	cout << endl << endl << " v5 : ";
	showVec(v5);
	v5.erase(remove( v5.begin(), v5.end(), 222), v5.end());
	cout << endl << " v5 without el = 222" << endl;
	showVec(v5);

	return 0;
}

void showVec(vector<int> v)
{
for (int i = 0; i < v.size(); i++)
	{
		cout << v[i] << " ";
	}
}
