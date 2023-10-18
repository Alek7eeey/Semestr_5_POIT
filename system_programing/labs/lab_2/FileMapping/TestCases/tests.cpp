#include "tests.h"

namespace tests 
{
	BOOL test1(HT::HtHandle* ht)
	{
		try
		{
			HT::insert(ht, new HT::Element("newKey", 3, "data", 5));
		}
		catch (const char* msg)
		{
			if (strcmp(msg, "error: so long key") == 0)
			{
				return true;
			}
			return false;
		}
	}

	BOOL test2(HT::HtHandle* ht)
	{
		try
		{
			HT::insert(ht, new HT::Element("newKey", 7, "dataFile", 3));
		}
		catch (const char* msg)
		{
			if (strcmp(msg, "error: so long payload") == 0)
			{
				return true;
			}
			return false;

		}
	}

	BOOL test3(HT::HtHandle* ht)
	{
		try
		{
			HT::open(L"./files/HTspace.ht", true);
			HT::Element* element = new HT::Element("test22", 7, "dataInfo", 9);
			HT::get(ht, element);
		}
		catch (const char* msg)
		{
			if (strcmp(msg, "error: file not found") == 1)
			{
				return true;
			}
			return false;
		}
	}

	BOOL test4(HT::HtHandle* ht)
	{
		try
		{
			HT::Element* element = new HT::Element("test2", 6, "dataInfo", 9);
			HT::insert(ht, element);
			HT::insert(ht, element);

		}

		catch (const char* msg)
		{
			if (strcmp(msg, "error: file is already insert") == 1)
			{
				return true;
			}
			return false;
		}
	}

	BOOL test5(HT::HtHandle* ht)
	{
		try 
		{
			HT::Element* element = new HT::Element("test2", 6, "dataInfo", 9);
			HT::insert(ht, element);
			HT::remove(ht, element);
			HT::remove(ht, element);

		}
		
		catch (const char* msg)
		{
			if (strcmp(msg, "error: element is already remove") == 1)
			{
				return true;
			}
			return false;
		}
	}
}