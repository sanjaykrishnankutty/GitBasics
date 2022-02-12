#include "Twitter.h"
#include <iostream>

Twitter::Twitter(std::string firstName, std::string lastName, int personId, std::string twitterHandle) :
	Person(firstName, lastName, personId), twitterHandle(twitterHandle)
{
	std::cout << "Constructing twitter handle" << std::endl;
}

Twitter :: ~Twitter()
{
	std::cout << "Destructing twitter handle" << std::endl;
}