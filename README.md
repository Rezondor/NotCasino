# NotCasino - Платформа для миниигр

Платформа для миниигр в стиле казино, но с использованием баллов вместо реальных денег.

## 🎮 Функциональность

- **Регистрация и авторизация** - безопасная система аутентификации с JWT токенами
- **Выбор игр** - различные миниигры (One Arm Bandit, планируются другие)
- **Профиль пользователя** - просмотр статистики и истории игр
- **Таблица лидеров** - рейтинг игроков по выигрышам
- **Игровой процесс** - увлекательные игры с системой баллов

## 🏗️ Архитектура

Проект построен на основе **Clean Architecture** с разделением на слои:

### Core (Ядро)
- `TWD.NotCasino.Core` - модели данных, интерфейсы, DTO
- `TWD.NotCasino.Domain.Core` - контекст базы данных
- `TWD.NotCasino.Api.Core` - общие компоненты API
- `TWD.NotCasino.Games.*.Application` - бизнес-логика игр

### Infrastructure (Инфраструктура)
- `TWD.NotCasino.Base` - базовые компоненты
- `TWD.NotCasino.Domain.Base` - базовые репозитории
- `TWD.NotCasino.Domain.Base.Postgres` - PostgreSQL провайдер
- `TWD.NotCasino.Games.*.Base` - базовые компоненты игр

### Presentation (Представление)
- `TWD.NotCasino.Api` - REST API

## 🚀 Быстрый старт

### Предварительные требования

- .NET 8.0 SDK
- PostgreSQL 12+
- Visual Studio 2022 или VS Code

### Установка и запуск

1. **Клонирование репозитория**
   ```bash
   git clone <repository-url>
   cd TWD.NotCasino
   ```

2. **Настройка базы данных**
   - Создайте базу данных PostgreSQL
   - Обновите строку подключения в `appsettings.json`

3. **Настройка JWT**
   - Сгенерируйте секретный ключ для JWT
   - Обновите настройки в `appsettings.json`

4. **Запуск приложения**
   ```bash
   cd src/Presentation/TWD.NotCasino.Api
   dotnet run
   ```

5. **Открытие Swagger UI**
   - Перейдите по адресу: `https://localhost:7001/swagger`

## 📊 Модели данных

### User (Пользователь)
- Основная информация пользователя
- Хешированные пароли с солью
- JWT токены для аутентификации

### Account (Аккаунт)
- Баланс пользователя в баллах
- Связь с пользователем

### GameLog (Лог игры)
- История всех игр
- Статистика выигрышей/проигрышей
- RTP (Return to Player)

### Leaderboard (Таблица лидеров)
- Рейтинг игроков
- Статистика по типам игр

### UserStatistics (Статистика пользователя)
- Общая статистика игрока
- Время игры, процент выигрышей

## 🔐 Безопасность

- **Хеширование паролей** - BCrypt с солью
- **JWT токены** - безопасная аутентификация
- **Валидация данных** - FluentValidation
- **CORS** - настройка для веб-клиентов

## 🎯 API Endpoints

### Аутентификация
- `POST /api/auth/register` - регистрация
- `POST /api/auth/login` - вход
- `POST /api/auth/refresh` - обновление токена

### Пользователи
- `GET /api/users/profile` - профиль пользователя
- `GET /api/users/statistics` - статистика пользователя
- `PUT /api/users/profile` - обновление профиля

### Игры
- `POST /api/games/play` - играть в игру
- `GET /api/games/history` - история игр
- `GET /api/games/leaderboard` - таблица лидеров

### Аккаунт
- `GET /api/account/balance` - баланс
- `POST /api/account/deposit` - пополнение (для тестирования)

## 🎮 Добавление новых игр

1. Создайте новый проект в `src/Core/TWD.NotCasino.Games.{GameName}.Application`
2. Реализуйте интерфейс `IGameEngine`
3. Добавьте новый тип в enum `GameType`
4. Обновите контроллер игр

## 🧪 Тестирование

```bash
# Запуск тестов
dotnet test

# Запуск с покрытием
dotnet test --collect:"XPlat Code Coverage"
```

## 📝 Лицензия

MIT License

## 🤝 Вклад в проект

1. Fork репозитория
2. Создайте feature branch
3. Внесите изменения
4. Создайте Pull Request

## 📞 Поддержка

По вопросам и предложениям создавайте Issues в репозитории.