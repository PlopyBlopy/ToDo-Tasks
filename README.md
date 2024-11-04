# ToDo-Tasks

## In Development

### Название приложения: ToDo Task

### Описание
Приложение позволяет создавать и управлять списком задач, отслеживая их выполнение.

### Особенности
- Реализован паттерн **MVVM**.
- Используется паттерн **Repository** для взаимодействия с базой данных.
- Применяется **EntityFrameworkCore**.
- База данных: **SQLite**.
- Используется паттерн **Dependency Injection** для управления зависимостями.
- Окна создаются с использованием паттерна **Factory**.

## Прогресс разработки
- Функционал: **20%**
- Визуализация: **20%**

### Превью приложения
[Превью приложения](https://github.com/user-attachments/assets/7e443158-47d6-409c-b0ad-7b8241512dd6)

### Планируемые функции
- Больше функциональных окон.
- Использование db PostgreSQL.
- Возможность командной работы.

### Текущие возможности
- Открытие и смена окон.
- Связь с базой данных.
- Отображение списка задач с группами в меню **Tasks**.
- Основные кнопки простого DoTo приложения.


### Особенности реализации
- **MVVM**: связь между пользовательским интерфейсом (View), свойствами и командами (ViewModel) и данными (Model).
- Связь с базой данных осуществляется через паттерн **Repository**, включая реализацию CRUD операций с помощью **EntityFrameworkCore**.
- Управление зависимостями реализовано с помощью паттерна **DI** и DI-контейнера.
- Смена окон выполняется с использованием паттерна **Factory** в **WindowsFactory**.
- Управление окнами и их жизненным циклом осуществляется через **WindowsManager**.
- XAML код окон использует шаблоны (Dictionary) для переиспользования элементов и стилей.
