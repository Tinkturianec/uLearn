﻿
# Аудиторные практики

1. Превратить рациональную дробь в десятичную. Возможен период. "1/3" должна превратиться в "0.(3)"

2. Каждый член последовательности является суммой квадратов цифр предыдущего. Задан первый элемент. Найти N-ый.
(там обязательно будет период)

3. Пусть задана функция f : [1..N] → [1..N]. Найти длину цикла в последовательности 1, f(1), f(f(1)), f(f(f(1))), ...
(алгоритмы описаны тут: http://en.wikipedia.org/wiki/Cycle_detection)

4. Пусть дан N-граф со единичной степенью исхода каждой вершины. Какова структура этого графа?

5. Граф из предыдущей задачи. Аня стоит в вершине x, а Вася в вершине y. Каждую секунду Аня передвигается по дуге графа и Вася передвигается по дуге графа.
Через сколько секунд Аня и Вася встретятся в одной вершине?

6. Проверить, что все цифры натурального числа разные.

# Компьютерные практики

Смотреть на то, как представляют N-грамму. Есть несколько способов со своими плюсами-минусами:

* Грамма — это массив строк. Массивы нельзя использовать в качестве ключей словарей и нельзя сравнивать на равенство.
* Грамма — это Tuple<string, ...>. Tuple разного размера являются разными и несовместимыми друг с другом типами. 
Поэтому не получится написать общий код нахождения всег N-грамм для произвольного N.
* Грамма — это отдельный класс, с переопределенными GetHashCode и Equals. Хорошо, но про это им ещё не рассказывали.
* Грамма — это строка, в которой все слова разделены пробелом. Наиболее приемлемый способ на данном этапе. Но для получения i-ого слова граммы придется пользоваться Split.

Смотреть на общий стиль. Длину методов, имена переменных и методов. 
Данные между методами не должны передаваться через поля класса, должны передаваться аргументами
и возвращаться в качестве возвращаемого значения функций.

Обращать внимание на эффективность алгоритма. Все должно быть в конце концов линейно от размера текста.

Операция поиска подходящего следующего слова должна работать за O(1) с помощью специально подготовленного Dictionary.

Распространенная ошибка — использовать для этого непосредственно словарь грамма → частота, пробегаясь по нему каждый раз циклом за O(n):

	int maxValue = int.MinValue;
	foreach(var pair in grammsFrequencies){
		if (pair.Value > maxValue){
			gram = pair.Key;
			maxValue = pair.Value;
		}
	}

Ещё одна распространенная ошибка при выводе частот:
foreach( ... in gramsFrequencies.OrderBy(...).ToDictionary())

После ToDictionary порядок уже никто не гарантирует. При этом результат будет слегка похож на отсортированный, из-за особенностей реализации хэш-таблицы, но на самом деле корректным не будет.