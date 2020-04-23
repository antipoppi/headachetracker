# Sisällysluettelo
1. [Tietoa tekijöistä](#tietoa)
2. [Sovelluksen yleiskuvaus](#kuvaus)
3. [Kohdeyleisö](#kohde)
4. [Käyttöympäristö](#ympäristö)
5. [Toiminnot](#toiminnot)
6. [Käyttötapauskaavio](#usecase)
7. [Käsitemalli](#käsitemalli)
8. [Työnjako](#työnjako)
9. [Työaikasuunnitelma](#työaikasuunnitelma)

<a name="tietoa"></a>
## Tietoa tekijöistä
Tatu Alatalo (N4927)

Venla Lyytikäinen (N3091): ensimmäisen vuoden tieto- ja viestintätekniikan monimuotoinen opiskelija JAMKissa.


<a name="kuvaus"></a>
## Sovelluksen yleiskuvaus
Päänsäryn seurantasovellus. Käyttäjä voi tehdä merkintöjä päänsärystä: oireet, päänsäryn laukaiseva tekijä, kiputaso ym. Sovelluksen tarkoituksena on auttaa seuraamaan päänsäryn oireita, syitä ja tasoa sekä selvittää toimivia omahoitokeinoja.


<a name="kohde"></a>
## Kohdeyleisö
Sovellus on suunnattu ihmisille, joilla on krooninen päänsärky (migreeni, jännityspäänsärky, jne.). Euroopassa ja Amerikassa 15-18%:lla naisista ja 6-8%:lla miehistä on diagnosoitu migreeni (https://migreeni.org/tietoa/migreeni/).  Jännityspäänsärkyä on miehillä ja naisilla suunnilleen yhtä paljon.

Sovelluksen kohderyhmä on melko laaja, joten ulkoasun tulisi miellyttää suurta osaa ihmisistä.


<a name="ympäristö"></a>
## Käyttöympäristö ja käytetyt teknologiat
Sovelluksen käyttöympäristönä on Windows. Ohjelmoinnissa käytetään SQLiteä, C#-kieltä ja WPF-tekniikkaa.

<a name="toiminnot"></a>
## Toteutettavat toiminnot

**Pakolliset**
* Uusien merkintöjen tekeminen
* Merkintöjen tarkastelu
* Merkintöjen muokkaaminen
* Merkintöjen poistaminen

**Ei-pakolliset**
* Kirjautuminen
* Rekisteröityminen


<a name="usecase"></a>
## Käyttötapauskaavio

![Käyttötapauskaavio](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/usecases.jpg "Käyttötapauskaavio")

**Tietojen syöttäminen:**   Sovellukseen lisätään uusi merkintä jossa selviää päänsärkytyyppi, särkytaso, mahdolliset lääkkeet, oireet, särynlievitys, 
mikä aiheutti, päivämäärä sekä muistiinpanoja. Lopuksi tämä tieto tallennetaan tietokantaan.  
**Tietojen tarkastelu:**    Merkintöjä voi etsiä tietokannasta ja lukea niitä.  
**Tietojen poistaminen:**   Etsityn/valitun merkinnän voi poistaa tietokannasta.  
**Tietojen muokkaus:**      Etsityn/valitun merkinnän tietoja voi muokata ja päivitys tallennetaan tietokantaan.  

<a name="käsitemalli"></a>
## Käsitemalli / luokkakaavio?

Sovelluksen yksinkertainen käsitemalli:
![Käsitemalli](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/kasitemalli.jpg "Käsitemalli")

Sovelluksen tietokannan luokkakaavio:
![SQL-kaavio](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/SQL_classdiagram.jpg "SQL-kaavio")

<a name="työnjako"></a>
## Työnjako
Työt jaetaan suunnilleen tasan, oman motivaation mukaan. 

<a name="työaikasuunnitelma"></a>
## Työaikasuunnitelma
*  Vko17: Suunnitelman tekeminen (10 tuntia)
*  Vko18: Tietokannan suunnittelu ja toteutus, käyttöliittymän suunnittelu (30 tuntia)
*  Vko19: Käyttöliittymän suunnittelu ja toteutus XAML, C#-koodi (30 tuntia)
*  Vko20: Käyttöliittymä XAML, C#-koodi (30 tuntia)
*  Vko21: Testaaminen, dokumentointi ja työn palautus (20 tuntia)  
**Yhteensä 120 tuntia**

Työaikojen dokumentaatio löytyy [täältä](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/blob/master/Docs/tyotunnit.md).
