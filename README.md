# Couponel

The purpose of this educational project is to make a website to manage the coupons.  
There are 3 types of users:
* **student** (access, add, use coupons)
* **offerer** (create coupons)
* **admin** (access to the statistics page)

The application is built on 2 servers:
- **front-end server** (using [angular](https://angular.io/)) (running on port 4200)
- **back-end server** (using [ASP.NET](https://dotnet.microsoft.com/apps/aspnet)) (running on port 5001)

These servers communicate with [REST/API](https://restfulapi.net/).

![Project Diagram](https://github.com/enaky/Couponel/blob/Co-54/Documentation/architecture/front-back-diagram.png)

## Back-End Notes
The back-end server is built on multi-tier-architecture:
* **Presentation Tier** (responsible for the controllers/user interface)
* **Bussiness Tier** (responsible for the logic and functionality)
* **Persistence/Database Tier** (responsible for CRUD operations)

![N-tier Architecture](https://github.com/enaky/Couponel/blob/Co-54/Documentation/diagrams/er-diagram.png)  

## E-R Diagram

![E-R Diagram](https://github.com/enaky/Couponel/blob/Co-54/Documentation/architecture/multi-tier-architecture.png)  


## Configure The Project
1. [Install Microsoft Sql Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
2. [Install SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/)
3. [Install Angular CLI](https://angular.io/guide/setup-local)
4. [Make sure you have .NET and ASP.NET configured in Visual Studio](https://www.geeksforgeeks.org/how-to-install-and-setup-visual-studio-for-asp-net/)
5. Open **Package Manager Console** in Visual Studio (make sure the Default Project is Couponel.Persistence) and run the following commands:
   * ```add-migration Migration-v01``` (to create a migration).
   * ```update-database``` (to generate Couponel Database using the created migration)  

> You can access the created database in *SQL Server Management Studio*.

> `Optional`: Populate the database running script ***reinitialize_data.bat*** from Scripts folder. Created users have the password identical to their username. (*Example*: user `mishu` has the password `mishu`)

> `Note`: Diacritics may not be read correctly because of encoding format. In that case, to fix this issue, you could copy the generated queries from ***AllInOne.sql*** from *Scripts\SqlScripts* and execute it in SQL Server Management.

## How to run the project
1. Run CouponelApp in Visual Studio
2. Run Couponel.Web with Visual Code or WebStorm:
   - ```npm install``` (to install required dependencies) (run first time)
   - ```ng serve```

## Screenshots Samples


* **`Admin Statistics Page`**  
![Admin Statistics Page](https://github.com/enaky/Couponel/blob/master/Documentation/pages/admin-page.png)


* **`Login Page`**  
![Login Page](https://github.com/enaky/Couponel/blob/master/Documentation/pages/login.png)


* **`All Vouchers Page`**  
![All Vouchers Page](https://github.com/enaky/Couponel/blob/master/Documentation/pages/all-vouchers-student-page.png)


* **`Student Redeemed Vouchers Page`**  
![Student Redeemed Vouchers Page](https://github.com/enaky/Couponel/blob/master/Documentation/pages/my-redeemed-vouchers-student-page.png)


* **`My profile Page`**  
![My profile Page](https://github.com/enaky/Couponel/blob/master/Documentation/pages/my-profile.png)


* **`Profile Edit Page`**  
![Profile Edit Page](https://github.com/enaky/Couponel/blob/master/Documentation/pages/profile-edit.png)


* **`Student Coupon Review Page`**  
![Student Coupon Review Page](https://github.com/enaky/Couponel/blob/master/Documentation/pages/student-coupon-review.png)


* **`Student Page`**  
![Student Page](https://github.com/enaky/Couponel/blob/master/Documentation/pages/student-page.png)


* **`Offerer Page`**  
![Offerer Page](https://github.com/enaky/Couponel/blob/master/Documentation/pages/offerer-page.png)