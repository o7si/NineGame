#include <iostream>
#include <vector>
using namespace std;
// ɾ��ʹ��erase����������������ָ�� 
int main() {
	const int maxn = 10;
	vector<int> vec(maxn);
	for(int i = 0; i < maxn; i++)
		vec[i] = i;
	vec.erase(vec.begin());
	for(int i = 0; i < vec.size(); i++)
		cout << vec[i] << " ";
	return 0; 
} 
