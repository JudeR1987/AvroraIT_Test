
-- 1. Создание таблиц базы данных «Исследование» - Researche

-- удаление существующих вариантов таблиц
print(char(13) + N'*** Удаление существующих таблиц:' + char(13));

-- первой удаляем таблицы у которых есть внешние ключи
print(N'*** Удаление таблицы ORDTASK ***');
drop table if exists dbo.ORDTASK;

print(char(9) + N'OK' + char(13));

print(N'*** Удаление таблицы ORDERS ***');
drop table if exists dbo.ORDERS;

print(char(9) + N'OK' + char(13));


-- создание таблиц - сначала те, у которых нет внешнего ключа
print(char(13) + N'*** Создание таблицы ORDERS ***' + char(13));
CREATE TABLE [dbo].[ORDERS] (
    [ORDNO]   NVARCHAR (7)  NOT NULL,
    [USRNAME] NVARCHAR (50) NOT NULL,
    
    PRIMARY KEY CLUSTERED ([ORDNO] ASC),
    CONSTRAINT AK_ORDERS_ORDNO UNIQUE NONCLUSTERED ([ORDNO])
);
go
print(char(9) + N'OK' + char(13));

print(char(13) + N'*** Создание таблицы ORDTASK ***' + char(13));
CREATE TABLE [dbo].[ORDTASK] (
    [TESTCODE] INT NOT NULL, 
    [ORDNO]    NVARCHAR(7) NOT NULL, 
    [TESTNAME] NVARCHAR(150) NOT NULL, 
    
    CONSTRAINT [FK_ORDTASK_ORDERS] FOREIGN KEY ([ORDNO]) REFERENCES [ORDERS]([ORDNO])
);
go
print(char(9) + N'OK' + char(13));


-- 2. Заполнение таблиц базы данных «Исследование» - Researche
print(char(13) + N'*** Заполнение таблиц базы данных Researche ***' + char(13));

-- запись данных в таблицу ORDERS
print(char(13) + N'*** Вставка записей в таблицу ORDERS ***' + char(13));
INSERT INTO [dbo].[ORDERS]
    ([ORDNO], [USRNAME])
VALUES
    (N'A000234', N'Носов А.Н.'),        --  1
    (N'A000766', N'Ольховская В.А.'),   --  2
    (N'A000908', N'Патько Е.Д.'),       --  3
    (N'A100040', N'Ямал И.В.'),         --  4
    (N'B001009', N'Кочерга И.А.'),      --  5
    (N'B001115', N'Ямал И.В.'),         --  6
    (N'C002185', N'Марченко Т.Д.'),     --  7
    (N'C002346', N'Макаренко В.Л.'),    --  8
    (N'C002421', N'Ольховская В.А.'),   --  9
    (N'C002620', N'Комарова И.А.'),     -- 10
    (N'C002622', N'Комарова И.А.'),     -- 11
    (N'C002654', N'Вороненко Д.О.'),    -- 12
    (N'C002656', N'Галушко Н.В.'),      -- 13
    (N'D004109', N'Кондрашова В.Е.'),   -- 14
    (N'D005912', N'Ольховская В.А.');   -- 15
go
print(char(9) + N'OK' + char(13));

-- запись данных в таблицу ORDTASK
print(char(13) + N'*** Вставка записей в таблицу ORDTASK ***' + char(13));
INSERT INTO [dbo].[ORDTASK]
    ([TESTCODE], [ORDNO], [TESTNAME])
VALUES
    (   234, N'A000234', N'какой-то тест №234'),                        --  1
    (   908, N'A000908', N'какой-то тест №908'),                        --  2
    (  1009, N'B001009', N'какой-то тест №1009'),                       --  3
    (  1115, N'B001115', N'какой-то тест №1115'),                       --  4
    (  2620, N'C002620', N'Измерения разности напряжения, тест №2620'), --  5
    (  4109, N'D004109', N'какой-то тест №4109'),                       --  6
    (  4110, N'D004109', N'какой-то тест №4110'),                       --  7
    (  5912, N'D005912', N'какой-то тест №5912'),                       --  8
    (   909, N'A000908', N'Измерения радиусов, тест №909'),             --  9
    (  4111, N'D004109', N'какой-то тест №4111'),                       -- 10
    (  1116, N'B001115', N'Измерения температуры, тест №1116'),         -- 11
    (  1117, N'B001115', N'какой-то тест №1117'),                       -- 12
    (  2346, N'C002346', N'какой-то тест №2346'),                       -- 13
    (  2347, N'C002346', N'Измерения уклона, тест №2347'),              -- 14
    (  2348, N'C002346', N'какой-то тест №2348'),                       -- 15
    (100040, N'A100040', N'Измерения радиусов, тест №100040'),          -- 16
    (  2656, N'C002656', N'какой-то тест №2656'),                       -- 17
    (  2421, N'C002421', N'Измерения нагрева, тест №2421'),             -- 18
    (  4112, N'D004109', N'какой-то тест №4112'),                       -- 19
    (  4113, N'D004109', N'какой-то тест №4113'),                       -- 20
    (   910, N'A000908', N'какой-то тест №910'),                        -- 21
    (   235, N'A000234', N'Измерения режущей поверхности, тест №235'),  -- 22
    (100041, N'A100040', N'Измерения радиусов, тест №100041'),          -- 23
    (  2185, N'C002185', N'Измерения упругости, тест №2185'),           -- 24
    (  2657, N'C002656', N'Измерения наклона, тест №2657');             -- 25
go
print(char(9) + N'OK' + char(13));


-- 3. Запросы к таблицам базы данных «Исследование» - Researche

-- ORDERS
select
    *
from
    ORDERS;
go
print(char(9) + N'OK' + char(13));

-- ORDTASK
select
    *
from
    ORDTASK;
go
print(char(9) + N'OK' + char(13));

-- 1) вывести все образцы и испытания по ним (поля для вывода ORDNO,
--    USRNAME,TESTCODE,TESTNAME)
print(char(13) + N'*** 1. Все образцы и испытания по ним ***' + char(13));

select
    ORDERS.ORDNO
    , USRNAME
    , ISNULL(TESTCODE, 0)                        as TESTCODE
    , ISNULL(TESTNAME, N'испытание не назначено') as TESTNAME
from
    ORDERS left join ORDTASK on ORDERS.ORDNO = ORDTASK.ORDNO;
go
print(char(9) + N'OK' + char(13));


-- 2) вывести все образцы, на которые назначено испытание с кодом (TESTCODE)
--    равным 123 (поле для вывода ORDNO)
declare @code int = 4112;
print(
    char(13) + N'*** 2. Все образцы, на которые назначено испытание с кодом №' +
    CAST(@code as nvarchar(6)) + N' ***' + char(13)
);

select
    ORDTASK.ORDNO
from
    ORDTASK join ORDERS on ORDTASK.ORDNO = ORDERS.ORDNO
where
    TESTCODE = @code;
go
print(char(9) + N'OK' + char(13));


-- 3) вывести всех пользователей, которые зарегистрировали образцы,
--    на которые назначено испытание с названием начинающимся с 'Измерения р'
--    (поле для вывода USRNAME)
print(char(13) + N'*** 3. Запрос №3 ***' + char(13));

declare @testName nvarchar(50) = N'Измерения р';

select
    USRNAME
from
    ORDTASK join ORDERS on ORDTASK.ORDNO = ORDERS.ORDNO
where
    TESTNAME like (@testName + '%')
group by
    USRNAME;
go

-- для проверки
select
    USRNAME
    , TESTNAME
from
    ORDTASK join ORDERS on ORDTASK.ORDNO = ORDERS.ORDNO
where
    TESTNAME like (@testName + '%');
go
print(char(9) + N'OK' + char(13));
