﻿namespace uLearn.Courses.BasicProgramming.Slides
{
	[Slide("Практика", "{3AD2D195-94B7-457C-A508-AA95EB70ED37}")]
	class S099_Exercise
	{
		/*
		В дальнейшем каждый модуль будет заканчиваться слайдом с практическими задачами для самостоятельного решения.

		Студентам ИМКН УрФУ предстоит сдавать эти задачи своим преподавателям на компьютерных практиках.

		*/
		
/*
[Скачать проекты с задачами](https://github.com/urfu-code/cs101-01-expr/archive/master.zip)

Проценты со вклада в банке
---
1. Создайте новый проект Console Application.
2. Напишите программу, которая после ввода суммы, процентной ставки и срока вклада 
рассчитывает накопившуюся сумму на момент окончания вклада.
3. Не забудьте выделить код, решающий задачу в отдельную от ввода и вывода функцию.

Детали:

1. В конце каждого месяца происходит "капитализация" — к сумме прибавляется накопившийся за месяц процент. 
Далее процент вычисляется от этой увеличенной суммы.
2. Процентная ставка — годовая (то есть в конце месяца сумма на счете увеличивается на одну двенадцатую ставки)
3. Считайте, что вклад открыт в первый день месяца, а срок вклада — это целое количество месяцев.


Angry Birds
---
1. Откройте и изучите проект AngryBirds. Это простой симулятор системы прицеливания.
2. Реализуйте функцию расчета угла прицеливания, в зависимости от начальной скорости снаряда и дальности до цели.

        double FindSightAngle(double v, double distance)

3. Проверьте корректность своего решения, запустив проект.

Детали:

1. Сопротивлением воздуха можно пренебречь
2. Ускорение свободного падения g = 9.8 м/с<sup>2</sup>
3. Освежить свои знания по физике всегда можно в википедии. В данном случае, вам может быть полезна статья про 
[Равноускоренное движение](http://ru.wikipedia.org/wiki/%D0%A0%D0%B0%D0%B2%D0%BD%D0%BE%D1%83%D1%81%D0%BA%D0%BE%D1%80%D0%B5%D0%BD%D0%BD%D0%BE%D0%B5_%D0%B4%D0%B2%D0%B8%D0%B6%D0%B5%D0%BD%D0%B8%D0%B5)

Бильярд
---
1. Откройте и изучите проект Billiards.
2. Вам нужно реализовать функции, для расчета угла отскока шарика от горизонтальных и вертикальных стен: 

        double BounceVerticalWall(double directionRadians);
        double BounceHorizontalWall(double directionRadians);

3. Проверьте корректность реализации, запустив проект.
4. После этого реализуйте более общую функцию отскока от произвольной стены, заданной углом ее наклона к горизонтали


        double BounceWall(double directionRadians, double wallInclanationRadians);

5. Проверьте корректность реализации, запустив проект еще раз.

Детали:

В этой задаче нужно считать, что угол падения равен углу отражения, то есть пренебречь всеми физическими эффектами, 
связанными с кручением шаров, трением шара об стенку и т.п.		
		
*/

	}
}
