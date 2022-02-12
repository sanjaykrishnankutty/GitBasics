#pragma once
#include <string>

class Person
{
	private:
		int personId;
		std::string personFirstName;
		std::string personLastName;

	public:
		std::string GetName();

	Person(std::string firstName, std::string lastName, int persond);
	~Person();
};
