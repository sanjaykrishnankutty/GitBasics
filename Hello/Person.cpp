#include "Person.h"
#include <iostream>
#include <string>

std::string Person::GetName()
{
	return personFirstName + personLastName;
}

Person::Person(std:: string firstName, std:: string lastName, int personId) :
	personFirstName(firstName),
	personLastName(lastName),
	personId(personId)
{
	std::cout << "Constructing Person " << std::endl;
}

Person::~Person()
{
	std::cout << "Destructing Person" << std::endl;
}

