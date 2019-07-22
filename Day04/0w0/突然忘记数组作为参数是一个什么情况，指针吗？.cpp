#include <iostream>
using namespace std;

void func(int arr[3][3]) {
	for(int i = 0; i < 3; i++) {
		for(int j = 0; j < 3; j++) {
			arr[i][j] = i * 3 + j;
		}
	}
}

int main() {
	int arr[3][3] = {0};
	func(arr);
	for(int i = 0; i < 3; i++) {
		for(int j = 0; j < 3; j++) {
			cout << arr[i][j] << " ";
		}
		cout << endl;
	}
	return 0;
}
