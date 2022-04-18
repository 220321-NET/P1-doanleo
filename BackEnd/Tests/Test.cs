using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Models;

namespace Tests;

public class Test
{
    [Fact]
    public void CheckCustomerNameDefault()
    {
        Customer c = new Customer();

        Assert.Equal("Guest", c.username);
    }
    [Fact]
    public void CheckCustomerPasswordDefault()
    {
        Customer c = new Customer();

        Assert.Equal("", c.password);
    }
    [Fact]
    public void CheckCustomerEmployee()
    {
        Customer c = new Customer();
        Assert.True(!c.isEmployee);
    }
    [Theory]
    [InlineData("")]
    [InlineData("tester")]
    [InlineData(null)]
    public void CheckCustomerNameTester(string input)
    {
        Customer c = new Customer();
        c.username = input;
        Assert.Equal(input, c.username);
    }
    [Theory]
    [InlineData("")]
    [InlineData("tester")]
    [InlineData(null)]
    public void CheckCustomerPasswordTester(string input)
    {
        Customer c = new Customer();
        c.password = input;
        Assert.Equal(input, c.password);
    }
    [Fact]
    public void DefaultStore()
    {
        Storefront s = new Storefront();
        Assert.Equal(1, s.StoreID);
        Assert.Equal("The Apple Store", s.StoreName);
    }
    [Theory]
    [InlineData("")]
    [InlineData("tester")]
    [InlineData(null)]
    public void CheckStoreName(string input)
    {
        Storefront s = new Storefront();
        s.StoreName = input;
        Assert.Equal(input, s.StoreName);
    }
    [Fact]
    public void DefaultOrder()
    {
        Order o = new Order();
        Assert.Equal(0, o.OrderID);
        Assert.Equal(0, o.OrderNum);
        Assert.Equal(0, o.OrderAmount);
        Assert.Equal(0, o.OrderTotalCost);
        Assert.Equal("Apple", o.OrderProduct);
        Assert.Equal("The Apple Store", o.OrderStore);
        Assert.Equal("Guest", o.OrderCust);
    }
    [Fact]
    public void DefaultProduct()
    {
        Product p = new Product();
        Assert.Equal("Apple", p.ProdName);
    }
    [Theory]
    [InlineData(-2.6f)]
    [InlineData(0)]
    [InlineData(100)]
    [InlineData(2.03d)]
    [InlineData(4564132321.1321654)]
    public void priceValidation(double d)
    {
        Product p = new Product();
        p.ProdCost = d;
        Assert.Equal(d, p.ProdCost);
    }
}