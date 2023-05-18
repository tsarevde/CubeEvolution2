# CubeEvolution2

### На этапе разработки

> Мобильная игра в жанре IO, казуальном сеттинге. Отличительной особенность является - враги, логика которых создана благодаря машинному обучению.


https://github.com/dudeel/CubeEvolution2/assets/76850149/c6544d34-e968-4cdd-a0d3-85da1232108d


## Архитектура приложения
![image](https://github.com/dudeel/CubeEvolution2/assets/76850149/adfedc36-f743-4b69-b8ae-27afc1a6eff5)


## Генерация мира
Объекты в игровом мире генерируются случайным образом используя готовые пресеты, что позволяет делать игровой процесс разнообразнее не жертвую его качеством наполнения.

![image](https://github.com/dudeel/CubeEvolution2/assets/76850149/270a9659-27ae-4f30-98ed-1929e04d61ba)
![image](https://github.com/dudeel/CubeEvolution2/assets/76850149/c600689e-a735-4bde-adb5-17affc047bc9)
![image](https://github.com/dudeel/CubeEvolution2/assets/76850149/8c82b23f-6a3b-4139-8eb9-1eada02118c5)

## Управление персонажем
Управление как пресонажем, так и траекторией выстрела происходит при помощи экранных джойстиков (оба унаследуют методы от одного класса)
Использовал Raycast для отображения дальности атаки.

![image](https://github.com/dudeel/CubeEvolution2/assets/76850149/14a48944-4c4d-40ca-ac74-066cd0d3d389)
![image](https://github.com/dudeel/CubeEvolution2/assets/76850149/45417b4c-d9fe-41bc-9983-2af99727cbd2)
