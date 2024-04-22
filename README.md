# Diplom

Весь проект построен на взаимодействии SQL и C#

Для работоспособности понадобится импортировать базу данных из папки SQL для импорта.

При запуске нас встречает окно входа. Если есть аккаунт, то вписываете свой логин и пароль. Если данные верны, то вас пустит на главное меню.
Также можно зарегестрироваться (нажать на кнопку с одноименным названием). Там вписываете данные, если похожего логина нету в бд, то регистрация будет успешной.

В главном меню сражзу можно увидеть вкладки для использования разных функций приложения. Управление интуитивно понятное. P.S. Настройку доступа к вкладкам я не сделал, но у пользователя есть параметр root для настройки видимости возможностей. 

В плане структуры кода да знаю, оно отвратительное (все происходит в 1 файле, хотя можно запросы к бд перенести в другой файл (ООП), но времени чутка не хватило сделать код более красивым).
А так все функции имеют понятное название и можно понять что они делают, как и переменные.

В файле DB хранится основа подключения к базе данных. Там можно менять параметры для вашей бд.

Для локального подключения к БД я пользовался программой XAMPP.