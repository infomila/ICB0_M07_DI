[ ... back  ](../../README.md)

# Pràctica 1: "Le petit Chef"

## Introducció
Volem fer una petita aplicació que ens ajudi a organitzar les compres d'un restaurant. A tal efecte necessitarem definr els escandalls dels plats. Ho farem a partir de la interfície descrita en els següents apartats:

![](xef.jpg)


## Gestió dels ingredients
Un ingredient representa quelcom que podem posar al plat.
Per representar-los usarem la classe *Ingredient*, que conté només un atribut *nom*, i un atribut *unitat* ( de tipus enumeració, amb els valors UDS, ML, G ).
La classe *Ingredient*, per tant, seria:
```c#
        String Nom; // (mínim 4 lletres)
        Unitat unitat;
```
L'enumeració *Unitat* es defineix de la següent forma:

```c#
    enum Unitat
    {
        UDS,
        G,
        ML
    }
```

Les operacions disponibles són:
 - alta de l'ingredient: 
 - eliminar ingredient.
 

#### Requeriments de la Interfície gràfica per gestionar ingredients

   - *ListBox* on es mostra el nom dels ingredients.
   - *TextBox* + *Button* "Alta Ing.". L'usuari escriurà el nom del nou ingredient al *TextBox*. El botó "Alta" està desactivat si al *TextBox* hi ha menys de 4 caràcters o si conté un nom ja existent a la llista (no admetem ingredients amb noms repetits).
   - *ComboBox* d'unitat de mesura. Mostrarà tres valors : "uds", "ml", "g".  El botó "Alta" està desactivat si no hi ha cap unitat seleccionada.
   - Un cop feta l'alta de l'ingredient, el *TextBox* de nom es buida, i el desplegable d'unitats es deixa sense cap opció seleccionada.
   - *Button* "Baixa". El botó "Baixa Ing." està desactivat si no hi ha res seleccionat a la llista. S'activa quan es selecciona quelcom. Quan fem click esborra l'ingredient seleccionat.
   **COMPTE**: No hem de poder esborrar un ingredient que s'està fent servir a un plat !


## Gestió dels plats

A banda dels ingredients, podrem crear i esborrar plats de la nostra carta.


La classe *Plat* conté els següents atributs:
```c#
public class Plat {
        String Codi; // (en format AA0000, dos lletres i 4 xifres)
        String Nom; // (mínim 5 lletres)
        String Descripcio; // (opcional)
        Dictionary<Ingredient,Int32> ingredients;
        ....
}
```

Primer es crea el plat indicant només el codi, nom i descripció, sense ingredients. Posteriorment es van afegit ingredients. 

 
#### Requeriments d'interfície gràfica
La llista de plats es mostra dins d'un *ListBox*. La llista conté una línia per cada plat, en format 
> [Codi] - [nom] 

P.ex.: 
>  GR6666 - Truita de patates

El botó **"Nou Plat"**  permetrà crear plats a partir de la informació que es recollirà en 3 *TextBox*, un pel codi, un altre pel nom i per la descripció. El *TextBox* de descripció ha de ser multilínia. El botó **"Nou Plat"** només estarà actiu si els camps compleixen les validacions.

Tindrem l'opció d'eliminar un plat mitjaçant un botó "Baixa Plat". El botó **"Baixa Plat"** està desactivat si no hi ha cap plat seleccionat al *ListBox*.

Al costat del *ListBox* de plats tindrem un altre *ListBox* on es mostraran els ingredients del plat seleccionat al *ListBox* de plats. Si no hi ha plats seleccionats, la llista estarà buida. Per cada ingredient es mostra una línia en format 
> [nom ingredient] [quantitat] [unitat]

P.ex.:
> Patata 45000 g


Per afegir ingredients a un plat usarem:
* un *ComboBox* que contindrà la llista dels noms dels ingredients.
* un *TextBox* on es podrà escriure un número (sencer). 
* un *Button* per afegir l'ingredient al plat seleccionat. El botó només estarà actiu si hi ha un plat seleccionat, un ingredient selecciont al *ComboBox* i una quantitat vàlida. **No permetem** repetir un mateix ingredient dos cops en el mateix plat. Tan bon punt fem click per afegir l'ingredient, apareixerà al *ListBox* d'ingredients.



## Creació d'un informe de compres
Finalment, l'aplicació tindrà una *TextBlock* on es mostrarà una comanda de compres a partir dels escandalls introduïts.
El primer pas és que l'usuari ens indiqui el nombre de comandes que espera en mitja per cada plat. A tal efecte afegirem un *Slider* que permet triar un valor sencer entre 0 i 300. Poseu un *TextBox* només de lectura al costat de l'*Slider* sincronitzat amb l'*Slider* que mostri el valor actual.

Si l'usuari tria un 30, voldrà dir que s'espera fer 30 serveis de cadascun dels plat a la llista. (30 del primer, 30 del segon, etc. )
Quan es premi el *Button* "Informe de Compres", es mostrarà en el *TextBlock* la llista de la compra que és necessària per preparar tots aquests plats. El format esperat és:
> 1.- Carn de vedella:    23.000 g  
  2.- Daurada:            30    uds.  
  3.- Salsa de soja:      450    ml  

*IMPORTANT*: En aquesta llista no hi ha d'haver repeticions. És possible que varis plats comparteixin alguns ingredients, i per tant cal sumar-ne les quantitats i que l'ingredient només aparegui un cop.

Podeu usar un *RichTextBlock* per donar color i estil al l'informe, més info [aquí](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.RichTextBlock?redirectedfrom=MSDN&view=winrt-20348).
         

