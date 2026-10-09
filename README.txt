# velora
Простой RESTful API на .NET Core для управления списком мероприятий. Реализует базовые CRUD-операции (Create, Read, Update, Delete).

## Запуск
Чтобы запустить проект, нужно выполнять набор команд, например, через git bash
1. клонировать репозиторий		git clone "https://github.com/yadrentseva/velora.git" 
2. перейти в папку с проектом	cd <название_папки>
3. собрать проект				dotnet build
4. запустить код				dotnet run

После запуска API доступно по адресу https://localhost:7015 или http://localhost:5021

## Тестирование
Для проверки работы API можно использовать Swagger https://localhost:7015/swagger или http://localhost:5021/swagger
Использование Swagger возможно только в окружении Development; окружение задается параметром ASPNETCORE_ENVIRONMENT в файле launchSettings.json

## Эндпоинты API (Маршруты)
| Метод | Эндпоинт | Описание |
| :--- | :--- | :--- |
| **GET** | `events/` | Получить список всех мероприятий |
| **GET** | `events/{id}` | Получить описание конкретного мероприятия |
| **POST** | `events/` | Добавить новое мероприятие |
| **PUT** | `events/{id}` | Обновить конкретное мероприятие |
| **DELETE** | `events/{id}` | Удалить мероприятие |