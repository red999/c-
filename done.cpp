// ask1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include<iostream>
#include<fstream>
#include<string>
#include<sstream>
#include<vector>

using namespace std;


int main(){
	ifstream stream1;
	string str;
	vector<string> list;
	stringstream ss;
	stringstream path;
	stringstream res;

	for(int i = 1; i < 4; i++)
	{
	path << "file" << i << ".txt";
	stream1.open(path.str());
	
	if(stream1.is_open())
	{
		
			getline(stream1, str);
			cout << str << endl;
			ss << str << " \n ";
			list.push_back(ss.str());
		
		stream1.close();
	}

	path.str(string());
	ss.str(string());
	}

	cout << " ----------------- " << endl;
	
	for (int i = 0; i < list.size(); i++)
	{
		ss << list.at(i);
		cout << ss.str();
		ss.str(string());
	}
    
    return 0;
} 
