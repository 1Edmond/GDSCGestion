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
* ZXinq : Bibliothèque utilisée pour scanner le code QR
## Interface de l'application
<div>
  <img src="https://user-images.githubusercontent.com/99556348/211666762-9f690481-c224-4128-b6d3-50bce8edd4a6.jpg" width="240" heigth="240" />
  <img src="https://user-images.githubusercontent.com/99556348/211666781-67c83a31-2a27-490c-8926-e615d69c82b9.jpg" width="240" heigth="240" />
  <img src="https://user-images.githubusercontent.com/99556348/211666789-6c8c686a-4682-459a-805a-57391fc6b010.jpg" width="240" heigth="240" />
</div>
