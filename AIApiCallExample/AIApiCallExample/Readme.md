# 🧩 .NET MVC Application – Environment Configuration Demo

## 📌 Overview

This project is a **.NET MVC web application** that demonstrates how to:

* Read values from **environment variables**
* Use **IOptions (strongly typed configuration)**
* Inject services using **Dependency Injection**
* Display values in a **Razor View using ViewBag**

---

## 🏗️ Project Structure

```
MyApp/
│
├── Controllers/
│   └── UserController.cs
│
├── Services/
│   └── MyService.cs
│
├── Models/
│   └── UserSettings.cs
│
├── Views/
│   └── User/
│       └── Index.cshtml
│
├── appsettings.json
├── Program.cs
└── README.md
```

---

## ⚙️ Prerequisites

* .NET 8 / .NET 9 / .NET 10 SDK
* Visual Studio / VS Code

---

## 🚀 Getting Started

### 1️⃣ Clone the Repository

```
git clone <your-repo-url>
cd MyApp
```

---

### 2️⃣ Set Environment Variable

#### ▶ Windows (PowerShell)

```
$env:MySettings__ApiKey="MyLocalValue"
```

#### ▶ Windows (Permanent)

```
setx MySettings__ApiKey "MyLocalValue"
```

#### ▶ Mac/Linux

```
export MySettings__ApiKey="MyLocalValue"
```

---

### 3️⃣ Run the Application

```
dotnet run
```

---

### 4️⃣ Open in Browser

```
https://localhost:5001/api/user
```

---

## 🔧 Configuration

### secrets.json (Optional)

```
{
  "MySettings": {
    "ApiKey": "DefaultValue"
  }
}
```

👉 Environment variables override this value.

---

## 💡 Implementation Details

### 🔹 UserSettings.cs

```
public class UserSettings
{
    public string ApiKey { get; set; }
}
```

---

### 🔹 MyService.cs

```
public class MyService
{
    private readonly string _apiKey;

    public MyService(IOptions<MySettings> options)
    {
        _apiKey = options.Value.ApiKey;
    }

    public string GetApiKey()
    {
        return _apiKey;
    }
}
```

---

### 🔹 UserController.cs

```
public class UserController : Controller
    {
        private static MyService _myService;
        public UserController(MyService myService)
        {
            _myService = myService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var apiKey = _myService.GetApiKey();
            ViewBag.apiKey = apiKey;
            return View();
        }
    }
```

---

### 🔹 Get.cshtml

```
<h2>API Key Value</h2>
<p>@ViewBag.ApiKey</p>
```

---

## 🧪 Key Concepts Used

* Dependency Injection (DI)
* IConfiguration & IOptions
* Environment Variables
* Razor Views (.cshtml)
* ViewBag (dynamic data passing)

---

## 🔥 Best Practices

* ✅ Use **Environment Variables** for secrets
* ✅ Prefer **Strongly Typed Models** over ViewBag
* ✅ Keep Controllers thin (business logic in services)
* ❌ Do not store secrets in `appsettings.json`

---

## 📈 Future Enhancements

* Replace ViewBag with strongly typed ViewModel
* Add database integration (EF Core)
* Add logging & exception handling
* Integrate with Angular frontend

---

## 👨‍💻 Author

* Developed as a learning/demo project for .NET MVC architecture

---
