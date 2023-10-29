#include <iostream>

void getCurrentDateAndTime()
{
	std::cout<<"Current date and time: "<<__DATE__<<" "<<__TIME__<<std::endl;
}

void main()
{
	getCurrentDateAndTime();
}