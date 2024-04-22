-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Апр 22 2024 г., 19:33
-- Версия сервера: 10.4.28-MariaDB
-- Версия PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `studyapp`
--

-- --------------------------------------------------------

--
-- Структура таблицы `furniture_accounting`
--

CREATE TABLE `furniture_accounting` (
  `ID_Furniture` int(11) NOT NULL,
  `Furniture_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ID_Room` int(11) DEFAULT NULL,
  `Status` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `furniture_accounting`
--

INSERT INTO `furniture_accounting` (`ID_Furniture`, `Furniture_name`, `ID_Room`, `Status`) VALUES
(1243213, 'Стол', 3, 'Открутились винты');

-- --------------------------------------------------------

--
-- Структура таблицы `grade`
--

CREATE TABLE `grade` (
  `ID_Grade` int(11) NOT NULL,
  `ID_Student` int(11) DEFAULT NULL,
  `ID_Task` int(11) DEFAULT NULL,
  `Evaluation` int(11) DEFAULT NULL,
  `Comments` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `room`
--

CREATE TABLE `room` (
  `ID_Room` int(11) NOT NULL,
  `Room_number` varchar(50) DEFAULT NULL,
  `Floor` int(11) DEFAULT NULL,
  `Status` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `room`
--

INSERT INTO `room` (`ID_Room`, `Room_number`, `Floor`, `Status`) VALUES
(1, '402', 4, 'Сломана дверь'),
(2, '401', 4, 'Не работает компьютер'),
(3, '403', 4, 'Появилась большая трещина'),
(4, '404', 4, '0'),
(5, '304', 3, '0'),
(6, '101', 1, '0');

-- --------------------------------------------------------

--
-- Структура таблицы `students_group`
--

CREATE TABLE `students_group` (
  `ID_Group` int(11) NOT NULL,
  `Name_group` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `students_group`
--

INSERT INTO `students_group` (`ID_Group`, `Name_group`) VALUES
(2, '20ИТ-МО(исбд-1)');

-- --------------------------------------------------------

--
-- Структура таблицы `subject`
--

CREATE TABLE `subject` (
  `ID_Subject` int(11) NOT NULL,
  `Subject_name` varchar(255) DEFAULT NULL,
  `ID_User` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `subject`
--

INSERT INTO `subject` (`ID_Subject`, `Subject_name`, `ID_User`) VALUES
(1, 'Практика', 5),
(2, 'Практика', 4),
(3, 'Практика', 3);

-- --------------------------------------------------------

--
-- Структура таблицы `task`
--

CREATE TABLE `task` (
  `ID_Task` int(11) NOT NULL,
  `ID_Subject` int(11) NOT NULL,
  `Task_info` text DEFAULT NULL,
  `Due_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `timetable`
--

CREATE TABLE `timetable` (
  `ID_Timetable` int(11) NOT NULL,
  `ID_Group` int(11) DEFAULT NULL,
  `ID_Room` int(11) DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `Time_start` time DEFAULT NULL,
  `Time_end` time DEFAULT NULL,
  `Location` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ID_Subject` int(11) DEFAULT NULL,
  `Cancel` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `timetable`
--

INSERT INTO `timetable` (`ID_Timetable`, `ID_Group`, `ID_Room`, `Date`, `Time_start`, `Time_end`, `Location`, `ID_Subject`, `Cancel`) VALUES
(2, 2, 4, '2024-04-21', '10:30:00', '12:00:00', 'Универ', 3, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `ID_User` int(11) NOT NULL,
  `Login` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Password` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Root` int(10) UNSIGNED NOT NULL,
  `Name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Surname` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Birthday` date DEFAULT NULL,
  `Phone_number` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`ID_User`, `Login`, `Password`, `Root`, `Name`, `Surname`, `Birthday`, `Phone_number`, `Email`) VALUES
(1, 'admin', 'admin', 1, '0', '0', NULL, NULL, NULL),
(2, 'kirill2001', 'yFEM4FAR', 1, '0', '0', NULL, NULL, NULL),
(3, 'z', 'z', 0, '0', '0', NULL, NULL, NULL),
(4, 'zz', 'zz', 0, '0', '0', NULL, NULL, NULL),
(5, 'aaa', 'aaa', 0, '', '', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `users_student_group`
--

CREATE TABLE `users_student_group` (
  `ID_User` int(11) NOT NULL,
  `ID_Group` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `users_student_group`
--

INSERT INTO `users_student_group` (`ID_User`, `ID_Group`) VALUES
(2, 2),
(3, 2),
(3, 2),
(4, 2);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `furniture_accounting`
--
ALTER TABLE `furniture_accounting`
  ADD PRIMARY KEY (`ID_Furniture`),
  ADD KEY `ID_Room` (`ID_Room`);

--
-- Индексы таблицы `grade`
--
ALTER TABLE `grade`
  ADD PRIMARY KEY (`ID_Grade`),
  ADD KEY `ID_Task` (`ID_Task`),
  ADD KEY `ID_Student` (`ID_Student`);

--
-- Индексы таблицы `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`ID_Room`);

--
-- Индексы таблицы `students_group`
--
ALTER TABLE `students_group`
  ADD PRIMARY KEY (`ID_Group`);

--
-- Индексы таблицы `subject`
--
ALTER TABLE `subject`
  ADD PRIMARY KEY (`ID_Subject`),
  ADD KEY `ID_User` (`ID_User`);

--
-- Индексы таблицы `task`
--
ALTER TABLE `task`
  ADD PRIMARY KEY (`ID_Task`),
  ADD KEY `ID_Subject` (`ID_Subject`);

--
-- Индексы таблицы `timetable`
--
ALTER TABLE `timetable`
  ADD PRIMARY KEY (`ID_Timetable`),
  ADD KEY `ID_Group` (`ID_Group`),
  ADD KEY `ID_Room` (`ID_Room`),
  ADD KEY `ID_Subject` (`ID_Subject`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID_User`) USING BTREE;

--
-- Индексы таблицы `users_student_group`
--
ALTER TABLE `users_student_group`
  ADD KEY `ID_Group` (`ID_Group`),
  ADD KEY `ID_User` (`ID_User`);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `furniture_accounting`
--
ALTER TABLE `furniture_accounting`
  ADD CONSTRAINT `furniture_accounting_ibfk_1` FOREIGN KEY (`ID_Room`) REFERENCES `room` (`ID_Room`);

--
-- Ограничения внешнего ключа таблицы `grade`
--
ALTER TABLE `grade`
  ADD CONSTRAINT `grade_ibfk_1` FOREIGN KEY (`ID_Task`) REFERENCES `task` (`ID_Task`),
  ADD CONSTRAINT `grade_ibfk_2` FOREIGN KEY (`ID_Student`) REFERENCES `users` (`ID_User`);

--
-- Ограничения внешнего ключа таблицы `subject`
--
ALTER TABLE `subject`
  ADD CONSTRAINT `subject_ibfk_1` FOREIGN KEY (`ID_User`) REFERENCES `users` (`ID_User`);

--
-- Ограничения внешнего ключа таблицы `task`
--
ALTER TABLE `task`
  ADD CONSTRAINT `task_ibfk_1` FOREIGN KEY (`ID_Subject`) REFERENCES `subject` (`ID_Subject`);

--
-- Ограничения внешнего ключа таблицы `timetable`
--
ALTER TABLE `timetable`
  ADD CONSTRAINT `timetable_ibfk_1` FOREIGN KEY (`ID_Group`) REFERENCES `students_group` (`ID_Group`),
  ADD CONSTRAINT `timetable_ibfk_2` FOREIGN KEY (`ID_Room`) REFERENCES `room` (`ID_Room`),
  ADD CONSTRAINT `timetable_ibfk_3` FOREIGN KEY (`ID_Subject`) REFERENCES `subject` (`ID_Subject`);

--
-- Ограничения внешнего ключа таблицы `users_student_group`
--
ALTER TABLE `users_student_group`
  ADD CONSTRAINT `users_student_group_ibfk_1` FOREIGN KEY (`ID_Group`) REFERENCES `students_group` (`ID_Group`),
  ADD CONSTRAINT `users_student_group_ibfk_2` FOREIGN KEY (`ID_User`) REFERENCES `users` (`ID_User`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
