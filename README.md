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
10. [Loppuraportti](#loppuraportti)

<a name="tietoa"></a>
## Tietoa tekijöistä
Tatu Alatalo (N4927): tieto- ja viestintätekniikan muuntokoulutusopiskelija (valmistuu 2021 lopussa)

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
* Käyttäjän tietojen muokkaaminen
* Käyttäjän tietojen poistaminen

<a name="usecase"></a>
## Käyttötapauskaavio

### Sovellukseen kirjautuminen

![Sovellukseen kirjautuminen](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/usecase_register_login.jpg "Sovellukseen kirjautuminen")  
**Sovellukseen rekisteröityminen:** Sovelluksen käyttämiseksi täytyy luoda ensin käyttäjätunnus, jossa pakollisena tietona on käyttäjänimi. Käyttäjä voi tallentaa myös muuta tietoa käyttäjäprofiiliinsa joka tallennetaan tietokantaan.  
**Sovellukseen kirjautuminen:** Sovellukseen kirjaudutaan valitsemalla käyttäjänimi.  

### Käyttäjän tietojen muokkaaminen

![Käyttäjän tietojen muokkaaminen](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/usecase_edit_delete_user.png "Käyttäjän tietojen muokkaaminen")  
**Käyttäjän tietojen muokkaaminen** Käyttäjän voi muokata omia tietojaan, kuten esim. käyttäjänimeään  
**Käyttäjän tietojen poistaminen** Käyttäjä voi poistaa tunnuksensa sekä kaikki merkintänsä.

### Merkintöjen lisäys

![Tietojen käsittely](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/usecases.jpg "Tietojen käsittely")

**Tietojen syöttäminen:**   Sovellukseen lisätään uusi merkintä jossa selviää päänsärkytyyppi, särkytaso, mahdolliset lääkkeet, oireet, särynlievitys, 
mikä aiheutti, päivämäärä sekä muistiinpanoja. Lopuksi tämä tieto tallennetaan tietokantaan.  
**Tietojen tarkastelu:**    Merkintöjä voi etsiä tietokannasta ja lukea niitä.  
**Tietojen poistaminen:**   Etsityn/valitun merkinnän voi poistaa tietokannasta.  
**Tietojen muokkaus:**      Etsityn/valitun merkinnän tietoja voi muokata ja päivitys tallennetaan tietokantaan.  

<a name="käsitemalli"></a>
## Käsitemalli / luokkakaavio

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

<a name="loppuraportti"></a>
# Loppuraportti

#### 1. Asennus

Tarvittavat .NET Frameworkin ulkopuoliset kirjastot:
* System.Data.SQLite



Nämä vielä pitää kirjoittaa:
* mitä asioita tehtävä ja huomioitava asennuksessa
* konfiguroitavat asiat


**2. Tietoa ohjelmasta (mitä tekee, miksi etc)**

_Toteutetut toiminnalliset vaatimukset_

* Käyttäjän ilmoittaa rekisteröityessään käyttäjänimen
* Käyttäjä ilmoittaa rekisteröityessään salasanan
* Käyttäjä voi kirjautua sisään
* Käyttäjä voi muokata merkintöjään
* Käyttäjä voi poistaa merkintöjään
* Käyttäjä voi tarkastella merkintöjään
* Käyttäjä voi tehdä uusia merkintöjä
* Merkintöjen tekemisessä voi lisätä päänsäryn tyypin
* Merkintöjen tekemisessä voi lisätä kiputason
* Merkintöjen tekemisessä voi lisätä käytettyjä lääkkeitä
* Merkintöjen tekemisessä voi lisätä päänsäryn oireita
* Merkintöjen tekemisessä voi lisätä päänsäryn lievennyskeinoja
* Merkintöjen tekemisessä voi lisätä päänsäryn aiheuttajia
* Merkintöjen tekemisessä voi lisätä muistiinpanoja

_Toteuttamatta jääneet toiminnalliset vaatimukset_

* Käyttäjän tietojen muokkaaminen
* Käyttäjän tietojen poistaminen

_Toiminnallisuus, joka toteutettiin yli alkuperäisten vaatimusten_
Nämä olivat ei-pakollisia:
* Kirjautuminen
* Rekisteröityminen


_Ei-toiminnalliset vaatimukset ja mahdolliset reunaehdot/rajoitukset_
* Salasanan tulee olla yli 5 merkkiä
* Käyttäjänimen tulee olla uniikki
* Salasanat on suolattu
* Salasanoissa käytetty sha256-hashausta


**3. Käyttöohjeet**


Käyttöohjeet ja kuvankaappaukset löytyvät [täältä](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/blob/master/Docs/kayttoohjeet.md).


**4. Ohjelman tarvitsemat /mukana tulevat tiedostot/tietokannat**

Ohjelman mukana tulee SQLiteHeadache.sql-tietokanta.



**5. Tiedossa olevat ongelmat ja bugit sekä jatkokehitysideat**

**6. Mitä opittu, mitkä olivat suurimmat haasteet, mitä kannattaisi tutkia/opiskella lisää jne**

**7. Tekijät, vastuiden ja työmäärän jakautuminen**

**8. Tekijöiden ehdotus arvosanaksi, ja perustelut sille**
