// VigenerCipher3.cpp : Defines the entry point for the console application.
//

// ����� ���� 4 ����� - EASY 
// �� ��������� �������� �������� � ����� �������� ��������� �����
//ADDTHEABILITYTODECIPHERANYKINDOFPOLYALPHABETICCIPHERSTHEONEUSEDINTHECIPHERTEXTSHEREHASTWENTYSIXINDEPENDENTRANDOMLYCHOSENMONOALPHABETICSUBSTITUTIONPATTERNSFOREACHLETTERFROMENGLISHALPHABETITISCLEARTHATYOUCANNOMORERELYONTHESAMESIMPLEROUTINEOFGUESSINGTHE

#include "stdafx.h"
#include <string>
#include <iostream>
#include <vector>
#include <set>
#include <algorithm>
#include <list>
#include <map>

using namespace std;

vector<int> getDistances(vector<int> dist, string cipher);
vector<int> getFactors(vector<int> factors, vector<int> distances);
int getKeyLength(set<int> lengths, vector<int> factors, string cipher);
float getIC(int len, string cipher);
void getAllX2(string cipher, int length);
char func1(string cipher, vector<char> Gx);
float func2(string cipher, vector<char> Gx);
vector<char> movePos(vector<char> Gx, int moveTo);

vector<int> distances;
vector<string> substrs;
vector<int> factors;
vector<pair<int, int>> keyLengths;
vector<pair<float, int>> res;
set<int> lengths;
//typedef map<char, float > list_x2;
vector<pair<char, float>> GxX2;

char engAlphab[] = { 'A', 'B', 'C', 'D', 'E', 'F', 'G',	'H', 'I', 'J', 'K',	'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',	'X', 'Y', 'Z' };
float F_engFreqVal[] = { 0.082, 0.014, 0.028, 0.038, 0.131, 0.029, 0.020, 0.053, 0.064, 0.001, 0.004, 0.034, 0.025, 0.071, 0.080, 0.020, 0.001, 0.068, 0.061, 0.105, 0.025, 0.009, 0.015, 0.002, 0.020, 0.001 };

int main()
{
	//examples
	//string cipher = "LFWKIMJLFWLOOMULOOMKLOOLILOO";
	//string cipher = "LFWKIMJCLPSISWKHJOGLKMVGURAGKMKMXMAMJCVXWUYLGGIISWALXAEYCXMFKMKBQBDCLAEFLFWKIMJCGUZUGSKECZGBWYMOACFVMQKYFWXTWMLAIDOYQBWFGKSDIULQGVSYHJAVEFWBLAEFLFWKIMJCFHSNNGGNWPWDAVMQFAAXWFZCXBVELKWMLAVGKYEDEMJXHUXDAVYXL";//string cipher = "LFWKIMJCLPSISWKHJOGLKMVGURAGKMKMXMAMJCVXWUYLGGIISWALXAEYCXMFKMKBQBDCLAEFLFWKIMJCGUZUGSKECZGBWYMOACFVMQKYFWXTWMLAIDOYQBWFGKSDIULQGVSYHJAVEFWBLAEFLFWKIMJCFHSNNGGNWPWDAVMQFAAXWFZCXBVELKWMLAVGKYEDEMJXHUXDAVYXL";
	string cipher = "EDVRLESZMLARCTGBICANLEJYRYCGRDGDTODWELHFEBWRMCUGTHWPWTZCSNWSWEVGRTZCGIHFIRLCBTKFIRWFESLUINLWWIPGRDWNINVCRTJYRDGKPYUFSSWLQOFMELHFEBWRMCKSFSLGXULGSNHYXTWPRSXMVESALLWRXEJDVOECRGDGWHSJTHSZITARMSUJIAJRLALWSUUYRNGKSRWPILQMRTZCWAECWIENPEJMYTALIOXEYEKQMNYRLECCCBQCBHSSWTATISWYVCZULIUFCOMNVOTYFLQSWEVRSDWAMPZCVTZGWPSPEGJYTHOGPLLFIIFBIXGDGOALGIVCRCWQXIDJAOJIESSQYGYCWTAMRYGSGAFRVYLMHINGHELFIMWQWAYCMNHYVTKZCTZCRUEZIRGDGHSPECLCVSALEKWWENVYTPDWJRWOYEFACAFYPYKGWTGCECZMJTZCQCSLCOMDMNVYAAQRSUKCLIYFIRGPHEJDVEISINUWWTSRMSLGGSOGXHLFMSLWTEGDGIHFIRLFINWVXPSPEGJYTHUMRTSGRSKMQEHPITLWMNLCVEKRMNYGRFGPQALGSNSZSULQSMWYHDARMOFYPRWUERV";
	//string cipher = "VVQGYTVVVKALURWFHQACMMVLEHUCATWFHHIPLXHVUWSCIGINCMUHNHQRMSUIMHWZODXTNAEKVVQGYTVVQPHXINWCABASYYMTKSZRCXWRPRFWYHXYGFIPSBWKQAMZYBXJQQABJEMTCHQSNAEKVVQGYTVVPCAQPBSLURQUCVMVPQUTMMLVHWDHNFIKJCPXMYEIOCDTXBJWKQGAN";
	//string cipher = "NWAIWEBBRFQFOCJPUGDOJVBGWSPTWRZ";
	//string cipher = "WQXYMREOBPVWHTHQYEQVEDEXRBGSIZSILGRTAJFZOAMAVVXGRFQGKCPIOZIJBCBLUWYRWSTUGVQPSUDIUWOESFMTBTANCYZTKTYBVFDKDERSIBJECAQDWPDERIEKGPRAQFBGTHQKVVGRAXAVTHARQEELUECGVVBJEBXIJAKNGESWTKBEDXPBQOUDWVTXESMRUWWRPAWKMTITKHFWTDAURRVFESFESTKSHFLZAEONEXZBWTIARWWTTHQYEQVEDEXRBGSOREDMTICM";

	//getDistances between equal chars
	distances.swap(getDistances(distances, cipher));
	//get factors of distances
	//factors will help to get lengths of the keyword
	factors.swap(getFactors(factors, distances));
	//get length from lengths
	int length = getKeyLength(lengths, factors, cipher);
	//get X2 for getting letters of the keyword
	getAllX2(cipher, length);

	return 0;
}

//������� �����
vector<int> getDistances(vector<int> dist, string cipher)
{

	//for (int i = 3; i < 8; i++) {
	//����� ������ �� ����������. ���� ��������������
	//������ ����, �� ����� ������ ������ �� ��� �� ������ ����
	for (int i = 0; i < cipher.size() - 2; i++)
	{
		//������ ��������(��������) ��� ������ � ����
		string substring = cipher.substr(i, 3);
		//�������� ����������� ��������
		int count_coincid_sub = 0;
		//����� ��� ���������� ������� �������(�� ��������� �������)
		int sub_indexes[3];
		//������ ��� ������ "sub_indexes"
		int sub_ind_count = 0;
		//�������� �� ��������� �� �������� ���������
		if (!(find(substrs.begin(), substrs.end(), cipher.substr(i, 3)) != substrs.end()))
		{
			//�� ���������. ����, ����� �� �� ������ ��� ��� ���������� �� ��������
			//�� �������������� �� ��������� ����
			substrs.push_back(cipher.substr(i, 3));
			//����� �������� � ����
			for (int i1 = 0; i1 < cipher.size() - 2; i1++)
			{
				//���� �������� 3, ��...
				//(��������� 3 ������ �� ���������� ��� ���������� ���������)
				if (sub_ind_count == 2) {
					//����� ���������
					int distance = sub_indexes[1] - sub_indexes[0];
					//����� ��������� �� �������
					distances.push_back(distance);

					cout << "substr " << cipher.substr(i, 3) << "  sub_indexes = "
						<< sub_indexes[1] << " and "
						<< sub_indexes[0]
						<< "  distance = " << distance << endl;
					cout << endl;

					break;
				}

				//���� �������� � ����� ����� 3
				if (cipher.substr(i, 3) == cipher.substr(i1, 3))
				{
					//����� ������� �� ������ ��������
					//cout << cipher.substr(i, 3) << " - pos = " << i1 << endl;
					sub_indexes[sub_ind_count] = i1;
					//��. �������� ��������
					sub_ind_count++;
				}
			}
		}

	}
	//}

	return distances;
}

//set for me. get factors without repeating for cheking. you can delete it
set<int> fact;
vector<int> getFactors(vector<int> factors, vector<int> distances)
{
	//���� ����� ���������
	for (int i = 0; i < distances.size(); i++)
	{
		//more then 2 because two is too short for keyword length
		//��������� ����� ��� ��������� �������. 
		//(��� �� ������ - �� ������� �����-�����, � ������� ����� ��
		//����, ���� ����� �� 2, �� i1(������) �� ���� ������ �� 2
		for (int i1 = distances.at(i); i1 > 2; i1--)
		{
			//��������� ������ ���������
			if (distances.at(i) % i1 == 0)
			{
				//���� ����� �� ���� ����������� ������ ���� ���� ����� 20
				if (i1 < 20)
				{
					//����� ��������� ������
					factors.push_back(i1);
					//you can delete fact.insert(i1). its too for set
					fact.insert(i1);
				}
			}
		}
	}

	return factors;
}

//�� �������� ������� ��������� ������� �����-�����
int getKeyLength(set<int> lengths, vector<int> factors, string cipher)
{
	vector<int> temp;
	for (int i = 0; i < factors.size(); i++)
	{
		int count_factors = 0;
		if (!(find(temp.begin(), temp.end(), factors.at(i)) != temp.end())) {
			temp.push_back(factors.at(i));

			for (int i1 = 0; i1 < factors.size(); i1++)
			{
				if (factors.at(i) == factors.at(i1))
					count_factors++;
			}
			//����� �������� ������� � ���� �-�� � ����
			keyLengths.push_back(make_pair(count_factors, factors.at(i)));
		}
	}

	//������ ��� ������� ������ �������
	sort(keyLengths.begin(), keyLengths.end());

	cout << "count of factors " << "  probable length" << endl;

	for (int i2 = keyLengths.size() - 1; i2 > 0; i2--)
	{
		//���� ��� �������(�������), ���� �������� � �����
		if (lengths.size() >= 3) break;
		lengths.insert(keyLengths[i2].second);
		cout << keyLengths[i2].first << ", " << keyLengths[i2].second << endl;
	}


	vector<char> vIn;

	//��� ����������� ��������� ������� ����� �������� ����������� ���������

	//��������� �������
	for (set<int>::iterator i = lengths.begin(); i != lengths.end(); i++) {
		int element = *i;
		cout << *i << " ";
		int len = *i;
		//������� �������� ������� � �-��� ��� ����������� ������� ���������
		res.push_back(make_pair(getIC(len, cipher), len));
	}

	//sort(res.begin(), res.end());
	using pair_type = decltype(res)::value_type;
	auto pr = max_element
	(
		//����� ��������� ������ ���������
		begin(res), end(res),
		[](const pair_type & p1, const pair_type & p2) {
		return p1.first < p2.first;
	}
	);
	cout << "Percentage is: " << pr->first << ", length is " << pr->second;

	return pr->second;
}

//������ ������ �� �-���� ���������� �����
vector<char> Gx;
vector<char> stopDublicate;

float getIC(int len, string cipher)
{
	float IC = 0;

	for (int i = 0; i < len; i++)
	{
		cout << i << ": ";
		for (int i1 = i; i1 < cipher.size(); i1 += len)
		{
			cout << cipher.at(i1);
			Gx.push_back(cipher.at(i1));
		}
		cout << endl << "------------------" << endl;

		int IC_1 = 0;
		for (int i2 = 0; i2 < Gx.size(); i2++)
		{
			if (!(find(stopDublicate.begin(), stopDublicate.end(), Gx.at(i2)) != stopDublicate.end()))
			{
				int count = 0;
				stopDublicate.push_back(Gx.at(i2));
				for (int i3 = 0; i3 < Gx.size(); i3++)
				{
					if (Gx.at(i2) == Gx.at(i3)) {
						count++;
					}
				}
				cout << Gx.at(i2) << " count = " << count << endl;
				//times of repeating char
				int F = count;
				IC_1 += (F * (F - 1));
			}
		}

		//������� �-�� ������� � G
		int N = Gx.size();
		//������� ������ ������� �����
		IC += (float)IC_1 / (float)(N * (N - 1));
		cout << endl << "---- IC ----- " << endl << len << " IC = " << IC << endl;

		Gx.clear();
		stopDublicate.clear();
	}
	//������� ������ ��� ����
	float res = IC / len;
	cout << endl << "res = " << res << endl;
	//������� ��� �������� ������ �� ���� ��������
	Gx.clear();
	stopDublicate.clear();

	return res;
}


//x2 ��� ��������� Gx
float X2_2 = 0;
void getAllX2(string cipher, int length)
{
	cout << endl; //<< "get Gx: ";
	for (int i = 0; i < length; i++)
	{
		X2_2 = 0;
		//cout << "G" << i+1 << ": " << endl;
		for (int i1 = i; i1 < cipher.size(); i1 += length)
		{
			Gx.push_back(cipher.at(i1));
			//cout << cipher.at(i1);
		}
		char letter = func1(cipher, Gx);
		cout << letter << " ";
		Gx.clear();
	}
}

vector<char> movedGx;
//get first letter of keyword
char func1(string cipher, vector<char> Gx)
{
	//list_x2 list1;
	GxX2.clear();
	movedGx.clear();

	for (int i = 0; i < 26; i++)
	{
		//cout << endl << engAlphab[i] << " ";
		movedGx.swap(movePos(Gx, i));
		float X2_Gx = func2(cipher, movedGx);
		GxX2.push_back(make_pair(engAlphab[i], X2_Gx));
		//list1.insert(list_x2::value_type(engAlphab[i], X2_Gx));
	}
	sort(GxX2.begin(), GxX2.end(), [](auto &left, auto &right) {
		return left.second < right.second;
	});
	char result = GxX2[0].first;

	return result;
}

vector<char> temp;
vector<char> movePos(vector<char> Gx, int moveTo)
{
	temp.clear();
	//cout << endl;
	for (int i = 0; i < Gx.size(); i++)
	{
		int pos = 0;
		int pos1 = 0;
		char *pch = strchr(engAlphab, Gx.at(i));
		while (pch != NULL)
		{
			//printf("found at %d\n", pch - engAlphab + 1);
			pos1 = pch - engAlphab;
			pos = pch - engAlphab - moveTo;
			pch = strchr(pch + 1, Gx.at(i));
		}
		if (pos < 0) { 
			int temp = moveTo - pos1;
			pos = 26 - temp;
		}
		//cout << pos << " ";
		temp.push_back(engAlphab[pos]);
	}

	return temp;
}

float func2(string cipher, vector<char> Gx)
{
	//need it for getting % of letter
	int N = Gx.size();
	//x2 ��� ������� ����� � Gx
	float X2_1 = 0;
	float X2_2 = 0;

	//---��� ���� �������. ��� ������ G�
	//������� ������ ��� ������������ ����� ����� � Gx
	for (int i = 0; i < Gx.size(); i++)
	{

		int count = 0;
		if (!(find(stopDublicate.begin(), stopDublicate.end(), Gx.at(i)) != stopDublicate.end()))
		{
			//cout << endl << " ----------" << endl;
			//cout << Gx.at(i) << " ";
			stopDublicate.push_back(Gx.at(i));
			for (int i1 = 0; i1 < Gx.size(); i1++)
			{
				if (Gx.at(i) == Gx.at(i1))
				{
					count++;
				}
			}
			//������� � % ������ ��� ������ ����� � Gx
			float perc = (float)count / (float)N;
			//������ ���� ����� ������� �� Gx � ����� ���� engAlph
			int ind = 0;
			//-----����� ����� �� engAlph, ��� = Gx.at(i)
			char *pch = strchr(engAlphab, Gx.at(i));
			while (pch != NULL)
			{
				//printf("found at %d\n", pch - engAlphab + 1);
				ind = pch - engAlphab;
				pch = strchr(pch + 1, Gx.at(i));
			}
			//------�������
			//cout << count << ", perc = " << perc << ", letter = " <<engAlphab[ind] <<  ", freq in eng = " << F_engFreqVal[ind];
			X2_1 = (float)perc - (float)F_engFreqVal[ind];
			X2_1 = pow(X2_1, 2);
			X2_1 = X2_1 / F_engFreqVal[ind];
			X2_2 += X2_1;
			//cout << " X2_1 = " << X2_1 << " X2_2 = " << X2_2;
		}
	}

	//cout << "X2_2 = " << X2_2 << endl;
	stopDublicate.clear();

	return X2_2;
}