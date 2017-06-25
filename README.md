# PatrizierKartenEditor
Patrizier Karteneditor für "stadtplatz##.tow"-Dateien 

Modding
Um Patrizier 2 modden zu können benötigt ihr das Programm
Dragon UnPACKer v5.7.0 Beta

Wenn ihr es installiert habt, könnt ihr damit die Datei
p2arch0.cpr
die sich in eurem Patrizier 2 Verzeichnis befindet öffnen.

Extrahiert damit die 28 Dateien stadtplatz00.tow bis stadtplatz27.tow in euer “…\PATRIZIER II Gold\iso\towns\“ Verzeichnis.

Falls es das Verzeichnis noch nicht gibt:
Erstellt in dem Verzeichnis, in dem sich auch die “Patrizier 2.exe“ befindet einen neuen Ordner namens „iso“. Geht nun in das Verzeichnis „iso“ und erstellt ebenfalls einen neuen Ordner namens „towns“.

In meinem Fall liegen nun die 28 stadtplatz## Dateien in
C:\Games\PATRIZIER II Gold\iso\towns\


Bei der stadtplatz00.tow Datei handelt es sich um den Grundriss von Lübeck.
Das heißt, wenn ihr diese Datei nun verändert könnt ihr zum Beispiel den Bauplatz außerhalb der äußersten (3tem) Mauer zum Bauen zur Verfügung stellen. Ebenso kann man festlegen, dass auch Häuser außerhalb der Mauer gebaut werden können.
Des Weiteren können mehr Fischereibauplätze freigegeben werden.
Ins Besondere kann man auch dem Spiel vorgaukeln, dass die Straßen unerreichbar sind – wodurch keine elend langen und super lästigen Straßen automatisch nach Platzierung eines Betriebes gezogen werden.


Um die stadtplatz##.tow Dateien bearbeiten/modden zu können benötigt ihr einen Hex Editor. Z.B. das Programm
HxD

Wenn ihr das Programm installiert habt öffnet nun eine der stadtplatz##.tow Dateien – z.B. stadtplatz00.tow (Lübeck).



Die ersten 100 Bytes beschreiben Metadaten. Alle anderen Bytes legen fest wo auf der Karte was zu finden ist. Und zwar beschreibt jeder folgende 226 Bytes Block eine Spalte auf der Karte – von oben bis unten. Der darauffolgende 226 Bytes Block beschreibt die rechts danebenstehende Spalte usw.




Jedes Byte gibt nun also an was sich an dieser Stelle befindet.
Hier eine Liste was die Bytes bedeuten:

03 = Straße außerhalb innerer Stadtmauer - zählt NICHT zum Straßenausbau in Bauoption dazu
04 = parallel neben der Straße außerhalb innerer Stadtmauer
06 = Rand
0B = Werft + Reparaturdeck + Hafenmeister (Leuchtturm)
0C = Wasser
0D = Steg / Küste / Felsen / Steine
0A = Stadtmauer
09 = Stadtmauer
10 = Außerhalb äußerster Stadtmauer – nicht bebaubar
11 = parallel neben der Stadtmauer
20 = Innerhalb äußerster Stadtmauer – bebaubar wenn Betrieb in der Nähe
80 = innerer Platz - zählt zum Straßenausbau in Bauoption als bereits ausgebaut dazu
83 = Straße innerhalb innerer Stadtmauer - zählt zum Straßenausbau in Bauoption dazu
84 = parallel neben der Straße innerhalb innerer Stadtmauer
8B = Stadtgebäude
91 = parallel innerhalb innerer Stadtmauer entlang
94 = Waffenkammer
97 = Ratskeller (Spelunke)
9C = Hafenkanone
9F = Platz dicht neben Stadtgebäude

0E = Fischereiplatz
3B = Bauplatz für Betrieb
A1 = Hausplatz (In vertikaler Lage)
A2 = Hausplatz (In horizontaler Lage)
A0 = innerhalb innerer Stadtmauer – sowohl für Betrieb als auch für Häuser bebaubar, wenn eines der beiden in der Nähe gebaut ist.
9E = reservierter Platz immer 2-mal vor A1 & A2 - wenn mit A0 ersetzt überscheiben Häuser den Landhandel - schützt die Scheune vor überschreiben
1E = reservierter Platz immer 2-mal vor 0E Fischereiplatz


Möchte man nun also den Platz außerhalb der äußersten Stadtmauer für den Bau freigeben ändert man alle „10“ Bytes in „A0“ Bytes.
Möchte man den Platz außerhalb der innersten Stadtmauer für den Bau von Betrieben UND Häusern freigeben ändert man alle „20“ Bytes in „A0“ Bytes.
Möchte man das außerhalb der innersten Stadtmauer keine Straßen zu Betrieben gezogen werden ändert man alle „03“ Bytes in „0D“ Bytes und alle „04“ Bytes in „A0“ Bytes. => Das Spiel meint also es gibt keine Straßen außerhalb der innersten Stadtmauer mehr.
Möchte man mehr Bauplätze von Beginn an ändert man alle „20 20 20 20 20 20 20“ Bytes in „20 20 20 20 20 20 3B“ Bytes.


Hier eine Übersichtskarte die ich aus den Hex Bytes in Excel übertragen habe.
Wenn ihr reinzoomt seht ihr die Byte-Werte des jeweiligen Kästchens.



Ich habe nun einen simplen Karteneditor für die Patrizier "stadtplatz##.tow"-Dateien erstellt, mit dem man diese auf einfache Weise bearbeiten kann.

Bitte ladet eure modifizierten Stadtplätze in dieses Forum hoch, damit auch andere Leute etwas davon haben.


zippyshare
[url=http://www52.zippyshare.com/v/nsDzjvFm/file.html]PatrizierKartenEditor.exe[/url]

dropbox
[url=https://www.dropbox.com/s/5ylnmc88cwz0oql/PatrizierKartenEditor.exe?dl=0]PatrizierKartenEditor.exe[/url]
