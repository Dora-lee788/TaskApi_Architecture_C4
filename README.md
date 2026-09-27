# TaskApi — C4 Architecture

## О проекте

TaskApi — учебный сервис управления задачами, продолжающий ранее зафиксированную проектную тему «сервис задач».

Основная задача системы — работа с задачами через API: пользователь отправляет запросы, а система обрабатывает их и работает с данными.

## Проектная тема

Зафиксированная тема проекта — **сервис задач**.

## C4 Architecture

### Context

![C4 Level 1 — Context](<docs/TaskApi_Architecture_C4-C4 Level 1 — Context.drawio.png>)

### Container

![C4 Level 2 — Container](<docs/TaskApi_Architecture_C4-C4 Level 2 — Container.drawio.png>)

### Component

![C4 Level 3 — Component](<docs/TaskApi_Architecture_C4-C4 Level 3 — Component.drawio.png>)

## Защита проекта

- **Какую задачу решает выбранный сервис:** управление задачами через API.
- **Проектная тема:** «сервис задач».
- **Context:** показывает пользователя и систему.
- **Container:** показывает основные контейнеры и взаимодействие между ними.
- **Component:** показывает внутренние компоненты выбранного API.
- **API:** используется для обработки запросов пользователя.
- **PostgreSQL:** используется для хранения данных.
- **Дополнительный компонент:** Redis Cache используется для кэширования данных.
- **API Gateway:** используется как единая точка входа для запросов пользователя.
- **Взаимодействие:** пользователь отправляет HTTP-запрос через API Gateway, после чего запрос передаётся в TaskApi, который взаимодействует с PostgreSQL и Redis Cache.

## Исходные файлы

Редактируемая схема:

[TaskApi_Architecture_C4.drawio](docs/TaskApi_Architecture_C4.drawio)

Экспорт схемы в PDF:

[TaskApi_Architecture_C4.pdf](docs/TaskApi_Architecture_C4.drawio.pdf)
