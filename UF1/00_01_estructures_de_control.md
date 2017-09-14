[ ... back  ](../README.md)

# Estructures de control

 
## condicionals
### if
```c#
	// if simple
	 if( a==3) {
		a++;
	 }
	 
	 // if compacte
	 if(a==3) a++;
	 
	 //if i else
	 if( a==3 ) {
		a++;
	 } else {
		a--;
	 }
	 
	 // if( a==3) {
		a++; 
	} else if(a==4) {
		a--; 
	} else {
		a=0;
	}
 ```
 ### if condensat
 És una estructura  if molt compacta:
 ```
 [ condició lògica ] ? [acció si la condició és certa ] : [ acció si és falsa ] ;
 ```
 Un exemple:
 
 ```c#
	 a==3? a++: a--;
 ```
 ### switch
 És igual que a C, però amb algunes peculiaritats:
  *  ens força a posar _break_ ( evita errors )
  *  podem fer _goto_
 
 Un exemple bàsic:
 
```c#
int nota = 5;
string notaDescriptiva ;
 switch (nota)
	{
	  case 5:
	  case 6:
		notaDescriptiva = "Aprovat";
		break;
	  case 7:
	  case 8:
		notaDescriptiva = "Notable";
		break;
	  case 9:
	  case 10:
		notaDescriptiva = "Excel·lent";
		break;
	  default:
		notaDescriptiva = "Insuficient";
		break;
	}
```

Funciona amb strings !!!!!!!

```c#
 
string notaDescriptiva;
int nota;

 switch (notaDescriptiva)
	{
	  case "Aprovat":
	    nota = 5;
		break;
	  case  "Notable":
	  nota = 7;
		break;
	  case  "Excel·lent":
	  nota = 9;
		break;
	  default:
		nota=4;
		break;
	}
```


I finalment un exemple on utilitzem _goto_
```c#

string language;
string pais;
int bonus=0;
...
switch(pais)
{
  case"US":
    bonus = 10;
    goto case"Britain";
  case"FR":
    language ="French";
    break;
  case"GB":
    language ="English";
    break;
}
```


------------------------------------------------------------------------------------------------------------


 ## Taules
 
 C# ens permet definir taules estàtiques:
  ```c#
             // exemple de taula amb inicialització
            int[] numeros= { 1, 6, 7, 10 };

            // podem fer taules de tipus més complexes, com cadenes
            string[] persones = { "Maria", "Berta", "Joan" };

            // creació d'una taula indicant dimensions, que s'omplirà
            // amb el valor per defecte del tipus de dades ( 0 en aquest cas )
            double[] temperatures = new double[10];
  ```
  
## Iteradors
### for
> for (initializer; condition; iterator):
>        statement(s)
  Funciona igual que a C.
  Iterador clàssic
```c#
int suma = 0;
int i ;
for ( i = 0; i < 100; i++)
{
  suma += i;
}
```
Iterador amb declaració incorporada
```c#
int suma = 0;
for (int i = 0; i < 100; i++)
{
  suma += i;
}
```

### while i do while
  
Igual que a C:

> while(condition)
>          statement(s);
  
  
> do {
>    statement(s)
> } while( condition );
  
###  foreach    
  Permet automatitzar el recorregut complet sobre una taula o llista.
  
Recorregut sobre taules:
  
```c#
            int[] numeros= { 1, 6, 7, 10 };
			string resultat = "";
            foreach( int t in numeros)
            {
                resultat += $" - {t}\n";
            }
```
	