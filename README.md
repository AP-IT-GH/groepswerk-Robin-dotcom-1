# VR Project

VR Golf tegen een AI

Met ons team hebben we een idee om een golf gerelateerde game te ontwikkelen. De bedoeling is iemand te laten spelen tegen een AI gestuurde tegenstander. Voor deze AI ontwikkelen we een brein met behulp van MLAgents in Unity. Het uiteindelijke doel is om een uitdagende game te creëren waarbij we een goed getrainde AI implementeren.

Doelstellingen:

1. De AI kan de bal potten in een rechte lijn zonder rekening te houden met physics (leer de kracht kennen).
2. De AI kan de bal potten en nu kan hij ook draaien, er gaan hoeken/bochten aan de map toegevoegd worden.
3. Draaien rond zijn eigen as

Omgevingen:

De eerste omgeving waar we in gaan trainen gaat een simpele golfbaan zijn. Hier zal de agent de bal in een rechte lijn moeten schieten. 
Het zal zelf moeten bepalen moet hoeveel kracht hij zal schieten om een hole-in-one te halen.

De 2e omgeving zal een golfbaan zijn waar bochten en heuvels in voorkomen. Hier zal de AI nog altijd de hole weten zijn maar zal hij niet meer in een rechte lijn kunnen schieten en zich moeten draaien.
De 3e omgeving zal zoals de 2e omgeving zijn maar deze zal dan ook obstakels bevatten om de AI te leren obstakels te ontwijken.

Acties:

De AI moet zal met verschillende zaken rekening houden. Hij kan de kracht bepalen waarmee hij op het balletje slaat. Ook kan hij de richting van het balletje veranderen om zo dichter bij de hole te komen. Als laatste kan hij ook het startpunt van het balletje bepalen bij het begin van de game. Hiervoor heeft hij keuze op een horizontale lijn in het startgebied. 

Observations:

Locatie van de hole wordt bijgehouden en door ook gebruik te maken van de locatie van de bal kan het hiermee de afstand en de richting berekenen.
We gaan de AI ook ogen geven om eventuele obstakels te detecteren en hierop te reageren. 
Deze ogen zullen ook helpen met hoeken te zien op de golfbanen.

## VR

Voor het VR aspect van het project hebben we het vrij simpel gehouden.
We maakten gebruik van de built-in tools van unity om de vr op te zetten, we maakten eerst een VR Rig object aan per level.

Aan dit VR Rig object gaven we 2 controllers (voor links en rechts) en een camera dat het zicht van de speler zal zijn.
Dan hebben we, om de speler rond te laten bewegen, een teleporteer systeem toegevoegd. Dit zit nogmaals allemaal ingebouwd in Unity.
We hebben een teleportation provider component toegevoegd aan onze VR Rig, daarna hebben we aan elk oppervlak waar de speler op moet kunnen staat een teleportation area component toegevoegd. 

Om de teleportation area te gebruiken moesten we ook nog een box collider toevoegen omdat deze niet werkt met een meshcollider. Daarna zetten we de boxcollider op isTrigger zodat deze niet de collision veranderd van de golfbaan.
Vervolgens moeten we de speler een manier geven om te teleporteren, hiervoor gaven we de VR Rig nog 2 objecten: Lefthandray en Righthandray. Dit zijn 2 extra controllers maar deze hebben ook nog eens een interaction ray component, dit zorgt er voor dat de speler met objecten in de wereld kan interacten zoals rondteleporteren, de stick pakken en de bal pakken.

Voor de physics hebben we gebruik gemaakt van de built-in physics van unity zelf waarvoor niets van extra programmeren nodig was. 
Je voegt een aan de bal en de stick beide een rigidbody toe en unity doet de rest.

## Level design