# GDSC Gestion
Il s'agit d'une petite application de gestion des participants du hackathon.
L'application a pour but de scanner le code QR que les participants ont obtenu suite à leur inscription et leur permettre de pouvoir avoir accès aux privilèges des participants.
Et aussi d'empêcher certains participants de recevoir certains trucs plusieurs fois.
## Concept
L'application scanne le code QR des participants et le stocke dans une base de donnée en local sur le téléphone.
Lors du scanne, si le code scanné par l'application existe déjà un message est retourné sur le téléphone indiquant que ce code existe déjà.
# Technologie utilisée pour réaliser l'application
* .Net Maui : Framework Microsoft pour le développement multiplateforme.
* Pattern MVVM : Model View ViewModel
* SQLite : Base de donnée sur le téléphone
* ZXinq : Bibliothèque utilisé pour scanner le code QR
## Interface de l'application
<img src="https://mega.nz/file/6YdEmbaD#wFurwwBC3RtV9cwQgj7h2CznVvbovvnL0XcuAKHpxT0" />
