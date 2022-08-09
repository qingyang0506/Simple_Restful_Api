# Simple_Restful_Api

This is the simple Web api to implement the CRUD operations and call the third party Api.

The EmployeeController will handle the CRUD operation of the Employee table in the database

The DigimonController will handle the data which is retrieve from calling the third party Api.

The ManagerController will use for the Unit testing.



we use the some middlewares such as AddControllers, AddDbContext, With them, we can put our database objects or controllers etc. into server containers, create the required objects automatically when the project starts and pass them on via dependency injection, thus simplifying our code and increasing its reuse.



The middleware UseHttpRedirection and MapControllers are useful tools for http request. They can aid to recognise the routers you write in controller and can implement the matching methods, which is helpful to us to test these methods.
