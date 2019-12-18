# Bosbeheer
De bedoeling is om gegevens over bossen bij te houden, waarbij de bomen de bron vormen.
## Aanmaken Class Library
Maak een ClassLibrary aan met de naam Bossen.Lib
Verwijder Class1.cs
Voeg er een mapje Entities aan toe.
Maak een klasse Boom aan.
### Klasse Boom
#### Aanmaken
Maak de klasse public
Voeg de enum Boomsoorten toe in de namespace (dus boven de class) met de elementen naaldboom en loofboom
Geef Boom de volgende properties
- Id (Guid)
- Naam
- Hoogte in meter
- Soort (keuze uit de boomSoorten uit de enum)
Gebruik hiervoor auto properties.
#### Testen
- Maak een reference naar BosBeheer.Lib
- Voeg aan de code behind een using statement toe naar de namespace van Boom
- Maak een methode LaadMockData aan waarin je enkele instances van je klasse aanmaakt. Laat die bij het opstarten van de Gui uitvoeren.
- Zet een breakpoint na de uitvoering van deze methode en ga na wat er in de instances van de klasse Boom zit.
### Constructor
Maak een parameterloze constructor aan voor Boom
Voeg een tweede constructor toe die voor alle properties een waarde vraagt.
De standaardwaarde voor de boomsoort is loofboom, de standaardwaarde voor de id is null.
Als er een null-waarde doorgegeven wordt voor de id, wordt er in deze constructor een Guid aangemaakt.
Maak in LaadMockData ook een instance aan via deze constructor.
Test het resultaat.
### Boomsoorten opladen
Zorg ervoor dat in cmbBoomSoort en cmbBoomSoortTelling de boomsoorten uit de enum getoond worden.
### Tonen in de Gui
Voeg de instances die je aanmaakte in LaadMockData toe aan een lstBomen. Verplaats de call, zodat er zeker geen probleem kan optreden bij het opstarten.
Pas de klasse Boom aan, zodat de naam van de boom en de soort getoond wordt.
Toon de details van een geselecteerde boom in de controls. De geselecteerde boom wordt opgeslagen in de globale variabele huidigeBoom.
### Klasse Bos
Maak de klasse Bos aan onder de entities.
De klasse Bos bevat een List<Boom> en een naam.
Bij de instantiëring van een bos wordt de methode LaadMockData gecalled. Verplaats deze methode naar Bos.
Voorzie de CRUD-operations in deze klasse en pas ze toe vanuit de GUI.
### Boom verfijnen
Zorg ervoor dat een boom met een lengte kleiner dan 0 meter of hoger dan 70 meter niet aangemaakt kan worden.
Geef een passende foutmelding als aan deze voorwaarde niet voldaan wordt en toon ze in de GUI.
### Meerdere bossen
Schrijf in de code behind een methode MaakBossen die enkele bossen aanmaakt, met daarin telkens enkele bomen. Gebruik de object initializer voor de aanmaak van de bossen.









