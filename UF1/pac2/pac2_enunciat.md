[ ... back  ](../README.md)

# Pr�ctica "cycleRacePRO"

__OBJECTIU:__ En aquesta pr�ctica construirem una petita aplicaci� que permetr� gestionar una cursa per etapes. En aquesta primera versi� ens ocuparem de l'eina que permet crear etapes i editar-ne el seu perfil:

## Model de dades i projecte base
L'aplicaci� seguir� el seg�ent model de dades, que es subministra ja preimplementat en 
el projecte que podeu descarregar [aqui](cycleRacerPRO.zip).
 ![Class Diagram](screenshots/class_diagram.png)
## Definici� de la interf�cie d'usuari
### Splash screen
Engegarem una pantalla de presentaci� "splash screen" abans de carregar la primera pantalla:

![Men� desplegat](screenshots/SplashScreen.png "Captura de pantalla")
### Editor d'etapes 
L'editor d'etapes �s una gesti� ( alta, baixa i modificaci� ) d'etapes d'una cursa ciclista.
L'Etapa �s una entitat complexa i s'edita en dues parts:
- dades b�siques
- perfil de l'etapa ( llista de punts kilom�trics rellevants)

#### Estructura global

- A l'esquerra sempre es mostrar� la llista d'etapes existents en un _ListView_.
- Cada element dins del _ListView_ ser� un control personalitzat, i es connectar� a un objecte _Etapa_.
- Usarem el patr� ["Tabs and Pivots"](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/tabs-pivot), per permetre
seleccionar entre l'edici� de les dades b�siques de l'etapa i el seu perfil.
    - **IMPORTANT:** Cada _Tab_ contindr� un _Frame_ on es carregar� una p�gina espec�fica, _Etapa_DadesBasiques.xaml_ i _Etapa_Perfils.xaml__
- Les barres d'eines que podem veure a les dues pantalles es faran usant el patr� ["Command Bar"](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/app-bars)

#### a) Dades b�siques
![Men� plegat](screenshots/StageEditor.png "Captura de pantalla")
Alguns comentaris:
- Tots els camps s�n obligatoris. El nom he de tenir 3 car�cters com a m�nim.
- si les dades no s�n correctes, es marca el control amb un fons vermell suau, i la icona de desar queda deshabilitada.
- El desplegable mostra text i imatge ( us caldr� modificar el _DataTemplate__ del _ComboBox__)
- Quan seleccioneu _Pick Image_ es mostrar� un _File Picker_ per tal que l'usuari pugui seleccionar una imatge.
Trobareu m�s a sota a l'annex el codi per a fer aquesta feina.

#### b) Perfils
![Men� plegat](screenshots/ProfileEditor.png "Captura de pantalla")

#### c) Visi� de perfil 
Quan premem la icona de l'ull a l'edici� del perfil, es mostra en un 
_PopUp_ (vegeu [aqu�](https://code.msdn.microsoft.com/windowsapps/Popup-Control-in-universel-700d46d4) per m�s detalls ) un gr�fic de l'etapa:
![Men� plegat](screenshots/ProfileEditor_View.png "Captura de pantalla")
Aquest gr�fic �s integrament un control personalitzat que cal implementar.


## Annex: code snippets:
### FilePicker
```c#
        /// Obrir un selector d'arxius, triar un arxiu i copiar-lo a la carpeta ApplicationData del
        /// programa. Crear una imatge en mem�ria a partir de l'arxiu.
        private async void btnFile1_Click(object sender, RoutedEventArgs e)
        {
                FileOpenPicker fp = new FileOpenPicker();
                fp.FileTypeFilter.Add(".jpg");
                fp.FileTypeFilter.Add(".png");

                StorageFile sf = await fp.PickSingleFileAsync();
                // Cerca la carpeta de dades de l'aplicaci�, dins de ApplicationData
                var folder = ApplicationData.Current.LocalFolder;
                // Dins de la carpeta de dades, creem una nova carpeta "icons"
                var iconsFolder = await folder.CreateFolderAsync("icons", CreationCollisionOption.OpenIfExists);
                // Creem un nom usant la data i hora, de forma que no poguem repetir noms.
                string name = (DateTime.Now).ToString("yyyyMMddhhmmss") + "_" + sf.Name;
                // Copiar l'arxiu triat a la carpeta indicada, usant el nom que hem muntat
                StorageFile copiedFile = await sf.CopyAsync(iconsFolder, name);
                // Crear una imatge en mem�ria (BitmapImage) a partir de l'arxiu copiat a ApplicationData
                BitmapImage tmpBitmap = new BitmapImage(new Uri(copiedFile.Path));
			// ..... YOUR CODE HERE ...........
        }
		
	
		
```		