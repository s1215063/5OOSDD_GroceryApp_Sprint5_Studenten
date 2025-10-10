# GroceryApp sprint5

Gitflow Workflow

Voor dit project word er gebruik gemaakt van de Gitflow methode om de ontwikkeling gestructureerd en overzichtelijk te houden.

Binnen Gitflow worden de volgende branches gebruikt:


## main
Bevat de stabiele, productierijpe code. Alles in deze branch is getest en klaar om in productie te gebruiken.


## develop
De integratiebranch waarin alle nieuwe features samengevoegd worden. Hier staat altijd de laatste werkende ontwikkelversie.


## feature/…
Voor iedere nieuwe user case of functionaliteit wordt een aparte feature branch aangemaakt.

- feature/UC8 → voor de uitwerking van Use Case 8.
- feature/UC9 → voor de uitwerking van Use Case 9.


Zodra een feature klaar is, wordt deze terug samengevoegd in de develop branch.


## release/…
Wanneer een nieuwe versie bijna klaar is, wordt er een release branch aangemaakt vanuit develop. Hierin worden enkel nog documentatie-updates gedaan, zodat de release stabiel wordt.


## hotfix/…
 Voor dringende fouten in de main branch die snel opgelost moeten worden, zonder te wachten op een nieuwe release.




## UC's
UC12 Productcategoriën toevoegen
- Producten kunnen getoond worden op basis van categorie
- Producten kunnen toegevoegd worden aan een categorie doormiddel van zoekfunctie

UC14 Toevoegen prijzen
- Producten bevatten nu een verkoop prijs
 
UC15 Toevoegen THT datum aan product 
- Producten bevatten nu een THT datum
