[ ... back  ](../README.md)

# Pràctica 1

## Introducció
Volem fer una petita aplicació que ens ajudi a organitzar una lliga d'escacs. La interficie gràfica serà senzilla, i ens enfocarem sobretot a treballar les estructures de dades i la validació.

![](2020-09-30-07-25-22.png)


## Gestió dels clubs
Els clubs són les entitats que s'enfronten a les lligues.
Per representar-los usarem la classe *Club*, que conté només un atribut *nom*.
Les operacions disponibles són:
 - alta d'un nou club
 - baixa d'un club existent


#### Requeriments de la Interfície gràfica per gestionar clubs

   - *ListBox* on es mostra el nom dels clubs.
   - *TextBox* + *Button* "Alta". L'usuari escriurà el nom del nou club al *TextBox*. El botó "Alta" està desactivat si al *TextBox* no hi ha un mínim de 3 caràcters o si conté un nom ja existent a la llista (no admetem clubs amb noms repetits).
   - *Button* "Baixa". El botó "Baixa" està desactivat si no hi ha res seleccionat a la llista de clubs. S'activa quan es selecciona quelcom. Quan fem click esborra el club seleccionat.


## Gestió dels jugadors
La classe *Jugador* conté els següents atributs:
* NIF 
* nom i cognoms 
* Número de Ranking ELO (sencer entre 0 i 3000)

Un club ha de tenir 5 jugadors registrats.
#### Requeriments d'interfície gràfica
La informació dels jugadors es mostra en el moment que es selecciona un club (veure apartat anterior) dins d'un *ListBox*. La llista conté una línia per cada jugador, en format 
> [NIF] - [nom] ([ELO])

P.ex.: 
>  11111111H - Paco León (1574)

Tindrem l'opció d'eliminar un jugador mitjaçant un botó "Baixa". El botó **"Baixa"** està desactivat si no hi ha cap jugador seleccionat al *ListBox*.

Per donar d'alta nous jugadors s'habilitaran tres *TextBox*s : NIF, nom, ranking ELO. Cal que fins que les tres dades no estiguin ben escrites, el botó **"Afegir"** no s'activi. Tampoc s'ha de permetre registrar més de 5 jugadors. Les validacions a fer són:
- NIF correcte (format i lletra vàlida i coherent amb el número)
- nom (mínim dos paraules, on cada paraula té un mínim de 3 lletres)
- ranking ELO: sencer entre 0 i 3000


## Creació d'una lliga
La interfície d'usuari ens oferirà un botó per crear el calendari de lliga a partir de la informació proporciona i d'una data d'inici que l'usuari podrà seleccionar en un *DatePicker*. El botó funcionarà exclusivament quan hi hagi un nombre parell de clubs (com a mínim 4), i cada club hagi registrats 5 jugadors, altrament donarà un missatge d'error explicant les condicions de creació de lliga.    

Una lliga consisteix en un conjunt de jornades, tantes com siguin necessaries per a que tots els clubs juguin contra tots els altres (com a visitant i com a local, dues voltes per tant). El rol de visitant i local de cada equip s'ha d'anar alternant a cada jornada. Les jornades es programen sempre en dissabte, començant pel primer dissabte que hi hagi a partir de la data seleccionada en el *DatePicker*.

Per organitzar cada jornada s'emparellen els clubs, i es decideix quins jugadors d'un club juguen partida amb quins jugadors de l'altre per ordre de ranking ELO (els millors d'un equip juguen amb els millors de l'altre). A les partides s'alterna quin club juga amb les blanques. El millor jugador local sempre comença amb blanques, per tant el segon jugador local ho farà amb negres i així anar seguint.            

Volem que la lliga es representi mitjançant les següents estructures de dades:
```c#
    Dictionary< dies , List<EnfrontamentClub> >
```
On definim un *EnfrontamentClub* com:
``` c#
        Club clubDeCasa;
        Club clubVisitant;
        Llist<Partida>;
```        

i una *Partida* és:

``` c#        
        Jugador jugadorA_blanques; 
        Jugador jugadorB_negres;
```


####  Requeriments d'Interfície:
L'organització resultant es mostrarà a la interfície mitjançant tres *ListBox*:
1. *ListBox* 1 : Mostra la llista de dies del torneig, en format:
> dd/mm/yyyy
2. *ListBox* 2 : quan triem un dia de torneig al *ListBox* anterior, mostra llista d'emparellaments per aquell dia, en format: 
>ClubA - ClubB
3. *ListBox* 3 : quan seleccionem un emparellament a la llista anterior, es mostra aquí la llista de partides en format:
>  JugadorA(ELO)[B] vs JugadorB(ELO) 
On la primera columna es correspon al *ClubA* i la segona al *ClubB*, i la marca [B] indica qui juga amb les blanques. 
 


