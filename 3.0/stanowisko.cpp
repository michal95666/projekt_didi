
enum TYP_ZDARZENIA
{
	NONE,
	WEZWANIE_DOSTAWY, // dochodzi do magazynu wyjsciowego
	PRZYBYCIE_DOSTAWY, // dochodzi do obu magazynow
	WEZWANIE_ODBIORU, // dochodzi do magazynu wejsciowego
};

class Zdarzenie
{
	Stanowisko* adresat;
	TYP_ZDARZENIA typ;
	double interwalCzasowy;
	int parametry1;
	int parametry2;
	int parametry3;
};

class Stanowisko
{
	// limity, limity, limity

	int magazynWejsciowyItem1;
	int magazynWejsciowyItem2;
	int magazynWyjsciowyItem1;
	
	bool enabled;
	bool productionInProgress;
	bool wyslanoWezwanieDostawy; // w przypadku kilku dostawc�w jest kilka wezwa� i kilka flag
	bool wyslanoWezwanieOdbioru;
	
	void ObslugaZdarzenia(Zdarzenie zdarzenie);
}

// funkcja wywow�ywana w okre�lonej chwili czasowej przez koordynatora
void Stanowisko::ObslugaZdarzenia(Zdarzenie zdarzenie)
{
	if (enabled)
	{
		switch(zdarzenie.typ)
		{
			case WEZWANIE_DOSTAWY:
				magazynWyjsciowyItem1 -= liczba_elementow; 
				wyslanoWezwanieOdbioru = false;
				break;
			case PRZYBYCIE_DOSTAWY:
				magazynWejsciowyItem1 += liczba1_elementow;
				magazynWejsciowyItem1 += liczba2_elementow;
				wyslanoWezwanieDostawy = false;
				break;
			case WEZWANIE_ODBIORU:
				koordynator.AddZdarzenie(/*...WEZWANIE_DOSTAWY...*/);
				wyslanoWezwanieDostawy = true;
				break;
		}
	
		if (productionInProgress)
		{
			
		}
	}
}

void Koordynator::GLownaPetla
{
	for(;;)
	{
		// wybranie najwcze�niejszego przysz�ego zdarzenia
		
		// wywo�anie Stanowisko::ObslugaZdarzenia()
	}
}

void main()
{
	Korrdynator koordynator;
	
	Stanowisko X(koordynator);
	Stanowisko A(koordynator);
	//...
	
	koordynator.AddStanowisko(X);
	koordynator.AddStanowisko(Y);
	koordynator.AddStanowisko(A);
	// ... 
	
	Product p1(0, "something");
	Product p2(1, "something else");
	Product p3(2, "sextoy");
	
	X.AddProductInWarehouse(&p1, /* limity, pocz�tkowa warto��*/); // nazwa produktu
	X.AddProductInWarehouse(&p2, /* */);
	X.AddProductInWarehouse(&p3, /* */);
	X.AddOdbiorca(A, &p1);
	A.AddProductInWarehouse(&p1, /* inne limity */);
	A.AddDostawca(X, &p1);
	
	
}