[ ... back  ](../../README.md)

# Pr�ctica "Map Editor"

__OBJECTIU:__ Es desitja construir una aplicaci� per editar/mantenir els mapes d'un joc d'aventures en 2D. El programa ens ha de permetre dos grans funcionalitats:
 * Gestionar items que es poden col�locar en un mapa ( crear-los/modificar-los i esborrar-los ). Cada Item t� un nom, una descripci� i una fotografia.
 * Posicionar els �tems en el mapa. Cada �tem pot apar�ixer MULTIPLES vegades al mapa, amb diferents valors de quantitat (amount) , posici� i visibilitat.

 
## Seccions


### Men�
Per fer el men�, usarem un SplitView. Aquest tipus d'estructura t� un panell que cont� el men�, i que es plega al fer click sobre un bot�. Aquest tipus de men� que es solen anomenar _Hamburguer menu_

![Men� desplegat](resources/Screenshot_2.png "Captura de pantalla")
![Men� plegat](resources/Screenshot_3.png "Captura de pantalla")

L'SplitView tindr� com a contingut principal un _Frame_ on anirem carregant les p�gines. 
Podeu trobar molts tutorials per muntar aquest tipus de men� que es solen anomenar , podeu provar [aquest](https://maximelabelle.wordpress.com/2016/02/02/building-a-hamburger-menu-for-your-universal-app/)

### P�gina �tems
Podem donar d'alta, esborrar o modificar els camps d'un �tem. Vegeu captures anteriors per saber quin ha de ser l'aspecte de la p�gina.
Tots els camps s�n obligatoris. Quan el camp sigui erroni es deshabilitaran el boton de desar i es mostrar� el camp erroni amb un suau color vermell de fons.
El nom t� un m�nim de 4 lletres, mentre que la descripci� en requereix 10 com a m�nim. (eviteu desar els espais inicials o finals )

En qualsevol moment, es pot seleccionar una imatge, a partir d'un bot�  que ens mostrar� un selector d'arxius.
![Canvi de la icona d'un �tem](resources/Screenshot_4.png "Captura de pantalla")

_ATENCI�_ : no poderem esborrar �tems que estan en �s en el mapa. ( es mostrar� una finestra de di�leg d'error )

### P�gina Edici� de Mapa
Un �tem pot ser col�locat m�ltiples vegades en el mapa. �s el que coneixerem com a 'MapItem'. Els MapItems estan associats a un tipus de �tem definit a la p�gina anterior, i tenen unes coordenades sobre la graella del mapa, una quantitat i un atribut boole� de visibilitat.
La pantalla ens mostra els �tems del mapa en una llista a l'esquerra i tamb� situats sobre el mapa. 
Les funcionalitats esperades s�n:
 - capacitat d'afegir nous �tems.
Seleccionar els items. L'�tem seleccionat es mostrar� ressaltat en el mapa amb un requadre groc m�s gruixut.
Els �tems s�n seleccionables mitjan�ant la llista, o prement directament a sobre d'ells en el mapa.
![Item no seleccionat](resources/Screenshot_5.png "Captura de pantalla")
![Item Seleccionat](resources/Screenshot_6.png "Captura de pantalla")
 - Moure i esborrar l'�tem seleccionat. Sobre l'�tem seleccionat es poden fer operacions de despla�ament ( botons de cursor ) i es poden esborrar ( bot� esborrar )

 - Finalment, l'edici� del mapa permet seleccionar qualsevol imatge, aix� com definir la mida de la graella que volem utilitzar en pixels d'al�ada i d'amplada.
![Captura de pantalla](resources/Screenshot_1.png "Captura de pantalla")


## Recursos
Arxius proporcionats:
 * [Assets: Mapes i icones d'exemple](resources/resources.jar)
 * [Classes del model ](resources/model.zip)

 
## Codi proporcionat 


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