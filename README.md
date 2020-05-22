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
10. [Loppuraportti ja esittely](#loppuraportti)

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
# Loppuraportti ja esittely

#### [Esittelyvideoon pääsee tästä](https://www.youtube.com/watch?v=W11ASStET-U)

#### 1. Asennus

**[Asenna tästä](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/Asennustiedosto/headachetracker_setup.exe).**


Asennus löytyy myös [täältä](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/blob/master/Asennustiedosto/headachetracker_setup.exe).

**Tarvittavat .NET Frameworkin ulkopuoliset kirjastot:**
* System.Data.SQLite

**Asennusohjeet**
1. Tuplaklikkaa headachetracker_setup.exe-tiedostoa.
2. Valitse haluatko asentaa ohjelman kaikille käyttäjille vai nykyiselle käyttäjälle. Paina Seuraava.
3. Valitse asennuskansio. Paina Seuraava.
4. Luo halutessasi pikakuvake työpöydälle. Paina Seuraava.
5. Paina Asenna.
6. Paina Valmis.

**Konfigurointi**

Ohjelma pitää suorittaa järjestelmänvalvojana, koska tietokantaa muokataan muualla kuin AppData-kansiossa.

#### 2. Tietoa ohjelmasta (mitä tekee, miksi etc)

**Toteutetut toiminnalliset vaatimukset**

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

**Toteuttamatta jääneet toiminnalliset vaatimukset**

* Käyttäjän tietojen muokkaaminen
* Käyttäjän tietojen poistaminen

**Toiminnallisuus, joka toteutettiin yli alkuperäisten vaatimusten**

Nämä olivat ei-pakollisia:
* Kirjautuminen
* Rekisteröityminen


**Ei-toiminnalliset vaatimukset ja mahdolliset reunaehdot/rajoitukset**
* Salasanan tulee olla yli 5 merkkiä
* Käyttäjänimen tulee olla uniikki
* Salasanat on suolattu
* Salasanoissa käytetty sha256-hashausta


#### 3. Käyttöohjeet


Käyttöohjeet ja kuvankaappaukset löytyvät [täältä](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/blob/master/Docs/kayttoohjeet.md).


#### 4. Ohjelman tarvitsemat /mukana tulevat tiedostot/tietokannat

Ohjelman mukana tulee SQLiteHeadache.sql-tietokanta.



#### 5. Tiedossa olevat ongelmat ja bugit sekä jatkokehitysideat

Tälle sovellukselle voisi tehdä vielä käyttäjälle lisätietoja (nimi, osoite ym.) sekä käyttäjä voisi muokata näitä tietojaan.
Jatkokehitysideana olisi siistiä virheiden käsittelyä, joka on aika monimutkaisesti tehty tällä hetkellä. Sen lisäksi esim. oireita valitessa olisi hyvä muistaa komponenttien tilat ja esim. muokkaustila voisi olla lisäystilan kaltainen.


Lisäksi tietokannan voisi siirtää AppData-kansioon tms. jotta ei tarvitse olla järjestelmänvalvoja voidakseen käyttää sovellusta.


#### 6. Mitä opittu, mitkä olivat suurimmat haasteet, mitä kannattaisi tutkia/opiskella lisää jne

MVVM-arkkitehtuuria olisi hyvä opiskella. Yritimme tehdä tähän sitä aluksi, mutta koska se oli liian työläs tähän, päädyimme olemaan käyttämättä sitä.



#### 7. Tekijät, vastuiden ja työmäärän jakautuminen

Työn määrä jakautui aika lailla puoliksi. Tatu teki enemmän tietokantaan ja salaukseen liittyviä asioita. Venla puolestaan teki enemmän käyttöliittymän toiminnallisuuksia ja ulkoasua.
Molemmat kuitenkin osallistuivatsekä käyttöliittymän suunnitteluun, toteutukseen että tietokantoihin liittyviin asioihin.

#### 8. Tekijöiden ehdotus arvosanaksi, ja perustelut sille

Kyseessä on toimiva sovellus, jota voi käyttää päänsäryn seurantaan. Ulkoasultaan sovellus on selkeä.
Virheitä, tietokantoja ja olioita on käsitelty. Lähdekoodi on kommentoitu ja sekä koodi että muuttujien ym. nimeäminen on yritetty tehdä mahdollisimman selkeästi.
Teimme asennus- ja käyttöohjeet. Aika käytettiin hyvin ja tasapuolisesti.


Näistä syistä ehdotamme arvosanaksi 5.