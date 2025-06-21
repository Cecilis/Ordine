# 🧠 Muro de Conexiones - Investigative Board App

Esta aplicación emula un **muro de conexiones visual** estilo policial, donde los usuarios pueden crear, conectar y organizar nodos (personas, eventos, lugares, ideas, etc.) dentro de tableros personalizables. Ideal para investigaciones complejas, lluvias de ideas o visualización de relaciones.

---

## 🏗️ Arquitectura

La solución está compuesta por varios microservicios, cada uno siguiendo los principios de **Clean Architecture**:

- **BoardService**: Gestión de tableros y posición de nodos.
- **NodeService**: CRUD de nodos con tipo, descripción y ubicación.
- (Próximamente) **LinkService**: Relaciones entre nodos.
- **API Gateway**: Punto de entrada único.
- Comunicación entre servicios: REST + RabbitMQ (eventualmente gRPC).

---

## 📦 Tecnologías

- **.NET 8** con ASP.NET Core
- **MongoDB** y/o PostgreSQL
- **MediatR**, **FluentValidation**, **Docker Compose**
- **Blazor WebAssembly** / Angular (Frontend en desarrollo)

---

## 🚀 Primeros pasos

1. Clona este repositorio:
   ```bash
   git clone https://github.com/tuusuario/muro-conexiones.git
