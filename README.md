# P1-doanleo

---
todo
---




sonar
serilog



?????
stock is a DTO, make a DTO Models folder and add DTO's in it
do i want have cart remove x amount? 
do i want to validate to see if x amount can be added to cart?

------------------
Big Apple Hub
------------------
A small network of stores that work closely with local Apple Orchards

There is a set list of Apples the network is allowed to sell and fixed price for said types of apples shared across all stores

------------------
Functions
------------------
The User must log in to access the store

-They can sign in with an existing account

--If the authentication fails, they are given the option to create a new account

-They can create a new account

When within the store, they are sent to the default "The Apple Store" and are given two options


-View Items in this store's stock

-View Customer's Order History across all stores

-Change Store they're at, this function is used in various menus


Upon viewing a store's inventory, they can add one of the items to their cart, remove items from the cart, check out, or change to another store

If the user is an employee, they are allowed to restock the store they're at

Upon viewing their order history, it will give the option to sort their orders, upon selecting the same sort again, it will change between ascending and descending order

If the user is an employee, they are redirected to looking at the store's orders and can change the store they're looking at. There is also an option to swap between viewing their own orders or the stores.

password to the db is appleRemote1, dont tell anyone that

------------------
Additional Requirements that I'm missing
------------------


-Logging with serilog/Nlog

True Exception Handling, kinda hardcoded in

True Input Validation, can make stock negative and restock negatives