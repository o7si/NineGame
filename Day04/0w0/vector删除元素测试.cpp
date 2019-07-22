#include <iostream>
#include <vector>
using namespace std;
// 删除使用erase方法，参数类似与指针 
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
