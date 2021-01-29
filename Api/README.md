# Web Api test task

## Installation

copy provided docker-compose.yml and customize for your needs

compile images from the sources - `docker-compose build && docker-compose up -d`

### Parameters

| Environment    | Description                |
|----------------|----------------------------|
| MSSQL_ADDRESS  | Address of Mssql instance  |
| MSSQL_PORT     | Port of Mssql instance     |
| MSSQL_USER     | User name for mssql server |
| MSSQL_PASSWORD | Password for mssql server  |

## Development

To run dependent environment use `docker-compose -f dev-compose.yml up -d --build`
