# Couponel

The purpose of this project is to make a website to manage the coupons.

We have 2 servers:
- front-end server (using angular) (port 4200)
- back-end (using ASP.NET) (port 5001)

These servers communicate with REST/API.

![Project Diagram](https://github.com/enaky/Couponel/blob/Co-54/Documentation/architecture/front-back-diagram.png)


## Configure The Project
1. [Install Microsoft Sql Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
2. [Install SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/)
3. [Install Angular CLI](https://angular.io/guide/setup-local)
4. [Make sure you have .NET and ASP.NET configured in Visual Studio](https://www.geeksforgeeks.org/how-to-install-and-setup-visual-studio-for-asp-net/)
5. Open **Package Manager Console** in Visual Studio (make sure the Default Project is Couponel.Persistence) and run ```add-migration Migration-v01``` to create the migration.
6. Run ```update-database``` to generate Couponel Database using the created migration (you can see it in *SQL Server Managem Studio*)
> `Optional`: Populate the database running script ***reinitialize_data.bat*** from Scripts folder. Created users have the password identical to their username.

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