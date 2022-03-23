# P0-doanleo
P0 Requirements Due April 6th 2022

Store App
Overview
The store app is a software that helps customers purchase products from your business. Designed with functionality that would make virtual shopping much simpler!

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

------------
Notes:
------------
Use namespace to make a 'folder' of classes
    BL

    DL
lists for now but database access later
    Models
classes based on each type mentioned above
    UI
Default program, and where main will be

GOAL TOMORROW, set up all models and finish the first two menus