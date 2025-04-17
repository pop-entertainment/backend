# Описание
Сервис интернет-магазина товаров для рукоделия

Основную информацию смотрите в [документации](https://docs.google.com/document/d/1P3uVEATefHxcxj-jKH4acKeJyOVQBqeSlbtKDuyILrs/edit?usp=sharing).

## Сущности

| Сущность     | Описание                                                                     |
| ------------ |------------------------------------------------------------------------------|
| BaseEntity   | Базовая сущность. Содержит поля Id, CreatedOn, ModifiedOn |

## Используемые технологии

* AspNet 8.0
* EF.Core 9.0
* AutoMapper 14.0.0
* FluentValidation.AspNetCore 11.3
* Docker

Поддерживаемые провайдеры СУБД:

* PostgreSql

# Среды

## Local
Локальная среда на локальном компьютере.

Для локальных настроек следует использовать appsettings.local.json - данный файл не попадет в репозиторий.

Для запуска зависимостей воспользуйтесь командой

    docker-compose -f docker-compose.yaml up postgres

## Production
Среда Production на кластере. Соответствует ветке `main`

| Key | Value |
| --- | ---  |
| Ветка | `master` |
| URL |  |
| Swagger |  |

# CI/CD

Файлы определения CI/CD расположены в папке `.ci`

# Change Log

Смотрите файл [CHANGELOG.md](./CHANGELOG.md)


