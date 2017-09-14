[ ... back  ]( ../README.md)

# Introducció al llenguatge C# :coffee:

## Comentaris
```c#
	 //  comentari monolínea
	 /*   
	   comentari multilínia
	 */
 ```
 
 
## Missatges de depuració
Per mostrar missatges de debug , que es poden trobar a la finestra _Salida_o _Output_ de Visual Studio ),
cal usar la comanda _Debug_WriteLine("MISSATGE")_

```c#
 Debug.WriteLine("Hello world");
```
 
 
##  Sortida / Entrada per consola


>NOTA: _System.Console_ és la classe que cal utilitzar per escriure a consola.
>
>   * Si useu WPF + .NET Framework  es pot fer servir immediatament.
> * Si useu Universal Apps + .NET Core, cal que carregueu el mòdul de consola. Això ho podeu fer editant l'arxiu _project.json_ i afegint la part que es mostra més a sota entre comentaris:
```
{
  "dependencies": {
    "Microsoft.NETCore.UniversalWindowsPlatform": "5.1.0"
  },
  "frameworks": {
    "uap10.0": { },
    //--------------------------------------------------------------
    "dnxcore50": {
      "dependencies": {
        "System.Console": "4.0.0-beta-*"
      }
    }
    //--------------------------------------------------------------
  },
  "runtimes": {
    "win10-arm": {},
    "win10-arm-aot": {},
    "win10-x86": {},
    "win10-x86-aot": {},
    "win10-x64": {},
    "win10-x64-aot": {}
  }
}
```

Els següent exemple mostra l'utilització de la consola:

```c#
	// Escrivint per consola
	System.Console.WriteLine("");
	// Llegint l'entrada de l'usuari
	string userInput = System.Console.ReadLine();
```

Alternativament, posant un "using" a la part inicial de l'arxiu *.cs
podeu simplificar-ho, podent usar directament el nom de la classe "Console", en comptes del nom complet "System.Console" .
```c#
	using System;
	...
	// Escrivint per consola
	Console.WriteLine("");
	// Llegint l'entrada de l'usuari
	string userInput = Console.ReadLine();
```




-------------------------------------------------------------------------------


## Tipus de dades i variables
### Tipus de dades primitius

Els tipus de dades primitius tenen una mida fixa definida pel runtime de .NET
Les variables de tipus primitius es desen a la pila.

 Name |	.NET Type 	   |Description 	               |Range (min:max)
 -------- | ------------------|-----------------------------|-----------------------------
 sbyte 	|System.SByte 	|8-bit signed integer    	|-128:127 (-27:27–1)
 short 	|System.Int16 	|16-bit signed integer 	|-32,768:32,767 (-215:215–1)
 int 	    | System.Int32 	|32-bit signed integer 	|-2,147,483,648:2,147,483,647 (-231:231–1)
 long 	|System.Int64 	|64-bit signed integer 	|-9,223,372,036,854,775,808: 9,223,372,036,854,775,807 (-263:263–1)
 byte 	|System.Byte 	   |8-bit unsigned integer 	|  0:255 (0:28–1)
 ushort 	|System.UInt16 |16-bit unsigned integer |  0:65,535 (0:216–1)
 uint 	   |System.UInt32 	|32-bit unsigned integer|	0:4,294,967,295 (0:232–1)
 ulong 	|System.UInt64 |64-bit unsigned integer |   0:18,446,744,073,709,551,615 (0:264–1)


### Declaració i inicialització de variables

Sintaxi idèntica a C:
```
[tipus de dades] [nom variable];
```
o usant  inicialització directa:
```
[tipus de dades] [nom variable] = [valor inicial];
```

### Literals
```c#
	bool  b = true;
	bool  bf = false;
	int i = 10;
	long lng = 1000L;
	ulong ulng = 10000UL;
	float f     = 10.4f; // f indica float
	double f = 10.4; // per defecte els nombres amb decimals són float.
	decimal d = 10.4M; // M de Money
	char c = 'A';
	
	
```
### Coma flotant o coma fixa 

Si useu _double_o _float_, useu representació en coma flotant. Aquesta representació permet treballar amb magnituds arbitràriament grans o petites, però duu associada una precisió, que pot fer que el valor que s'emmagatzemi no sigui exactament el valor que voliem desar.

Si usem _decimal_, treballem amb coma fixa. El llenguatge ens garanteix preservar fins a 29 digits sense pèrdua d'informació.
Aquest tipus de dades és el que farem servir per representar valors monetaris.

### Inferència de tipus: usant _var_
Podem "escaquejar-nos" de dir el tipus de dades, i deixar que sigui el compilador qui ho determini.
Això ho indiquem usant el tipus de dades  _var_, que en realitat el que fa és obligar el compilador a decidir automàticament el tipus de dades.

```c#
    var x = 25; // això és equivalent a : int x = 25;
	var nom = "Paco";  // això equival a string nom ="Paco";
```
### Constants
Podem definir valors constants, que no es poden manipular posteriorment a la seva declaració. Cal inicialitzar la constant en la declaració.
```c#
	const int a = 100;
```
## Scope o àmbit de les variables
###  Variables locals i atributs. Valors per defecte
El compilador ens avisa si hi ha variables locals que s'utilitzen sense incialitzar.
Hi ha un tipus de variables "especials" anomenades atributs, molt diferent de les variables locals.  Recordeu que les variables locals "desapareixen" quan acaba la funció que s'executa. Per contra, els atributs mantenen el seu valor mentre l'objecte on estan existeix.
La diferència entre un atribut i una variable local és el lloc on es declara:
```c#
    public sealed partial class MainPage : Page
    {
        int edat; // això és un atribut

...

        private void btnBoto_Click(object sender, RoutedEventArgs e)
        {
            decimal preu; // això és una variable local
			...

```
Els atributs si que es poden fer servir sense donar un valor inicial, doncs C# els inicialitza amb un valor per defecte segons el seu tipus de dades:

     tipus             | valor per defecte 
 --------------------|----------------------
 tipus numèrics  |            0             
 tipus _bool_ |            false             
 tipus _char_ |            caràcter 0         
 tipus _string_  |            null             
 tipus _object_  |            null             
 
### Col·lisió de noms entre atributs i variables locals

 Es pot donar el cas de declarar una variable local i un atribut amb el mateix nom. Això COMPILA i és dona per vàlid:
 
 ```c#
     class Persona
    {
        private string nom ="Paco";

        public Persona()
        {
            string nom = "Maria";

            string copia = nom; // Què val "nom" aquí?

        }
    }
```
En la línia on hi ha el comentar, fem servir la variable _nom_, però hi ha certa ambigüitat doncs no sabem si ens estem referint a l'atribut o a la variable loca.l

La regla és senzilla, si no es diu el contrari , sempre  ens referim a la *variable local *
Si volem forçar la referència a l'atribut cal usar el prefixe _this._
```c#
    class Persona
    {
        private string nom ="Paco";

        public Persona()
        {
            string nom = "Maria";

            string copia = nom; // "Maria"
            string copia1 = this.nom;  // "Paco"
        }
    }
```

###  Limitació de l'àmbit usant { } adiccionals
Les variables sempre tenen un àmbit de vida limitat per les claus més internes on estan declarades. Això ens porta a que , de vegades, volem restringir  l'àmbit d'una variable a un fragment de codi, i això ho aconseguim forçant l'us de brackets addicionals:
```c#

            { // inici de l'àmbit
                int v = 3; // la variable v "viu" dins dels brackets
                v++;

                //int v = 45;  // Això no compilaria, la variable existeix.
            } // final de l'ambit ( v desapareix )
            {
                int v = 4; // aquí la puc tornar a declarar, doncs v  no existeix
                v--;
            }
```




## Treballant amb cadenes
Les cadenes són UNICODE ( per tant cada caràcter ocupa 16bits, i permeten representació universal de caràcters de la majoria de llenguatges exisitents ) 

 * Concatenació
Concatenem cadenes amb l'operador +
```c#
	string nom = "Josep " + "Maria";
	string nom_complet = nom + " López";
 ```

 * Salt de línia
 Podem usar els literals "\n" o "\r\n"per representar el salt de línia:
 
 ```c#
	string dosLinies = "Primera Línia\nSegona Línia";
 ```
 
 És millor utilitizar la seva representació genèrica _Environment.NewLine_:
 
  ```c#
	string dosLinies = "Primera Línia"+ Environment.NewLine + "Segona Línia";
 ```
 * Autoreemplaçament
 Si prefixem la cadena amb un $, podem incrustar valors de variables dins de la cadena sense haver de fer concatenacions.
 
   ```c#
             string cadena = "Món";
            string autoreemplaç = $"Hola {cadena} ! ";
  ```
  
 * Mètodes de conversió
 Qualsevol tipus primitiu es pot convertir a cadena usant .toString()
 
 
 
 * Mètodes de cerca, substitució i trimming
 
     MÈTODE             | FUNCIÓ
 --------------------|----------------------
 .Substring( posició_inicial )  |    retorna la subcadena que comença a posició_inicial(inclosa) fins al final            
.Substring( posició_inicial, num_chars ) |       retorna la subcadena que comença a posició_inicial(inclosa), prenent num_chars consecutius a partir de la posició inicial (la posició inicial compta)              
.Trim()     | Elimina espais en blanc a l'inici i final de la cadena
.Trim(char[] caracters) | Elimina els caràcters indicats al paràemtre del inici i final de la cadena
 .PadLeft(num_cars)  | omple la cadena per l'esquerra amb espais en blanc, fins assolir longitud num_cars
 .PadLeft(num_cars),  caracter_de_padding)| omple la cadena per l'esquerra amb caracter_de_padding, fins assolir longitud num_cars
 .Length  | longitud de la cadena
 cadena[i]   | accés directe al ièssim caràcter de la cadena
 
 
### Conversions de tipus numèric a cadena
Al convertir a cadena un número, podem especificar el nombre de posicions senceres i decimals, així 
com la utilització  o no d'un separador de milers.
```c#
	double numeroDec = 2321.23;
	string num = numeroDec.ToString("#####.000"); //2321,230
 
	num = numeroDec.ToString("##,###.000"); //2.321,230
 
	// Utilitzant un indicador de cultura
	CultureInfo us = new CultureInfo("en-US");
	num = numeroDec.ToString("##,###.000", us); //2,321.230
 ```
### Conversions de tipus data a cadena
#### Declaració de data
Les dates es representen amb el tipus DateTime, que permet emmagatzemar la data i la hora ( hores, minuts i segons )
de forma conjunta.
Per declarar i inicialitzar una data ho podem fer de diverses maneres:
```c#
            
            DateTime ara = DateTime.Now; // ARA, incloent dia i hora

            DateTime avui = DateTime.Today; // ARA, incloent dia només

            DateTime data = new DateTime(2017, 12, 31); // constructor explícit amb data

            DateTime dataIHora = new DateTime(2017, 12, 31, 22, 30, 59); // constructor explícit amb data i hora


```
#### Conversió a cadena especificant el format
Podem usar cadenes de format per especificar quina és la representació que volem assolir.
```c#

            string dataS = data.ToString("dd/MM/yyyy"); //  31/12/2017
            txtMissatge.Text += ">" + dataS + "\n";
            dataS = data.ToString("dd-MMM-yy hh:mm:ss"); // 31-dic.-17 12:00:00

            dataS = data.ToString("dddd, dd \\de MMMM \\de yyyy"); //domingo, 31 de diciembre de 2017

            dataS = data.ToString("hh:mm:ss"); //12:00:00

            CultureInfo fr = new CultureInfo("fr-FR");
            dataS = data.ToString("dddd, dd \\de MMMM \\de yyyy", fr); //dimanche, 31 de décembre de 2017
```
### Conversions de cadena a tipus numèrics (Parsing)

Podem treballar de forma "Segura" amb _[TIPUS_DE_DADES].TryParse()_ . 
Podem usar  Aquest mètode intenta convertir la cadena a un número TIPUS_DE_DADES, on TIPUS_DE_DADES pot ser Int32, Double, etc.
Si la conversió falla, el mètode retorna false, true altrament.
Fixeu-vos que el resultat es retorna per un paràmetre de sortida ( marcat com a _out_ )
```c#


            double doubleParsed;

            bool exit = Double.TryParse("123,22", out doubleParsed); //doubleParsed = 123,22,  

            // Compte , per defecte usem els separadors decimals definits a l'idioma actual.
            exit = Double.TryParse("123.22", out  doubleParsed); //doubleParsed = 12322, exit = true
            

            // Podem especificar l'idioma i l'estil del número
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowDecimalPoint;
            CultureInfo uk = new CultureInfo("en-UK");
            exit = Double.TryParse("123.22", style, uk, out doubleParsed); //doubleParsed = 123,22, exit = true

            // Si dona error la conversió retorna false
            exit = Double.TryParse("123,xx", out doubleParsed); //doubleParsed = 0, exit = false
```
També podem anar "a l'aventura" usant _[TIPUS_DE_DADES].Parse()_, que funciona retornant directament el nombre
convertit, però amb el problema de que si la conversió no és correcta, llança una excepció.

```c#
            double dd = double.Parse("123,2"); // tot va bé dd= 123,2
            try
            {
                dd = double.Parse("xxxxx");
            }
            catch (Exception ex)
            {
                // Passem per aquí !!!
                dd = 0;
            }
```

### Conversions de cadena a tipus data (Parsing)
Si coneixem el format de la data dins de la cadena que se'ns proporciona, és senzill usar DateTime.ParseExact
per fer la conversió a DateTime:
```c#

            string dataAParsejar = "31-12-2020 14h 12' 55''";
            DateTime dataParsejada = DateTime.ParseExact(dataAParsejar, "dd-MM-yyyy HH\\h mm\\' ss\\'\\'",
                                   System.Globalization.CultureInfo.InvariantCulture);

            dataS = dataParsejada.ToString("dddd, dd \\de MMMM \\de yyyy, a le\\s HH:mm:ss tt");
            txtMissatge.Text += ">" + dataS + "\n";
```


