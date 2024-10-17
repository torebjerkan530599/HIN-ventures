# HIN-Ventures

PROSJEKT ARBEID I WEBAPPLIKASJONER 2.

Av : Halil Ibrahim Keser, Irina Balkerova, Tore Bjerkan

Prosjektbeskrivelse (fra faglærer):
Webutviklingsfirma HIN-Ventures er et mellomstort webutviklingsfirma med 10 faste ansatte. Flere av disse er prosjektledere og blant disse er noen senior utviklere med mange års erfaring. Firmaet tar på seg oppdrag fra små og store aktører i inn og utland. De har en stor andel faste kunder.  De benytter seg i stor grad av frilansere til å løse oppdrag fra kunder.

HIN-Ventures har en god del småoppdrag som går ut på å legge til enkel funksjonalitet i eksisterende kodebase for en kunde. Dette skaper en del papirarbeid og tar mye ressurser fra prosjektlederne og seniorutviklerne. Derfor ønsker HIN-Ventures å få utviklet en løsning som gjør at kundene kommer i direkte kontakt med frilanserne, men at all kode og betaling går igjennom HIN-Ventures.

HIN-Ventures ser for seg en portal hvor frilanserne registrerer seg med sine spesialfelt og får betalt for antall linjer kode de leverer til kunden. Kunden kan abonnere på portalen, og får tilgang til et viss antall linjer kode for en gitt pris.

Kunden skal ha mulighet for å kunne enten velge mellom frilanserne, eller forespørre etter en frilanser basert på spesialfelt. Dersom kunden forespør etter en frilanser basert på spesialfelt, bør det fungere på først til mølla basis. Dvs. første frilanser som griper tak i forespørselen får den. Det bør være mulighet for kunden å kunne chatte med frilanseren i portalen. En frilanser bør kunne utføre deler av et oppdrag, andre frilansere kan overta og fortsette på oppdraget, arbeidet som er utført av hver frilanser må kunne registreres,

Det er viktig at det er mulig å hente ut informasjon om hvor mange linjer kode en frilanser har skrevet for en gitt kunde, og hvor mange linjer kode han har skrevet per måned (For fakturerings hensyn).  Det bør også være mulig å hente ut informasjon om hvem som har jobbet for en kunde og hvor mange linjer kode kunden har brukt. En kunde bør kunne gi en rating til en frilanser som har levert et oppdrag, gjennomsnittlig rating for en frilanser bør vises når en kunde skal velge blant disse.

Hin-Ventures ønsker benytte cryptocoins for betaling av oppdrag fra kunder og betaling til frilansere. Selskapet må ha en cryptocoin-adresse som kunder betaler til, frilanserne mottar betaling fra HiN-Ventures til sin cryptocoin-adresse basert på kodelinjer levert og brukt. block.ioLenker til en ekstern side. tilbyr et testnett og REST API for flere ulike cryptocoins for utviklere.

Portalen skal også gi seniorutviklerne mulighet til å sjekke kvaliteten på koden som er skrevet.

HIN-Ventures ønsker å fremme at frilanserne er aktive på portalen, vi ønsker at kunden skal få kjappe svar på sine henvendelser. Gjerne igjennom at frilanserne er tilkoblet portalen igjennom websocket eller SignalR og vil bli varslet i sanntid når en kunde sender en forespørsel.

Selve løsningen bør ha så nært 100% test coverage som mulig, så det er enkelt for nye (og eksisterende) utviklere å jobbe med portalen uten å ødelegge eksisterende funksjonalitet.

Det forventes av hvert prosjekt munner ut i et ferdig produkt som kan presenteres for faglærere. Den ferdige løsningen bør kunne flyttes, unngå derfor hardkoding av URL'er, filnavn og liknende.

GIT eller Azure Devops skal benyttes aktivt av alle prosjektmedlemmer i utviklingen slik at historikken vil vise hvem som har gjort hva og når til en hver tid. Faglærere må gis tilgang til repository fra starten av prosjektet.

Prosjektoppgaven løses på gruppebasis med opptil 3 medlemmer pr gruppe.

Deployment

Løsningen deployes til Azure eller AWS, epostadresser i uit.no domenet har tilgang til begge disse. Begge steder er det $100 i kreditt, med mulighet for økning ved behov, databaser har vist seg være kostbare i drift. Informasjon om AWS deployment herLenker til en ekstern side., Azure herLenker til en ekstern side..

Innlevering.

Prosjektrapport.

Det skal leveres en prosjektrapport som minimum omfatter følgende elementer:

Beskrivelse av valgt løsning, inklusive klassediagram, databasemodell, tester og liknende som inngår i løsningen
Nødvendige nettadresser (URL) og brukernavn og passord for å kunne vurdere alle aspekter ved løsningen. Typisk både brukernavn og passord for administrator og vanlig bruker må oppgis.
Kommentarer/evaluering knyttet til egen løsning.
Dokumentasjon av arbeidsinnsats pr. deltaker; hvem har gjort hva, og hvor mye tid er brukt. Faglærere må ha tilgang til repository som er benyttet.
Andre forutsetninger vedrørende løsningen.
