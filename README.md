![A moody picture of a bakery window filled with baked goods. There is a heavenly light shinning upon the delicious looking treats.](https://us.123rf.com/450wm/djvstock/djvstock2305/djvstock230509854/204043462-freshly-baked-french-croissants-a-gourmet-indulgence-for-sweet-tooth-generated-by-artificial.jpg?ver=6)
# Pierre's Sweet and Savory Treats

#### An MVC application for Pierre to market his sweet and savory treats. This application has user authentication and a many-to-many relationship.
#### By Suzanne Schuber

## Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* Identity
* C# 
* MySQL Database
* HTML
* CSS
* Git
* Razor Views

## This application has user authentication where the user is able to log in and log out. 

* Only logged in users have create, update, and delete functionality. 
* All users have read functionality.
* There is a many-to-many relationship between Treats and Flavors. A treat can have many flavors and a flavor can have many treats.
* A user can navigate to a splash page that lists all treats and flavors.   * All users are able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

## Setup/Installation Requirements 

1. Clone this repo.
2. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's root directory called "TreatShop.Solutions"
3. Add a .gitignore file to root directory.
5. add obj, bin, and appsettings.json to .gitignore file.
6. Within the production directory "TreatShop", create a new file called appsettings.json.
7. Within appsettings.json, put in the following code, replacing the database, uid and pwd values with your own database name, username and password for MySQL.
``````
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
``````
8. Run database migrations to create the required tables by executing the following commands in the terminal:
``````
$ dotnet ef migrations add Initial
``````

``````
$ dotnet ef database update
``````

19. Within the production directory "TreatShop", run dotnet watch run in the command line to start the project in development mode with a watcher.

## Known Bugs
I was unable to get the "Unauthorized" page to work. When you are logged in everything works as it should. If you are not logged in you are not able to Create, Update, or Delete but instead of it directing to the "Unauthorized.cshtml" you get a 404 error that says "This localhost page can’t be found."

## License
MIT License

Copyright (c) 2023 Suzanne Schuber

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.