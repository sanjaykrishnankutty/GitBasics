// Hello.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include "Person.h"
#include "Twitter.h"
using std::cout;
using std::string;

int main()
{
    std::string name;
    int count=1;
    double count1 = 2.2;
    count = static_cast<int>(count1);
    bool valid(1);
    char s;
    auto a1 = 1;
    string str;
    std::cin >> name;
    cout << "Hello World!\n";
    cout << "Hello, " << name << std::endl;
    Person person("Sanjay","KrishnanKutty",1);
    auto returnValue = person.GetName();
    std::cout << returnValue << std::endl;
    {
        Twitter twitter("Twinkle", "Jayachandran", 2, "@twinkleJayachandran");
        auto result = twitter.GetName();
    }
    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
