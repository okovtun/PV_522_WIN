https://github.com/okovtun/PV_522_WIN.git
https://www.youtube.com/playlist?list=PLeqyOOqxeiINVm9qYjf8vL_BT0gKdaFR_

Disable stupid VS features:
https://stackoverflow.com/questions/73964338/how-to-disable-automatic-brace-surrounding-on-selection-in-visual-studio

C++:
https://legacy.cplusplus.com/doc/tutorial/

Jeffrey Richter:
https://github.com/maybez/maybe/blob/master/Books/windows/Windows%20Via%20C%EF%BC%8FC++,Fifth%20Edition%20.pdf

TODO:
1. Почитать про двойную буферизацию;
2. 

DONE:
1. На форму добавить 'checkBoxShowWeekday', который будет отображать или скрывать день недели;	DONE
2. *Форма всегда должна запускаиться в правом верхнем углу экрана, независимо от разрешения;	DONE
3. Залить проект на GitHub и прислать ссылку на репозиторий;	DONE

DONE:
1. Создать программу установки для калькулятора;

DONE:
1. Создать ветку 'ResourceOnlyDLL';
2. Значки кнопок вынести в *.DLL-файлы "square_blue.dll" и "metal_mistral.dll":
	https://learn.microsoft.com/en-us/cpp/build/creating-a-resource-only-dll?view=msvc-170
	LoadLibrary("filename");
	FreeLibrary(???);

LIB:
	***https://learn.microsoft.com/en-us/cpp/build/walkthrough-creating-and-using-a-static-library-cpp?view=msvc-170
DLL:
	***https://learn.microsoft.com/en-us/windows/win32/dlls/dynamic-link-libraries
	***https://learn.microsoft.com/en-us/cpp/build/walkthrough-creating-and-using-a-dynamic-link-library-cpp?view=msvc-170

DONE:
1. Создать ветку 'Colors';	DONE
2. Для каждой темы подобрать цветовую схему и обеспечить переключение цветовых схем 
   вместе с переключением скинов;	DONE
3. Применить кастомный шрифт к дисплею калькулятора;

DONE:
0. Сделать COMMIT на 'master', после COMMIT скачать архивы в папку 'ButtonsBMP'
   и распаковать их в соответсвующие папки,
   после чего сделать еще один COMMIT 'ButtonsBMP.RAR', и только после этого
   создать ветку 'ButtonsBMP_HW';
1. Применить к кнопкам любую тему на выбор:
	https://github.com/okovtun/PV_522_WIN/tree/master/WinAPI/Calc/ButtonsBMP;
2. ***Обеспечить переключение тем калькулятора через контекстное меню;
3. Почитать про кнопки:
	https://learn.microsoft.com/en-us/windows/win32/controls/buttons
	https://learn.microsoft.com/en-us/windows/win32/controls/button-types-and-styles	!!!
	https://learn.microsoft.com/en-us/windows/win32/controls/button-styles

DONE:
1. Сделать COMMIT;
2. Создать ветку 'CalculationsHW';
3. На ветке 'CalculationsHW' организовать вычисления конвейером;
4. Применить значки к кнопкам;

DONE:
1. Сделать COMMIT;
2. Создать ветку 'KeyboardHW';
3. На ветке 'KeyboardHW' добить оставшиеся клавиши;
	https://learn.microsoft.com/en-us/windows/win32/inputdev/wm-keydown

DONE:
В Solution 'WinAPI' добавить проект 'CalcHW' и в этом проекте реализовать калькулятор,
наподобие калькулятора Windows.

DONE:
1. В проекте 'MainWindow' окно должно всегда запускаться ровно по центру экрана,
   и занимать ровно 75% экрана;
2. В том же проекте при изменении размера окна и перемещении окна по экрану,
   его размер и позиция на экране должны отображаться в строке заголовка;

DONE:
1. В Solution 'WinAPI' добавить проект 'ListBox', и реализовать в нем такой же функционал, как и в проекте 'ComboBox';
2. В проекте 'ListBox' в окне должна быть кнопка "Добавить", при нажатии на которую открывается модальное окно диалога,
   и в этом окне можно ввести текст добавляемого элемента;
3. Добавить кнопку "Удалить", которая удаляет выбранный элемент ListBox-а;
4. Двойной щелчек мыши на элементе ListBox открывает такое же окно, как и при добавлении элемента,
   и в текстовое поле дочернего окна уже загружен выбранный элемент. При внесении изменений в текст элемента
   и нажатии кнопки 'OK' изменения сохраняются в ListBox-е;

DONE:
1. Загрузить значек в окно 'ComboBox';
2. При нажатии кнопки 'Cancel' программа должна закрываться;
3. При нажатии кнопки 'OK' должно появляться окно сообщения (MessageBox),
   В котором будет информация о том, какой пункт ComboBox-а выбрал пользователь.
   Нужно отобразить как номер, так и содержимое выбранного пункта;

DONE:
1. Почитать про Венгерскую нотацию:
	https://ru.wikipedia.org/wiki/%D0%92%D0%B5%D0%BD%D0%B3%D0%B5%D1%80%D1%81%D0%BA%D0%B0%D1%8F_%D0%BD%D0%BE%D1%82%D0%B0%D1%86%D0%B8%D1%8F
2. https://www.ixbt.com/cpu/cpu-digest-2009.shtml
3. При запуске программы в EditControl 'IDC_EDIT_LOGIN' должно отображаться приглашение
   'Введите имя пользователя'. Когда пользователь ставит курсор в это поле, приглашение пропадает,
   и если пользователь ввел свое имя, то при уходе с текстового поля, в нем сохраняется имя пользователя.
   Но если на момен ухода с текстового поля оно остается пустым, то приглашение возвращается.

DONE:
1. Зарегистрироваться на github.com;
2. В журнал прислать ссылку на свой GitHub;