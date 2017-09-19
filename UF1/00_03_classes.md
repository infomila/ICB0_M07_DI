[ ... back  ](../README.md)

# Breu introducci� a les classes

## Declaraci� d'una classe
Una primera aproximaci� a una classe �s veure-la com la definici� d'una tupla de dades, a la que afegim funcions "especials" anomenades constructors.
Els constructors tenen el mateix nom que la classe, i permeten donar valors inicials a la tupla.

```c#
    public class Persona
    {
        public int mNumeroNIF;				//Aix� �s un atribut de la classe
        public char mLletraNIF;				//Aix� �s un atribut de la classe
        public DateTime mDataNaixement;		//Aix� �s un atribut de la classe
        public string mNom;					//Aix� �s un atribut de la classe
		

        public Persona()					// Constructor sense par�metres
        {
        }
		// Constructor amb par�metres
        public Persona(string pNom, int pNumeroNIF, char pLletraNIF, DateTime pDataNaix)
        {
            mNom = pNom;
            mNumeroNIF = pNumeroNIF;
            mLletraNIF = pLletraNIF;
            mNom = pNom;
            mDataNaixement = pDataNaix;
        }

    }
 ```
 ## Creaci� d'un objecte i utilitzaci� dels atributs p�blics
 
 Crear un objecte �s semblant a definir una variable de tipus tupla. Cal utilitzar un constructor per 
 "fer lloc" per les dades que volem emmagatzemar.
 
 ```c#

		Persona p0 = new Persona(); // Creem un objecte usant el constructor buit
		Persona p1 = new Persona("Paco", 12345678,'C', DateTime.Now.AddYears(-10)); // Creem un objecte usant el constructor amb par�metres
		p1.mNom = "Joan"; // Acc�s d'escriptura
		string nom = p1.mNom; // Acc�s de lectura
		Persona p2 = new Persona("Maria", 11111111,'H', new DateTime(1990,12,31)); // Creem un altre objecte 

 ```
 
 ## Propietats
 
 L'acc�s als atributs �s perill�s, doncs no permet cap control de les dades. Per exemple, podem assignar un nom buit, donar qualsevol valor a la lletra del NIF, posar dates de naixment futures.....
 
 Per tenir un control detallat de l'acc�s a les dades, els atributs _s'encapsulen_ en *Propietats*.
 Per cada atribut:
 * el fem private
 * creem una propietat associada del mateix tipus, amb el nom lleugerament diferent ( generalment inicial maj�scula )
 * a la propietat tenim un get i un set ( opcionals ambd�s ) on podem afegir l�gica de control.
 
  ```c#
         // Atributs PRIVATS !!!!
        private char mLletraNIF;
        private DateTime mDataNaixement;
        private string mNom;
        private int mNumeroNIF;

        // ----------------- Propietats que desen el seu valor en els
        // ----------------- seus atributs respectius
        public int NumeroNIF
        {
            get { return mNumeroNIF; }
            set { mNumeroNIF = value; }
        }
        public char LletraNIF
        {
            get { return mLletraNIF; }
        }
        public string Nom
        {
            get { return mNom; }
            set { if(value==null || value.Trim().Length < 2)
                {
                    throw new Exception("nom invalid");
                }
                mNom = value;
            }
        }
        public DateTime DataNaixement
        {
            get { return mDataNaixement; }
            set
            {
                if (value == null || mDataNaixement > DateTime.Now)
                {
                    throw new Exception("data invalida");
                }
                mDataNaixement = value;
            }
        }
 ```
 
 Un cop declarades les propietats, el seu �s �s id�ntic a la dels atributs, per� cal tenir en compte que quan assignem valors i llegim valors estem passant 
 pel codi del m�tode _set()_ i _get()_ respectivament.
 Com es pot veure a l'exemple seg�ent, quan intentem assignar una 'x' a la propietat _Nom_, el programa llan�a una excepci�
 donat que el codi de validaci� exigeix que tingui com a m�nim 2 car�cters.
 
  ```c#

		Persona p0 = new Persona(); // Creem un objecte usant el constructor buit
		Persona p1 = new Persona("Paco", 12345678,'C', DateTime.Now.AddYears(-10)); // Creem un objecte usant el constructor amb par�metres
		p1.Nom = "Joan"; // Acc�s d'escriptura
		string nom = p1.Nom; // Acc�s de lectura

		p1.Nom = "x"; // <----- KABOOOM !!! 
 ```