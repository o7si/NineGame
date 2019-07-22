#include <iostream>
#include <string>
using namespace std;

int main() {
	freopen("cin.txt", "r", stdin);
	freopen("out.txt", "w", stdout);
	string str;
	while(getline(cin, str)) {
		int result = 0;
		for(int i = 0; i < str.length(); i++) {
			if(str[i] == ' ')
				continue;
			result = result * 2 + str[i] - '0';
		}
		cout << str << "====>" << result << endl;
	}
	return 0;
}
