# Eggsplorer

Home:
1: login
2: registratie
3: Producten
	(
	a: Details
	b: sort
	c: search
	)
4: Info
5: admindashboard
	a: bestellingen overview
		I: edit
		II: delete

	b: Goedkeuring
		I: create
		II: delete
		III: edit

	c: producten
		I: create
		II: delete
		III: edit

6: Bestelpagina
	a:overview producten
	b: winkelmandje
	c: Thankyou

!!!Bij aanvang moet er eerst een account worden aangemaakt via de admin pagina "Gebruikers" dan pas kunnen er bestellingen geplaatst worden!!!

Punten waarmee rekening mee gehouden moet worden:
Een pagina waar een geregistreerde gebruiker een bestelling kan plaatsen:
	- Een bestelling kan enkel geplaatst worden indien er een gebruikersaccount is aangemaakt via de adminpagina "Gebruikers"

* Een samenvatting gegeven van alle bestellingen. De totale prijs voor de bestelling dient op deze pagina te worden weergegeven.
	- Dit werkt!

* Een pagina die de individuele bestellingen bijhoudt en een totaalprijs per persoon weergeeft.
	- Dit werkt!

* Een pagina waar een administrator kan inloggen en bestellingen aanpassen of verwijderen. 
	- De inlogpagina is niet operationeel, maar het aanpassen en verwijderen van bestellingen werkt wel

* Bestellingen verwijderen moet in bulk kunnen.
	- Dit werkt doormiddel van een checkbox

* Een pagina waar een administrator kan inloggen en prijzen van de producten aanpassen
	- Een inlogpagina is niet operationeel, aanpassen van de prijzen lukt wel

* Een pagina waar een administrator een andere administrator kan maken of verwijderen
	 - Dit werkt volledig zoals het hoort

* Een pagina waar een administrator een gebruiker kan goedkeuren
	- Dit werkt, maar op dezelfde pagina waar je ook een gebruiker kan verwijderen (gIndex)
	- De gebruiker wordt goedgekeurd doormiddel van het aanvinken via een checkbox

* De website dient vanaf 14u30 alle bestellingen te verwijderen zodat er de volgende dag opnieuw besteld kan worden. 
	-
* Enkel geregistreerde gebruikers kunnen bestellingen plaatsen. 
	- Dit werkt!
* Wanneer een gebruiker zich registreert dient deze registratie eerst goedgekeurd te worden door de administrator.
	- De gebruiker wordt aangemaakt via de admincontroller (gCreate) en wordt goedgekeurd doormiddel van het aanvinken via een checkbox
	- Er zit geen beveiliging op, dus iedereen kan een gebruiker aanmaken

Bonuspunten:

* Aangename styling van de website
	- Dit hebben we zoveel mogelijk gedaan

* Bootstrap gebruiken voor de volledige website
	- Dit hebben we zoveel mogelijk gedaan

* Creativiteit indien je zelf een ander soort website maakt
    - We hebben een website gemaakt waar je eieren kan bestellen