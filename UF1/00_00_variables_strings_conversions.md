[ ... back  ]( ../README.md)

# Introducci� al llenguatge C# :coffee:

## Comentaris
```c#
	 //  comentari monol�nea
	 /*   
	   comentari multil�nia
	 */
 ```
 
 
## Missatges de depuraci�
Per mostrar missatges de debug , que es poden trobar a la finestra _Salida_o _Output_ de Visual Studio ),
cal usar la comanda _Debug_WriteLine("MISSATGE")_

```c#
 Debug.WriteLine("Hello world");
```
 
 
##  Sortida / Entrada per consola


>NOTA: _System.Console_ �s la classe que cal utilitzar per escriure a consola.
>
>   * Si useu WPF + .NET Framework  es pot fer servir immediatament.
> * Si useu Universal Apps + .NET Core, cal que carregueu el m�dul de consola. Aix� ho podeu fer editant l'arxiu _project.json_ i afegint la part que es mostra m�s a sota entre comentaris:
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

Els seg�ent exemple mostra l'utilitzaci� de la consola:

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
 sbyte 	|System.SByte 	|8-bit signed integer    	|-128:127 (-27:27�1)
 short 	|System.Int16 	|16-bit signed integer 	|-32,768:32,767 (-215:215�1)
 int 	    | System.Int32 	|32-bit signed integer 	|-2,147,483,648:2,147,483,647 (-231:231�1)
 long 	|System.Int64 	|64-bit signed integer 	|-9,223,372,036,854,775,808: 9,223,372,036,854,775,807 (-263:263�1)
 byte 	|System.Byte 	   |8-bit unsigned integer 	|  0:255 (0:28�1)
 ushort 	|System.UInt16 |16-bit unsigned integer |  0:65,535 (0:216�1)
 uint 	   |System.UInt32 	|32-bit unsigned integer|	0:4,294,967,295 (0:232�1)
 ulong 	|System.UInt64 |64-bit unsigned integer |   0:18,446,744,073,709,551,615 (0:264�1)


### Declaraci� i inicialitzaci� de variables

Sintaxi id�ntica a C:
```
[tipus de dades] [nom variable];
```
o usant  inicialitzaci� directa:
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
	double f = 10.4; // per defecte els nombres amb decimals s�n float.
	decimal d = 10.4M; // M de Money
	char c = 'A';
	
	
```
### Coma flotant o coma fixa 

Si useu _double_o _float_, useu representaci� en coma flotant. Aquesta representaci� permet treballar amb magnituds arbitr�riament grans o petites, per� duu associada una precisi�, que pot fer que el valor que s'emmagatzemi no sigui exactament el valor que voliem desar.

Si usem _decimal_, treballem amb coma fixa. El llenguatge ens garanteix preservar fins a 29 digits sense p�rdua d'informaci�.
Aquest tipus de dades �s el que farem servir per representar valors monetaris.

### Infer�ncia de tipus: usant _var_
Podem "escaquejar-nos" de dir el tipus de dades, i deixar que sigui el compilador qui ho determini.
Aix� ho indiquem usant el tipus de dades  _var_, que en realitat el que fa �s obligar el compilador a decidir autom�ticament el tipus de dades.

```c#
    var x = 25; // aix� �s equivalent a : int x = 25;
	var nom = "Paco";  // aix� equival a string nom ="Paco";
```
### Constants
Podem definir valors constants, que no es poden manipular posteriorment a la seva declaraci�. Cal inicialitzar la constant en la declaraci�.
```c#
	const int a = 100;
```
## Scope o �mbit de les variables
###  Variables locals i atributs. Valors per defecte
El compilador ens avisa si hi ha variables locals que s'utilitzen sense incialitzar.
Hi ha un tipus de variables "especials" anomenades atributs, molt diferent de les variables locals.  Recordeu que les variables locals "desapareixen" quan acaba la funci� que s'executa. Per contra, els atributs mantenen el seu valor mentre l'objecte on estan existeix.
La difer�ncia entre un atribut i una variable local �s el lloc on es declara:
```c#
    public sealed partial class MainPage : Page
    {
        int edat; // aix� �s un atribut

...

        private void btnBoto_Click(object sender, RoutedEventArgs e)
        {
            decimal preu; // aix� �s una variable local
			...

```
Els atributs si que es poden fer servir sense donar un valor inicial, doncs C# els inicialitza amb un valor per defecte segons el seu tipus de dades:

     tipus             | valor per defecte 
 --------------------|----------------------
 tipus num�rics  |            0             
 tipus _bool_ |            false             
 tipus _char_ |            car�cter 0         
 tipus _string_  |            null             
 tipus _object_  |            null             
 
### Col�lisi� de noms entre atributs i variables locals

 Es pot donar el cas de declarar una variable local i un atribut amb el mateix nom. Aix� COMPILA i �s dona per v�lid:
 
 ```c#
     class Persona
    {
        private string nom ="Paco";

        public Persona()
        {
            string nom = "Maria";

            string copia = nom; // Qu� val "nom" aqu�?

        }
    }
```
En la l�nia on hi ha el comentar, fem servir la variable _nom_, per� hi ha certa ambig�itat doncs no sabem si ens estem referint a l'atribut o a la variable loca.l

La regla �s senzilla, si no es diu el contrari , sempre  ens referim a la *variable local *
Si volem for�ar la refer�ncia a l'atribut cal usar el prefixe _this._
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

###  Limitaci� de l'�mbit usant { } adiccionals
Les variables sempre tenen un �mbit de vida limitat per les claus m�s internes on estan declarades. Aix� ens porta a que , de vegades, volem restringir  l'�mbit d'una variable a un fragment de codi, i aix� ho aconseguim for�ant l'us de brackets addicionals:
```c#

            { // inici de l'�mbit
                int v = 3; // la variable v "viu" dins dels brackets
                v++;

                //int v = 45;  // Aix� no compilaria, la variable existeix.
            } // final de l'ambit ( v desapareix )
            {
                int v = 4; // aqu� la puc tornar a declarar, doncs v  no existeix
                v--;
            }
```




## Treballant amb cadenes
Les cadenes s�n UNICODE ( per tant cada car�cter ocupa 16bits, i permeten representaci� universal de car�cters de la majoria de llenguatges exisitents ) 

 * Concatenaci�
Concatenem cadenes amb l'operador +
```c#
	string nom = "Josep " + "Maria";
	string nom_complet = nom + " L�pez";
 ```

 * Salt de l�nia
 Podem usar els literals "\n" o "\r\n"per representar el salt de l�nia:
 
 ```c#
	string dosLinies = "Primera L�nia\nSegona L�nia";
 ```
 
 �s millor utilitizar la seva representaci� gen�rica _Environment.NewLine_:
 
  ```c#
	string dosLinies = "Primera L�nia"+ Environment.NewLine + "Segona L�nia";
 ```
 * Autoreempla�ament
 Si prefixem la cadena amb un $, podem incrustar valors de variables dins de la cadena sense haver de fer concatenacions.
 
   ```c#
             string cadena = "M�n";
            string autoreempla� = $"Hola {cadena} ! ";
  ```
  
 * M�todes de conversi�
 Qualsevol tipus primitiu es pot convertir a cadena usant .toString()
 
 
 
 * M�todes de cerca, substituci� i trimming
 
     M�TODE             | FUNCI�
 --------------------|----------------------
 .Substring( posici�_inicial )  |    retorna la subcadena que comen�a a posici�_inicial(inclosa) fins al final            
.Substring( posici�_inicial, num_chars ) |       retorna la subcadena que comen�a a posici�_inicial(inclosa), prenent num_chars consecutius a partir de la posici� inicial (la posici� inicial compta)              
.Trim()     | Elimina espais en blanc a l'inici i final de la cadena
.Trim(char[] caracters) | Elimina els car�cters indicats al par�emtre del inici i final de la cadena
 .PadLeft(num_cars)  | omple la cadena per l'esquerra amb espais en blanc, fins assolir longitud num_cars
 .PadLeft(num_cars),  caracter_de_padding)| omple la cadena per l'esquerra amb caracter_de_padding, fins assolir longitud num_cars
 .Length  | longitud de la cadena
 cadena[i]   | acc�s directe al i�ssim car�cter de la cadena
 
 
### Conversions de tipus num�ric a cadena
Al convertir a cadena un n�mero, podem especificar el nombre de posicions senceres i decimals, aix� 
com la utilitzaci�  o no d'un separador de milers.
```c#
	double numeroDec = 2321.23;
	string num = numeroDec.ToString("#####.000"); //2321,230
 
	num = numeroDec.ToString("##,###.000"); //2.321,230
 
	// Utilitzant un indicador de cultura
	CultureInfo us = new CultureInfo("en-US");
	num = numeroDec.ToString("##,###.000", us); //2,321.230
 ```
### Conversions de tipus data a cadena
#### Declaraci� de data
Les dates es representen amb el tipus DateTime, que permet emmagatzemar la data i la hora ( hores, minuts i segons )
de forma conjunta.
Per declarar i inicialitzar una data ho podem fer de diverses maneres:
```c#
            
            DateTime ara = DateTime.Now; // ARA, incloent dia i hora

            DateTime avui = DateTime.Today; // ARA, incloent dia nom�s

            DateTime data = new DateTime(2017, 12, 31); // constructor expl�cit amb data

            DateTime dataIHora = new DateTime(2017, 12, 31, 22, 30, 59); // constructor expl�cit amb data i hora


```
#### Conversi� a cadena especificant el format
Podem usar cadenes de format per especificar quina �s la representaci� que volem assolir.
```c#

            string dataS = data.ToString("dd/MM/yyyy"); //  31/12/2017
            txtMissatge.Text += ">" + dataS + "\n";
            dataS = data.ToString("dd-MMM-yy hh:mm:ss"); // 31-dic.-17 12:00:00

            dataS = data.ToString("dddd, dd \\de MMMM \\de yyyy"); //domingo, 31 de diciembre de 2017

            dataS = data.ToString("hh:mm:ss"); //12:00:00

            CultureInfo fr = new CultureInfo("fr-FR");
            dataS = data.ToString("dddd, dd \\de MMMM \\de yyyy", fr); //dimanche, 31 de d�cembre de 2017
```
### Conversions de cadena a tipus num�rics (Parsing)

Podem treballar de forma "Segura" amb _[TIPUS_DE_DADES].TryParse()_ . 
Podem usar  Aquest m�tode intenta convertir la cadena a un n�mero TIPUS_DE_DADES, on TIPUS_DE_DADES pot ser Int32, Double, etc.
Si la conversi� falla, el m�tode retorna false, true altrament.
Fixeu-vos que el resultat es retorna per un par�metre de sortida ( marcat com a _out_ )
```c#


            double doubleParsed;

            bool exit = Double.TryParse("123,22", out doubleParsed); //doubleParsed = 123,22,  

            // Compte , per defecte usem els separadors decimals definits a l'idioma actual.
            exit = Double.TryParse("123.22", out  doubleParsed); //doubleParsed = 12322, exit = true
            

            // Podem especificar l'idioma i l'estil del n�mero
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowDecimalPoint;
            CultureInfo uk = new CultureInfo("en-UK");
            exit = Double.TryParse("123.22", style, uk, out doubleParsed); //doubleParsed = 123,22, exit = true

            // Si dona error la conversi� retorna false
            exit = Double.TryParse("123,xx", out doubleParsed); //doubleParsed = 0, exit = false
```
Tamb� podem anar "a l'aventura" usant _[TIPUS_DE_DADES].Parse()_, que funciona retornant directament el nombre
convertit, per� amb el problema de que si la conversi� no �s correcta, llan�a una excepci�.

```c#
            double dd = double.Parse("123,2"); // tot va b� dd= 123,2
            try
            {
                dd = double.Parse("xxxxx");
            }
            catch (Exception ex)
            {
                // Passem per aqu� !!!
                dd = 0;
            }
```

### Conversions de cadena a tipus data (Parsing)
Si coneixem el format de la data dins de la cadena que se'ns proporciona, �s senzill usar DateTime.ParseExact
per fer la conversi� a DateTime:
```c#

            string dataAParsejar = "31-12-2020 14h 12' 55''";
            DateTime dataParsejada = DateTime.ParseExact(dataAParsejar, "dd-MM-yyyy HH\\h mm\\' ss\\'\\'",
                                   System.Globalization.CultureInfo.InvariantCulture);

            dataS = dataParsejada.ToString("dddd, dd \\de MMMM \\de yyyy, a le\\s HH:mm:ss tt");
            txtMissatge.Text += ">" + dataS + "\n";
```


