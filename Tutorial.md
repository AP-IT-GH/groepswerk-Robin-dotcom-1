# Documentatie VR Golf (Tutorial)

## Inhoudstabel
1. Voorbereidingen project
2. Maken van testing area en AI agent
3. Maken van maps
4. SceneManager

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



