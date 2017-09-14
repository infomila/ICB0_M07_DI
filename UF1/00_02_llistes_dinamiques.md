[ ... back  ]( ../README.md)

# Llistes din�miques  (_List_) 

Les llistes din�miques, a difer�ncia de les taules, s�n estructures de dades que poden anar creixent a demanda. No cal que donem una mida inicial de la llista, sin� que la llista anir� allotjant mem�ria a mesura que necessiti afegir nous elements a la llista.

.NET ens proporciona fets els tipus abstractes de dades din�mics m�s habituals, cal triar el m�s adequat segons les nostres necessitats. Per comen�ar treballarem amb l'estructura d'�s m�s general: _List_
Tanmateix n'hi ha d'altres tipus d'estructures de dades per desar "col�lecions" , entre d'altres:
 * List
 * Queue
 * Stack
 * Dictionary
 
## Inicialitzaci�

La sintaxi d'una llista din�mica b�sica �s:

```c#
	List<[tipus de dades]> = new List<tipus de dades]();
```

```c#
    // Creaci� duna llista din�mica
    List<string> people = new List<string>();
```

## Afegir elements

```c#
    // Afegir elements a la llista
    people.Add("Maria");
    people.Add("Berta");
    people.Add("Joan");
    people.Add("Pep");
```    
```c#    
    // Acc�s per �ndex
    people[2] = "Josep";
```
##  Recorreguts

```c#
    // Recorregut per �ndex
    string noms = "";
    for(int n=0;n<people.Count;n++)
    {
    	noms += $" - {people[n]} \n";
    }
    ```

```c#
    // Recorregut amb foreach
    foreach( string p in people )
    {
    	noms += $" - {p} \n";
    }
```
## Eliminar elements

```c#
    // Eliminaci� d'un element de la llista
    noms.Remove(2, 1); // esborra l'element amb �ndex 2 ( el tercer )
    // i reindexa els posteriors
    noms.Remove(2);  // esborra tots els elements de la llista a partir del que 
    // est� a l'index 2 (incl�s)
```

 ## Cerca d'elements
 ```c#
     bool MariaFound = people.Contains("Maria"); // mariaFound �s true
     bool mariaFound = people.Contains("maria"); // mariaFound �s false
     bool kkFound = people.Contains("kk"); //kkFound false
```

 # Diccionaris
 Un diccionari �s una taula que associa una clau amb un valor. A difer�ncia de les taules convencionals, on la clau sempre �s un valor enter de 0 a N-1, als diccionaris trobem que:
 * les claus no tenen per qu� ser correlatives
 * les claus poden ser de qualsevol tipus de dades: n�meros, cadenes, dates .....
 
 ## Inicialitzaci� i entrada de dades dels diccionaris:
 ```c#
     //    tipus de la clau, tipus del valor
     Dictionary<string, int> anotacions = new Dictionary<string,int>();
     // assignem valor a una clau
     anotacions["Maria"] = 10;
     anotacions["Pere"] = 8;
```
Despr�s d'executar les l�nies anteriors, tenim en mem�ria una taula com la seg�ent:

CLAU | Valor
-----|-----
Maria|10
Pere|8

Podem accedir als valors proporcionant la clau. Tingueu present que si la clau no es troba, ens llan�a una excepci� ___KeyNotFoundException___
  ```c#
    // Buscar valor existent
    int anotacioMaria = anotacions["Maria"]; //anotacioMaria = 10
    Debug.WriteLine(anotacioMaria);

    // Buscar valor que potser no hi �s ?�
    try
    {
    	int anotacioFantasma = anotacions["????"];

    }catch(Exception ex)
    {
    	Debug.WriteLine("Persona no trobada !!");
    }
```

Si volem assegurar el tret, podem preguntar al diccionari si la clau existeix abans d'intentar llegir-ne el valor, usant _.ContainsKey_:
 ```c#
     if(anotacions.ContainsKey("????"))
     {
     	// fer aqu� la feina amb la seguretat que la clau existeix
     }
 ```
 Tamb� podem fer recorreguts, 
 
 ```c#
     // Primer aconseguim la col�lecci� de totes les claus
     var claus = anotacions.Keys;
     // Recorrem les claus, i per cada clau demanem el valor
     foreach( string clau in claus)
     {
     	Debug.WriteLine($"{clau} ha fet {anotacions[clau]} punts");
     } 
 ```
 
 ```c#
	// Podem fer tamb� un recorregut estrictament pels valors
	var valors = anotacions.Values;
	foreach(int anotacio in valors)
	{
		Debug.WriteLine($"{anotacio}");
	} 
 ```