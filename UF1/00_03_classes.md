[ ... back  ](../README.md)

# Breu introducció a les classes

## Declaració d'una classe
Una primera aproximació a una classe és veure-la com la definició d'una tupla de dades, a la que afegim funcions "especials" anomenades constructors.
Els constructors tenen el mateix nom que la classe, i permeten donar valors inicials a la tupla.

```c#
    public class Persona
    {
        public int mNumeroNIF;				//Això és un atribut de la classe
        public char mLletraNIF;				//Això és un atribut de la classe
        public DateTime mDataNaixement;		//Això és un atribut de la classe
        public string mNom;					//Això és un atribut de la classe
		

        public Persona()					// Constructor sense paràmetres
        {
        }
		// Constructor amb paràmetres
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
 ## Creació d'un objecte i utilització dels atributs públics
 
 Crear un objecte és semblant a definir una variable de tipus tupla. Cal utilitzar un constructor per 
 "fer lloc" per les dades que volem emmagatzemar.
 
 ```c#

		Persona p0 = new Persona(); // Creem un objecte usant el constructor buit
		Persona p1 = new Persona("Paco", 12345678,'C', DateTime.Now.AddYears(-10)); // Creem un objecte usant el constructor amb paràmetres
		p1.mNom = "Joan"; // Accés d'escriptura
		string nom = p1.mNom; // Accés de lectura
		Persona p2 = new Persona("Maria", 11111111,'H', new DateTime(1990,12,31)); // Creem un altre objecte 

 ```
 
 ## Propietats
 
 L'accés als atributs és perillòs, doncs no permet cap control de les dades. Per exemple, podem assignar un nom buit, donar qualsevol valor a la lletra del NIF, posar dates de naixment futures.....
 
 Per tenir un control detallat de l'accés a les dades, els atributs _s'encapsulen_ en *Propietats*.
 Per cada atribut:
 * el fem private
 * creem una propietat associada del mateix tipus, amb el nom lleugerament diferent ( generalment inicial majúscula )
 * a la propietat tenim un get i un set ( opcionals ambdós ) on podem afegir lògica de control.
 
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
 
 Un cop declarades les propietats, el seu ús és idèntic a la dels atributs, però cal tenir en compte que quan assignem valors i llegim valors estem passant 
 pel codi del métode _set()_ i _get()_ respectivament.
 Com es pot veure a l'exemple següent, quan intentem assignar una 'x' a la propietat _Nom_, el programa llança una excepció
 donat que el codi de validació exigeix que tingui com a mínim 2 caràcters.
 
  ```c#

		Persona p0 = new Persona(); // Creem un objecte usant el constructor buit
		Persona p1 = new Persona("Paco", 12345678,'C', DateTime.Now.AddYears(-10)); // Creem un objecte usant el constructor amb paràmetres
		p1.Nom = "Joan"; // Accés d'escriptura
		string nom = p1.Nom; // Accés de lectura

		p1.Nom = "x"; // <----- KABOOOM !!! 
 ```