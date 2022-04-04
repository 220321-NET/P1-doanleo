# P0-doanleo
P0 Requirements Due April 6th 2022

Store App
Overview
The store app is a software that helps customers purchase products fro
m your business. Designed with functionality that would make virtual shopping much simpler!

password to the db is appleRemote1

------------
TO-DO LIST
------------


TODO TODAY

add to cart function in irepo just removes an items stock, doesnt care if it goes negative

Select Stores.StoreName, Products.ProductName, Products.ProductCost, Stock from StoreStock
join Stores on Storestock.Storeid = stores.StoreID
join Products on storestock.ProductID = products.productid
Where StoreName = 'The Apple Store'
Order by productCost;


BEGIN SQL STATEMENTS



remcart might be broken
make all the close menus's X rather than x or 2

clean up spacing,
make a ascii logo?


lookinto sqlcommandbuilder
    set store on launch to default store
mark criteria below as complete

------------
Functionality
------------
add a new customer ("sign up")
search customers by name("log in")
view storefront inventory
place orders to a store for customers
The customer should be able to purchase multiple products
view order history of customer
view order history of location
display details of an order
Order histories should have the option to be sorted by date (latest to oldest and vice versa) or cost (least expensive to most expensive)
The manager should be able to replenish inventory

------------
Models
------------
Customer
StoreFront
Orders
Product
Note: Add as much models as you would need for your design

------------
Additional requirements
------------
Exception Handling
Input validation
At least 20 unit tests
Logging (to a file, no logging to the console)
Data should be persisted, (no data should be hard coded)
You should use a DB to store data
DB structure should be 3NF
Should have an ER Diagram
Code should have xml documentation

------------
Tech Stack
------------
C#
Xunit
SQLServer DB
ADO.NET
Serilog or Nlog (or any other logging frameworks)
