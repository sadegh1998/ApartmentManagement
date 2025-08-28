# پیاده‌سازی کامل Expense و ExpenseUnit

## 📋 **خلاصه پیاده‌سازی**

این مستندات پیاده‌سازی کامل بخش‌های **Expense** و **ExpenseUnit** در سیستم مدیریت آپارتمان Modirsa را توضیح می‌دهد.

## 🏗️ **معماری پیاده‌سازی شده**

### **1. Domain Layer**
- **Expenses Entity**: موجودیت اصلی هزینه‌ها
- **ExpenseUnits Entity**: موجودیت تخصیص هزینه به واحدها
- **EntityBase**: کلاس پایه برای تمام موجودیت‌ها

### **2. Application Layer**
- **Commands**: Create, Edit, Delete
- **Queries**: GetAll, GetById, Search
- **Handlers**: پیاده‌سازی منطق کسب و کار
- **Validation**: اعتبارسنجی ورودی‌ها
- **AutoMapper**: تبدیل بین Domain و ViewModels

### **3. Infrastructure Layer**
- **Repositories**: دسترسی به داده
- **DbContext**: تنظیمات Entity Framework
- **Mappings**: تنظیمات ORM

### **4. Presentation Layer**
- **API Controllers**: RESTful endpoints
- **DTOs**: انتقال داده

## 📁 **ساختار فایل‌های ایجاد شده**

### **Commands**
```
src/Application/Feature/Command/Expense/
├── CreateExpense/
│   ├── CreateExpenseCommand.cs
│   ├── CreateExpenseHandler.cs
│   └── CreateExpenseCommandValidator.cs
├── EditExpense/
│   ├── EditExpenseCommand.cs
│   ├── EditExpenseHandler.cs
│   └── EditExpenseCommandValidator.cs
└── DeleteExpense/
    ├── DeleteExpenseCommand.cs
    └── DeleteExpenseHandler.cs
```

```
src/Application/Feature/Command/ExpenseUnit/
├── CreateExpenseUnit/
│   ├── CreateExpenseUnitCommand.cs
│   ├── CreateExpenseUnitHandler.cs
│   └── CreateExpenseUnitCommandValidator.cs
├── EditExpenseUnit/
│   ├── EditExpenseUnitCommand.cs
│   ├── EditExpenseUnitHandler.cs
│   └── EditExpenseUnitCommandValidator.cs
└── DeleteExpenseUnit/
    ├── DeleteExpenseUnitCommand.cs
    └── DeleteExpenseUnitHandler.cs
```

### **Queries**
```
src/Application/Feature/Query/Expense/
├── GetAllExpenses/
│   ├── GetAllExpensesQuery.cs
│   ├── GetAllExpensesHandler.cs
│   └── ExpenseViewModel.cs
├── GetExpenseById/
│   ├── GetExpenseByIdQuery.cs
│   ├── GetExpenseByIdHandler.cs
│   └── ExpenseViewModel.cs
└── SearchExpenses/
    ├── SearchExpensesQuery.cs
    ├── SearchExpensesHandler.cs
    └── ExpenseViewModel.cs
```

```
src/Application/Feature/Query/ExpenseUnit/
├── GetAllExpenseUnits/
│   ├── GetAllExpenseUnitsQuery.cs
│   ├── GetAllExpenseUnitsHandler.cs
│   └── ExpenseUnitViewModel.cs
├── GetExpenseUnitById/
│   ├── GetExpenseUnitByIdQuery.cs
│   ├── GetExpenseUnitByIdHandler.cs
│   └── ExpenseUnitViewModel.cs
└── GetExpenseUnitsByExpenseId/
    ├── GetExpenseUnitsByExpenseIdQuery.cs
    ├── GetExpenseUnitsByExpenseIdHandler.cs
    └── ExpenseUnitViewModel.cs
```

### **Controllers**
```
Modirsa.Presentation/ModisaApp.API/Controllers/
├── ExpenseController.cs
└── ExpenseUnitController.cs
```

## 🔧 **ویژگی‌های پیاده‌سازی شده**

### **Expense Management**
- ✅ ایجاد هزینه جدید
- ✅ ویرایش هزینه موجود
- ✅ حذف هزینه
- ✅ دریافت تمام هزینه‌ها
- ✅ دریافت هزینه بر اساس ID
- ✅ جستجوی پیشرفته هزینه‌ها

### **ExpenseUnit Management**
- ✅ تخصیص هزینه به واحد
- ✅ ویرایش تخصیص هزینه
- ✅ حذف تخصیص هزینه
- ✅ دریافت تمام تخصیص‌ها
- ✅ دریافت تخصیص بر اساس ID
- ✅ دریافت تخصیص‌های یک هزینه خاص

### **Validation**
- ✅ اعتبارسنجی مبلغ (بزرگتر از صفر)
- ✅ اعتبارسنجی تاریخ (نمی‌تواند در آینده باشد)
- ✅ اعتبارسنجی توضیحات (حداکثر 500 کاراکتر)
- ✅ اعتبارسنجی روش تخصیص (حداکثر 100 کاراکتر)

### **Search & Filtering**
- ✅ جستجو بر اساس توضیحات
- ✅ فیلتر بر اساس ساختمان
- ✅ فیلتر بر اساس بازه تاریخ
- ✅ فیلتر بر اساس بازه مبلغ

## 🌐 **API Endpoints**

### **Expense Controller**
```
GET    /api/Expense/GetAllExpenses
GET    /api/Expense/GetExpenseById?id={id}
GET    /api/Expense/SearchExpenses?description={desc}&buildingId={id}&fromDate={date}&toDate={date}&minAmount={amount}&maxAmount={amount}
POST   /api/Expense/CreateExpense
PUT    /api/Expense/EditExpense
DELETE /api/Expense/DeleteExpense?id={id}
```

### **ExpenseUnit Controller**
```
GET    /api/ExpenseUnit/GetAllExpenseUnits
GET    /api/ExpenseUnit/GetExpenseUnitById?id={id}
GET    /api/ExpenseUnit/GetExpenseUnitsByExpenseId?expenseId={id}
POST   /api/ExpenseUnit/CreateExpenseUnit
PUT    /api/ExpenseUnit/EditExpenseUnit
DELETE /api/ExpenseUnit/DeleteExpenseUnit?id={id}
```

## 🗄️ **Database Schema**

### **Expenses Table**
```sql
CREATE TABLE Expenses (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    BuildingId UNIQUEIDENTIFIER NOT NULL,
    Description NVARCHAR(500) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    DateIncurred DATETIME2 NOT NULL,
    AllocationMethod NVARCHAR(100) NOT NULL,
    CreationDate DATETIME2 NOT NULL,
    FOREIGN KEY (BuildingId) REFERENCES Buildings(Id)
);
```

### **ExpenseUnits Table**
```sql
CREATE TABLE ExpenseUnits (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    AmountDue DECIMAL(18,2) NOT NULL,
    ExpenseId UNIQUEIDENTIFIER NOT NULL,
    UnitId UNIQUEIDENTIFIER NOT NULL,
    CreationDate DATETIME2 NOT NULL,
    FOREIGN KEY (ExpenseId) REFERENCES Expenses(Id),
    FOREIGN KEY (UnitId) REFERENCES Units(Id)
);
```

## 🔄 **AutoMapper Profiles**

### **ExpenseProfile**
- تبدیل `Expenses` به `ExpenseViewModel`
- نگاشت نام ساختمان و تعداد واحدهای هزینه

### **ExpenseUnitProfile**
- تبدیل `ExpenseUnits` به `ExpenseUnitViewModel`
- نگاشت توضیحات هزینه و نام واحد

## 🚀 **نحوه استفاده**

### **1. ایجاد هزینه جدید**
```csharp
var command = new CreateExpenseCommand
{
    BuildingId = Guid.NewGuid(),
    Description = "هزینه تعمیر آسانسور",
    Amount = 5000000,
    DateIncurred = DateTime.Now,
    AllocationMethod = "بر اساس متراژ"
};

var result = await mediator.Send(command);
```

### **2. تخصیص هزینه به واحد**
```csharp
var command = new CreateExpenseUnitCommand
{
    AmountDue = 500000,
    ExpenseId = expenseId,
    UnitId = unitId
};

var result = await mediator.Send(command);
```

### **3. جستجوی هزینه‌ها**
```csharp
var query = new SearchExpensesQuery
{
    Description = "تعمیر",
    BuildingId = buildingId,
    FromDate = DateTime.Now.AddMonths(-1),
    ToDate = DateTime.Now,
    MinAmount = 1000000,
    MaxAmount = 10000000
};

var results = await mediator.Send(query);
```

## ✅ **تست‌های پیشنهادی**

### **Unit Tests**
- تست Command Handlers
- تست Query Handlers
- تست Validation
- تست AutoMapper Profiles

### **Integration Tests**
- تست Repository Methods
- تست API Controllers
- تست Database Operations

### **End-to-End Tests**
- تست کامل workflow ایجاد هزینه
- تست تخصیص هزینه به واحدها
- تست جستجو و فیلتر

## 🔧 **نکات فنی**

### **Performance**
- استفاده از `Include` برای eager loading
- استفاده از `AsNoTracking` برای read-only queries
- پیاده‌سازی pagination برای لیست‌های بزرگ

### **Security**
- اعتبارسنجی تمام ورودی‌ها
- مدیریت خطاها و exception handling
- لاگ کردن عملیات مهم

### **Maintainability**
- جداسازی منطق کسب و کار
- استفاده از dependency injection
- کد تمیز و قابل خواندن

## 📝 **نتیجه‌گیری**

پیاده‌سازی کامل بخش‌های Expense و ExpenseUnit با موفقیت انجام شده است. این پیاده‌سازی شامل:

1. **معماری تمیز** با جداسازی لایه‌ها
2. **CQRS Pattern** برای جداسازی عملیات خواندن و نوشتن
3. **Validation** کامل برای تمام ورودی‌ها
4. **AutoMapper** برای تبدیل بین لایه‌ها
5. **Repository Pattern** برای دسترسی به داده
6. **API Controllers** کامل با تمام عملیات CRUD
7. **Error Handling** و مدیریت خطاها

این پیاده‌سازی آماده استفاده در production است و می‌تواند به عنوان پایه‌ای برای توسعه سایر بخش‌های سیستم استفاده شود.


