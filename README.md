>Нашему курьеру нужно доставить пиццу в несколько районов. Чтобы он не запутался, мобильное приложение показывает ему цепочку районов, которые он должен посетить.
>
>Вам нужно реализовать алгоритм обработки данных, получаемых от бэк-офисной системы. Каждый блок данных содержит в себе пункт отправления и пункт назначения. Гарантируется, что если упорядочить эти блоки так, чтобы для каждого блока в упорядоченном списке пункт назначения совпадал с пунктом отправления в следующем блоке в списке, получится один список блоков без циклов и пропусков.
>
>Например, у нас есть блоки:
>
>Южнопортовый → Печатники
>
>Текстильщики → Нижегородский
>
>Печатники → Текстильщики
>
>Если упорядочить их в соответствии с требованиями выше, то получится следующий список: 
>
>Южнопортовый → Печатники, Печатники → Текстильщики, Текстильщики → Нижегородский
>
>Требуется:
>
>Спроектировать и написать на языке C# библиотеку, которая реализует функцию сортировки блоков. При проектировании не забыть про удобство использования и надёжность.
>
>Функция должна принимать набор неупорядоченных блоков и возвращать набор упорядоченный в соответствии с требованиями выше, то есть в возвращаемом из функции списке для каждого блока пункт назначения на ней должен совпадать с пунктом отправления на следующей карточке.
>
>Дать оценку сложности получившегося алгоритма сортировки.
>
>Написать тесты.

## Временная сложность - n^2
## Требуемая память - 2*n
