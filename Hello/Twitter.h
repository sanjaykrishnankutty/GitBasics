#pragma once
#include "Person.h"

class Twitter : public Person
{
	private:
		std::string twitterHandle;
	public:
		Twitter(std::string firstName, std::string lastName, int personId, std::string twitterHandle);
		~Twitter();
};
