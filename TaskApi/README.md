# TaskApi — C4 Architecture

## О проекте

TaskApi — учебный сервис управления задачами, продолжающий ранее зафиксированную проектную тему «сервис задач».

Основная задача системы — работа с задачами через API: пользователь отправляет запросы, а система обрабатывает их и работает с данными.

## Проектная тема

Зафиксированная тема проекта — **сервис задач**.

## C4 Architecture

### Context

[![C4 Level 1 — Context](TaskApi_Architecture_C4-C4%20Level%201%20%E2%80%94%20Context.png)](TaskApi_Architecture_C4-C4%20Level%201%20%E2%80%94%20Context.png)

### Container

[![C4 Level 2 — Container](TaskApi_Architecture_C4-C4%20Level%202%20%E2%80%94%20Container.png)](TaskApi_Architecture_C4-C4%20Level%202%20%E2%80%94%20Container.png)

### Component

[![C4 Level 3 — Component](TaskApi_Architecture_C4-C4%20Level%203%20%E2%80%94%20Component.png)](TaskApi_Architecture_C4-C4%20Level%203%20%E2%80%94%20Component.png)

## Обоснование архитектуры

**API** выбран для взаимодействия пользователя с системой и выполнения операций с задачами.

**PostgreSQL** выбран для хранения данных системы.

**Redis Cache** выбран как дополнительный компонент для кэширования данных и уменьшения количества обращений к базе данных.

**API Gateway** используется как единая точка входа для запросов пользователя и передаёт запросы к API.

## Взаимодействие компонентов

Основные компоненты взаимодействуют через HTTP-запросы и обращения к хранилищам данных. Пользовательский запрос проходит через API Gateway к API, после чего система работает с PostgreSQL и Redis Cache.

## Исходные файлы

[Редактируемая C4-схема (.drawio)](TaskApi_Architecture_C4.drawio)

[Архитектура в PDF](TaskApi_Architecture_C4.drawio.pdf)