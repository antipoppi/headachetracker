# Käyttöohjeet

## Login-ikkuna ja Registration-ikkuna

![Rekisteröinti](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/registrationscreen.png "Rekisteröinti")


![Kirjautuminen](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/loginscreen.png "Kirjautuminen")



Login-ikkunasta kirjaudutaan sisään kirjoittamalla käyttäjätunnus ja salasana niille tarkoitettuihin laatikoihin. Sen jälkeen painetaan Login-nappia, jotta kirjaudutaan sisään.

Jos sinulla ei ole käyttäjätunnusta, voit painaa Register-nappulaa, jolloin avataan uusi ikkuna. Registration-ikkunassa rekisteröidytään kirjoittamalla käyttäjätunnus, salasana ja salasanan vahvistus. Tämän jälkeen painetaan Submit-nappulaa, jolloin käyttäjätunnus rekisteröidään tietokantaan.

Registration-ikkunassa on myös mahdollista poistaa kirjoittamansa tiedot painamalla Reset-nappulaa tai peruuttaa ja palata kirjautumisruutuun painamalla Cancel-nappulaa.


## MainWindow -ikkuna


![MainWindow](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/mainwindow.png "MainWindow")


 Kirjauduttuasi avautuu MainWindow-ikkuna, jossa on  4 nappia: New entry, Edit selected, Delete selected ja Quit.
* New entry -napista avataan ikkuna, jossa voit tehdä uuden merkinnän. 
* Edit selected -napista valittu datagridin rivi avataan muokattavaksi Edit entry -ikkunaan.
* Delete selected -napista valittu datagridin rivi poistetaan tietokannasta.
* Quit-napista ohjelma suljetaan. Tällöin ilmestyy viestiruutu, jossa varmistetaan ohjelman sulkeminen. Jos painat Yes-nappia, ohjelma suljetaan. Muutoin ohjelma pysyy käynnissä.


## Add entry -ikkuna


![AddEntry](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/entryscreen.png "AddEntry")

 Painettuasi New entry -nappia, avataan Add entry -ikkuna, jossa voit lisätä merkintöjä. Voit valita päänsäryn tyypin ja päänsäryn kiputason sekä lisätä muistiinpanoja tekstiruutuun.

* Add medications -nappia painettaessa avataan uusi ikkuna, jossa voit lisätä merkintään lääkkeitä.
* Add symptoms -nappia painettaessa avataan uusi ikkuna, jossa voit lisätä merkintään oireita.
* Add reliefs -nappia painettaessa avataan uusi ikkuna, jossa voit lisätä merkintään päänsärkyä helpottaneita asioita.
* Add triggers -nappia painettaessa avataan uusi ikkuna, jossa voit lisätä merkintään päänsäryn aiheuttajia.
* Preview-nappia painettaessa avataan ikkuna, josta voi esikatsella merkintään lisättyjä tietoja.
* Cancel-napista palataan takaisin MainWindow-ikkunaan.

Merkintä tallennetaan painamalla Save entry -nappia. Tällöin palataan pääikkunaan, jossa uusi merkintä päivittyy datagridiin ja tietokantaan.

![AddMedications](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/medicationscreen.png "AddMedications")
![AddSymptoms](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/symptomscreen.png "AddSymptoms")
![AddReliefs](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/reliefscreen.png "AddReliefs")
![AddTriggers](https://gitlab.labranet.jamk.fi/N3091/headachetracker/-/raw/master/kuvat/triggerscreen.png "AddTriggers")




