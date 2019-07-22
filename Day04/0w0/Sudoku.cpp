#include <bits/stdc++.h>
using namespace std;

const int maxn = 9;
int gameMap[maxn][maxn] = {0};

void printMap(int array[maxn][maxn]) {
	cout << "-------------------------------------" << endl;
	for(int i = 0; i < maxn; i++) {
		for(int j = 0; j < maxn; j++) {
			cout << array[i][j] << " ";
		}
		cout << endl;
	}
	cout << "-------------------------------------" << endl;
}

bool judge(int array[maxn][maxn]) {
	for(int i = 0; i < maxn; i++) {
		set<int> sRow, sColumn;
		int cntRow = 0, cntColumn = 0;
		for(int j = 0; j < maxn; j++) {
			if(array[i][j] == 0)
				cntRow++;
			else
				sRow.insert(array[i][j]);
			if(array[j][i] == 0)
				cntColumn++; 
			else
				sColumn.insert(array[j][i]);
		}
		//cout << "set1 And cnt1: " << sRow.size() << " + " << cntRow << " = " << sRow.size() + cntRow << endl;  
		//cout << "set2 And cnt2: " << sColumn.size() << " + " << cntColumn << " = " << sColumn.size() + cntColumn << endl; 
		if(sRow.size() + cntRow != maxn || sColumn.size() + cntColumn != maxn) {
		//	cout << "Row or Column is No!" << endl;
			return false; 
		}
	}
	int dx[9] = {0, -1, -1, 0, 1, 1, 1, 0, -1};
	int dy[9] = {0, 0, -1, -1, -1, 0, 1, 1, 1};
	int cx[9] = {1, 1, 1, 4, 4, 4, 7, 7, 7};
	int cy[9] = {1, 4, 7, 1, 4, 7, 1, 4, 7};
	for(int i = 0; i < 9; i++) {
		set<int> sGrid;
		int cntGrid = 0;
		for(int k = 0; k < 9; k++) {
			int x = cx[i] + dx[k];
			int y = cy[i] + dy[k];
			if(array[x][y] == 0)
				cntGrid++;
			else
				sGrid.insert(array[x][y]);
		}
		//cout << "set3 And cnt3: " << sGrid.size() << " + " << cntGrid << " = " << sGrid.size() + cntGrid << endl;
		if(sGrid.size() + cntGrid != maxn) {
		//	cout << "Grid is No!" << endl;
			return false;
		}
	}
	return true;
}

bool isFind = false;

void Generate(int array[maxn][maxn], int k) {
	if(k >= maxn * maxn || isFind) {
		isFind = true;
		printMap(gameMap);
		return;
	}
	int x = k / maxn, y = k % maxn;
	vector<int> vec(maxn);
	for(int i = 0; i < maxn; i++)
		vec[i] = i + 1;
	while(vec.size()) {
		if(isFind)
			return;
		int random = rand() % vec.size();
		array[x][y] = vec[random];
		vec.erase(vec.begin() + random);
		if(judge(array)) {
			Generate(array, k + 1);
		} 
	}
	if(!isFind)
		array[x][y] = 0;
}

int main() {
	//freopen("cin.txt", "r", stdin);
	//freopen("cout.txt", "w", stdout);
	srand(time(NULL));
	/*
	for(int i = 0; i < maxn; i++) {
		for(int j = 0; j < maxn; j++) {
			cin >> gameMap[i][j];
		}
	}
	*/
	Generate(gameMap, 0);
	printMap(gameMap);
	if(judge(gameMap)) {
		cout << "YES" << endl;
	} else {
		cout << "NO" << endl; 
	}
	return 0;
}
