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

De 3e omgeving zal zoals de 2e omgeving zijn maar deze zal dan ook obstakels bevatten om de AI te leren obstakels te ontwijken. Deze omgeving is de grootste challenge. 

Acties:

De AI zal met verschillende zaken rekening moeten houden. Hij kan de kracht bepalen waarmee hij op het balletje slaat. Ook kan hij de richting van het balletje veranderen om zo dichter bij de hole te komen. Als laatste kan hij ook het startpunt van het balletje bepalen bij het begin van de game. Hiervoor heeft hij keuze op een horizontale lijn in het startgebied. 

Observations:

Locatie van de hole wordt bijgehouden en door ook gebruik te maken van de locatie van de bal kan de agent hiermee de afstand en de richting berekenen.
We gaan de AI ook ogen geven om eventuele obstakels te detecteren en hierop te reageren. 
Deze ogen zullen ook helpen met hoeken te zien op de golfbanen.


# Documentatie VR Golf (Tutorial)

## Inhoudstabel
1. Voorbereidingen project
2. Maken van testing area en AI agent
3. Maken van maps
4. SceneManager
5. VR 

## 1. Voorbereidingen project

#### Open de packetmanager van Unity en installeer de ML Agents package
Zorg ervoor dat je de "Unity Registry" optie selecteert van het dropdown menu:
![image](https://user-images.githubusercontent.com/72873870/172708445-878e339b-fd48-4f80-af1f-15e682f48f28.png)

## 2. Maken van testing area en AI agent

Om onze AI te testen, hebben we gebruik gemaakt van een aparte scene waarin we aan de AI sleutelden en tests uitvoerden met anaconda. 

#### Testing area
De testing area die we maakte, ziet er als volgt uit:

![image](https://user-images.githubusercontent.com/72873870/172709195-07b969ca-0f5d-426c-aa56-b6051beed3f5.png)

De testing area bestaat uit onze golfagent, de AI, en uit verschillende objecten die samen de map vormen. De agent wordt gerepresenteerd door een blauwe bal, de hole waarin de bal moet is een rode bal. De trainingarea scene view ziet er als volgt uit: 

![image](https://user-images.githubusercontent.com/72873870/172709608-825e0a9e-6b85-4c40-9ef9-110309921c42.png)

Om het testen van onze agent te versnellen, hebben we van de testarea een prefab gemaakt en deze verschillende malen gedupliceerd in onze trainingareascene: 

![image](https://user-images.githubusercontent.com/72873870/172709806-9d42e2b6-4411-44c3-ad3d-ad00371834d0.png)

Het uitvoeren van de tests hebben we, zoals in de lessen, gedaan met anaconda prompt: 

![image](https://user-images.githubusercontent.com/72873870/172710623-2c14c745-f9bf-42ec-8bc7-0671b6a2bc74.png)


#### AI agent

De agent is een 3d sphere object met rigidbody, behavior parameters, golf agent script, decision requester en ray perception sensor 3d:

![image](https://user-images.githubusercontent.com/72873870/172711046-5abcca95-21b8-4815-8b82-4ab44d00e7fd.png)
![image](https://user-images.githubusercontent.com/72873870/172711098-6d183b31-66e2-44e5-a7c8-bf3fc6c93eb2.png)

Het golf agent script ziet er als volgt uit: 
![properties](https://user-images.githubusercontent.com/60871981/172820980-c69b03b1-2835-4fcc-ae47-85c071e840f6.PNG)
![initialize](https://user-images.githubusercontent.com/60871981/172821087-e80e8c44-491e-4d64-96c4-ccb1a1cf66b8.PNG)
![collision](https://user-images.githubusercontent.com/60871981/172821134-1d51193a-ea3e-4257-8cd2-9eb0aa270c09.PNG)
![detection](https://user-images.githubusercontent.com/60871981/172821249-dd7bf60a-7dda-4cdc-861b-b2a11457749d.PNG)
## 3. Maken van maps

We hebben verschillende maps gemaakt met behulp van een asset pack die we in de online asset store hebben gevonden. Gebruikte asset pack: 

![image](https://user-images.githubusercontent.com/72873870/172716986-3bb07049-c329-4c0c-a115-fa2cfb55cb7b.png)

Na wat uittesten hebben we volgende maps gemaakt. De eerste maps zijn eenvoudig, de laatste maps zijn wat meer ingewikkeld.
#### Map 1 

![image](https://user-images.githubusercontent.com/72873870/172717255-0534f8b0-abce-467f-a505-636cb0c4ebc4.png)

#### Map 2

![image](https://user-images.githubusercontent.com/72873870/172717490-31dbd856-f371-4a01-8dde-33c1f835410e.png)

#### Map 3

![image](https://user-images.githubusercontent.com/72873870/172717559-fd928c2b-92dd-4bfa-be61-c6df03f34726.png)


#### Map 4

![image](https://user-images.githubusercontent.com/72873870/172717664-3640daf9-d91c-4ff8-af01-1b106db001c4.png)


#### Map 5

Je ziet op dat de speler op deze map verschillende opties kan kiezen om de hole te bereiken
![image](https://user-images.githubusercontent.com/72873870/172717746-c3a15886-72e9-4f50-93d4-44fa7546aae2.png)


#### Map 6
Zijaanzicht: 
![image](https://user-images.githubusercontent.com/72873870/172717943-e33d5001-363d-4e0a-8c5e-e857bd4df839.png)

Bovenaanzicht: 
![image](https://user-images.githubusercontent.com/72873870/172717993-41159821-ef05-4126-ba22-799a4fee46f2.png)

#### Algemene mapstructuur
Op elke map staan twee vlaggen, een roodwit gestreepte vlag en een effen vlag. De speler begint steeds vanaf de gestreepte vlag. De effen vlag maakt duidelijk waar de hole is.
#### Prefab
Van elke map hebben we een prefab gemaakt, zodat we deze later makkelijk kunnen gebruiken in ons spel. 

## 4. SceneManager
#### Builder opties
Het spel bestaat uit 6 verschillende levels, met 6 verschillende maps:

![image](https://user-images.githubusercontent.com/72873870/172719086-28c3d953-0b27-46f1-91fc-4121013ea4d3.png)

We hebben alle scenes samengebracht met behulp van de SceneManager van Unity. Voordat we hiermee kunnen werken, moeten de build instellingen aanpassen en onze scenes toevoegen. Alle verschillende scenes worden toegevoegd door ze met behulp van "drag & drop" toe te voegen aan de builder:

![image](https://user-images.githubusercontent.com/72873870/172719349-005c08c9-27fe-4e5c-95ee-28199ed43996.png)

#### Holes
In elke hole hebben we een soort van deathzone geïmplementeerd. De deathzone, in ons geval de sceneSwitcher is een sphere object met een rigidbody dat dient als een trigger. De mesh renderer is gedisabled zodat de sphere niet zichtbaar is:

![image](https://user-images.githubusercontent.com/72873870/172719827-ed0293e8-0677-4657-8121-766c5f39f26e.png)

![image](https://user-images.githubusercontent.com/72873870/172719859-bb6cffb8-3bfc-4e76-92dd-9db62a347df5.png)

#### Scene Switch 
Elke sceneSwitch object heeft een script genaamd SceneSwitch:

![image](https://user-images.githubusercontent.com/72873870/172720006-deda156a-5984-48e9-bbd5-786cee73e46d.png)

Na het toevoegen van de namespace UnityEngine.SceneManagement kunnen we gebruik maken van de LoadScene methode om de volgende scene te laden bij een collide event. Wanneer de bal in de hole valt, zal de volgende scene worden geladen. 

#### Menu
We hebben een VR menu toegevoegd aan elke scene om zo van map te wisselen. Het is een simpele UI canvas component met twee belangrijke scripts. Onderstaand script zorgt ervoor dat je de menu tevoorschijn kan laten komen door op de y-knop van je controller te drukken: 

![image](https://user-images.githubusercontent.com/72873870/172815928-546830c6-ceea-4210-8acf-70bfbce7d495.png)

De buttons op het canvas zijn gelinkt met de scenes met behulp van de OnClick() method van Unity. Je geeft de naam van de te laden scene mee als parameter. Hiervoor is ook een kort scriptje geschreven:

![image](https://user-images.githubusercontent.com/72873870/172816228-00a4215a-c4f0-47e5-85af-40b1c15c0de9.png)

## 5. VR

Voor het VR aspect van het project hebben we het vrij simpel gehouden.
We maakten gebruik van de built-in tools van unity om de vr op te zetten, we maakten eerst een VR Rig object aan per level.

Aan dit VR Rig object gaven we 2 controllers (voor links en rechts) en een camera dat het zicht van de speler zal zijn.
Dan hebben we, om de speler rond te laten bewegen, een teleporteer systeem toegevoegd. Dit zit nogmaals allemaal ingebouwd in Unity.
We hebben een teleportation provider component toegevoegd aan onze VR Rig, daarna hebben we aan elk oppervlak waar de speler op moet kunnen staat een teleportation area component toegevoegd. 

Om de teleportation area te gebruiken moesten we ook nog een box collider toevoegen omdat deze niet werkt met een meshcollider. Daarna zetten we de boxcollider op isTrigger zodat deze niet de collision veranderd van de golfbaan.
Vervolgens moeten we de speler een manier geven om te teleporteren, hiervoor gaven we de VR Rig nog 2 objecten: Lefthandray en Righthandray. Dit zijn 2 extra controllers maar deze hebben ook nog eens een interaction ray component, dit zorgt er voor dat de speler met objecten in de wereld kan interacten zoals rondteleporteren, de stick pakken en de bal pakken.

Voor de physics hebben we gebruik gemaakt van de built-in physics van unity zelf waarvoor niets van extra programmeren nodig was. 
Je voegt een aan de bal en de stick beide een rigidbody toe en unity doet de rest.

