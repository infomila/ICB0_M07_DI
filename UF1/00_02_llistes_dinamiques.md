[ ... back  ]( ../README.md)

# Llistes dinàmiques  (_List_) 

Les llistes dinàmiques, a diferència de les taules, són estructures de dades que poden anar creixent a demanda. No cal que donem una mida inicial de la llista, sinó que la llista anirà allotjant memòria a mesura que necessiti afegir nous elements a la llista.

.NET ens proporciona fets els tipus abstractes de dades dinàmics més habituals, cal triar el més adequat segons les nostres necessitats. Per començar treballarem amb l'estructura d'ús més general: _List_
Tanmateix n'hi ha d'altres tipus d'estructures de dades per desar "col·lecions" , entre d'altres:
 * List
 * Queue
 * Stack
 * Dictionary
 
## Inicialització

La sintaxi d'una llista dinàmica bàsica és:

```c#
	List<[tipus de dades]> = new List<tipus de dades]();
```

```c#
    // Creació duna llista dinàmica
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
    // Accés per índex
    people[2] = "Josep";
```
##  Recorreguts

```c#
    // Recorregut per índex
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
    // Eliminació d'un element de la llista
    noms.Remove(2, 1); // esborra l'element amb índex 2 ( el tercer )
    // i reindexa els posteriors
    noms.Remove(2);  // esborra tots els elements de la llista a partir del que 
    // està a l'index 2 (inclós)
```

 ## Cerca d'elements
 ```c#
     bool MariaFound = people.Contains("Maria"); // mariaFound és true
     bool mariaFound = people.Contains("maria"); // mariaFound és false
     bool kkFound = people.Contains("kk"); //kkFound false
```

 # Diccionaris
 Un diccionari és una taula que associa una clau amb un valor. A diferència de les taules convencionals, on la clau sempre és un valor enter de 0 a N-1, als diccionaris trobem que:
 * les claus no tenen per què ser correlatives
 * les claus poden ser de qualsevol tipus de dades: números, cadenes, dates .....
 
 ## Inicialització i entrada de dades dels diccionaris:
 ```c#
     //    tipus de la clau, tipus del valor
     Dictionary<string, int> anotacions = new Dictionary<string,int>();
     // assignem valor a una clau
     anotacions["Maria"] = 10;
     anotacions["Pere"] = 8;
```
Després d'executar les línies anteriors, tenim en memòria una taula com la següent:

CLAU | Valor
-----|-----
Maria|10
Pere|8

Podem accedir als valors proporcionant la clau. Tingueu present que si la clau no es troba, ens llança una excepció ___KeyNotFoundException___
  ```c#
    // Buscar valor existent
    int anotacioMaria = anotacions["Maria"]; //anotacioMaria = 10
    Debug.WriteLine(anotacioMaria);

    // Buscar valor que potser no hi és ?¿
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
     	// fer aquí la feina amb la seguretat que la clau existeix
     }
 ```
 També podem fer recorreguts, 
 
 ```c#
     // Primer aconseguim la col·lecció de totes les claus
     var claus = anotacions.Keys;
     // Recorrem les claus, i per cada clau demanem el valor
     foreach( string clau in claus)
     {
     	Debug.WriteLine($"{clau} ha fet {anotacions[clau]} punts");
     } 
 ```
 
 ```c#
	// Podem fer també un recorregut estrictament pels valors
	var valors = anotacions.Values;
	foreach(int anotacio in valors)
	{
		Debug.WriteLine($"{anotacio}");
	} 
 ```