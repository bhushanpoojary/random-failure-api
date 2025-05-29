# random-failure-api
An API that randomly fails with different HTTP status codes and exceptions. Useful for testing retry policies, monitoring tools, and resilience patterns

# 🎲 randomapi - Chaos Testing API

**randomapi** is a mock API that intentionally fails in unpredictable ways — randomly throwing exceptions, returning various HTTP error codes, or timing out. It's designed to help you test:

- Retry logic
- Circuit breakers
- Timeout handling
- Monitoring and alerting systems (e.g., Application Insights, Grafana, Prometheus)
- Chaos engineering tools

---

## 🚀 Features

- Returns random HTTP status codes (e.g., 400, 401, 404, 500, 503)
- Randomly throws unhandled exceptions
- Simulates delayed responses or timeouts
- Customizable failure probabilities

---

## 📦 Example Endpoints

| Endpoint       | Description                                  |
|----------------|----------------------------------------------|
| `/random`      | Returns random status code or error          |
| `/fail`        | Always fails with a random 5xx error         |
| `/timeout`     | Simulates long-running request               |
| `/exception`   | Throws a random server-side exception        |
| `/status/:code`| Returns specified HTTP status code           |

---

## ⚙️ Setup & Run

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/)
- or [Node.js](https://nodejs.org/) / [Python](https://www.python.org/) if you're implementing it in those

### Clone and Run

```bash
git clone https://github.com/bhushanpoojary/randomapi.git
cd randomapi
dotnet run

