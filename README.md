# Projectwerk .NET
## EggSplorer
**Groep 1**
- Leni Demeulemeester
- Jasper Dick
- Jarno Pot


## Alvorens het runnen van het programma
Run volgend script in dbo.Users:
```
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([ID], [FirstName], [LastName], [PhoneNumber], [Email], [Password], [IsAdmin], [IsApproved]) VALUES (0, N'Admin', N'EggSplorer', 0691413321, N'admin1@eggsplorer.com', N'1234', 1, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
```
Dit maakt onze stanaardgebruiker aan die we hardcoded meegeven bij het plaasten van bestellingen aangezien we authenticatie niet werkende hebben gekregen.
Alle bestellingen worden dus geregistreerd onder deze gebruiker.
Bij de pagina om gebruikers en admins te bewerken of verwijderen, zorgen we ervoor dat deze user niet getoond wordt op de pagina zodat deze ook niet kan verwijderd worden.

Run ook volgend commando in de Package Manager Console:
```
Update-Database
```


## Wat niet gelukt is
Authenticatie is bij ons niet gelukt.
Dit betekent dat iedereen naar ons admin gedeelte van de website kan navigeren.
We hebben wel een aparte layout voorzien voor de admins zodat dit toch lijkt alsof we een afgezonderd deel voor admins hebben.


## Punten waarmee rekening met gehouden moet worden
### Voor de gebruikers
1. Homepagina
	- `/Home`
	- Altijd leuk om een welkompagina te hebben met een kleine introductie

2. Info
	- `/Home/Info`
	- Info over ons bedrijf EggSplorer

3. Producten
	- `/Home/Producten`
	- Een lijst van alle producten met foto, naam, beschrijving, prijs
	- Dit is gewoon een overzicht, hier kan je niet bestellen

4. Bestellen
	- `/Bestel/Index`
	- Een pagina waar een geregistreerde gebruiker een bestelling kan plaatsen:
		- Een bestelling plaatsen lukt
		- Alle bestellingen worden wel geregistreerd onder onze standaardgebruiker met ID = 0 (wordt hardcoded meegegeven)
		- Dit gebeurt via een handige tabel die all producten oplijst en waar je gewoon het aantal meegeeft
		- Onderaan klik je dan op het winkelwandje 
		- Deze verwijst je door naar een bevestigingspagina waar je je order kan zien
		- Hier bevestig je effectief nog je bestelling door opnieuw op het winkelmandje te klikken
		- Als laatste kom je op de bedank pagina met enkele navigatieknoppen
	- Enkel geregistreerde gebruikers kunnen bestellingen plaatsen. 
		- Dit werkt enkel via onze hardcoded user met ID = 0

5. Registreren
	- `/Home/Registratie`
	- Deze werkt niet

6. Inloggen
	- `/Home/Login`
	- Deze werkt niet

### Voor de admins
1. Admin
	- `/Admin`
	- Home pagina voor de admins waar opgelijst staat wat een admin kan doen

2. Overzicht
	- `/Admin/bOverview`
	- Een samenvatting geven van alle bestellingen. De totale prijs voor de bestelling dient op deze pagina te worden weergegeven.
		- Dit werkt!
		- Dit zit in ons admin gedeelte

3. Bestellingen
	- `/Admin/bIndex`
	- Een pagina die de individuele bestellingen bijhoudt en een totaalprijs per persoon weergeeft.
		- Dit werkt!
		- Onze pagina toont een gedetailleerd overzicht per bestelling
			- ID, tijdstip, klantnaam, totaalprijs van de individuele bestelling en een overzicht van de details
			- Details bevatten het aantal per product, productnaam en prijs/stuk			
	- Een pagina waar een administrator kan inloggen en bestellingen aanpassen of verwijderen. 
		- De inlogpagina is niet operationeel, maar het verwijderen van bestellingen werkt wel
	- Bestellingen verwijderen moet in bulk kunnen.
		- In bulk verwijderen werkt door middel van een checkbox
	- De website dient vanaf 14u30 alle bestellingen te verwijderen zodat er de volgende dag opnieuw besteld kan worden. 
		- Dit is niet geïmplementeerd

6. Producten
	- `/Admin/pIndex`
	- Een pagina waar een administrator kan inloggen en prijzen van de producten aanpassen
		- Een inlogpagina is niet operationeel, aanpassen van de prijzen lukt wel
		- Deze pagina bevat een lijst van alle producten
		- Er is een optie om in bulk te verwijderen met een checkbox met de knop `Verwijderen` onderaan de pagina
			- Verwijderen zal je ook doorverwijzen naar een bevestigingspagina `/Admin/pDelete` waar je je actie moet bevestigen
		- Er is een knop `Maak aan` bovenaan de pagina die je doorverwijst naar de `/Admin/pCreate` waar je nieuwe producten kan toevoegen
			- Voorlopig hebben we soort van hardcoded de image source links in onze pagina verwerkt
			- Bij het toevoegen van een nieuw product, kan je geen image source meegeven
			- Om dit correct te laten verlopen, moet je na het aanmaken van een nieuw product het ID van het product opzoeken in dbo.Products
			- Dan voeg je de foto toe in `wwwroot\images` en geef je die de volgende naam op basis van het ID: `ID.jpg`
		- Er is een knop `Bewerken`	bij elke product om een product te bewerken, deze verwijst je door naar `/Admin/pEdit`
			- Zowel naam, beschrijving en prijs kan je aanpassen

7. Gebruikers
	- `/Admin/gIndex`
	- Een pagina waar een administrator een andere administrator kan maken of verwijderen
		- Dit werkt volledig zoals het hoort
		- Deze heeft dezelfde functionaliteiten als Producten: 
			- `Maak aan` -> `gCreate`
			- `Bewerken` -> `gEdit`
			- `Verwijderen`
	- Een pagina waar een administrator een gebruiker kan goedkeuren
		- Dit werkt, maar op dezelfde pagina waar je ook een gebruiker kan verwijderen
		- De gebruiker wordt goedgekeurd doormiddel van het aanvinken via een checkbox
		- Dus zowel admins als gebruikers worden bij ons in dezelfde table van de database opgeslagen, deze worden van elkaar onderscheiden door de properties `IsAdmin` en `IsApproved`


## Bonuspunten
1. Aangename styling van de website
	- Dit hebben we zoveel mogelijk gedaan
	- Leuke foto's, handige tabellen, eenvoudige formulieren
	- Less is more :-D

2. Bootstrap gebruiken voor de volledige website
	- Dit hebben we zoveel mogelijk gedaan
	- Margins, lettertype, headers, table, alignment, divider...

3. Creativiteit indien je zelf een ander soort website maakt
    - We hebben een website gemaakt waar je paaseieren kan bestellen ipv broodjes