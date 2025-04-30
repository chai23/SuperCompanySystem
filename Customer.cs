using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超好企業系統
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Telephone { get; set; }
        public string BillForm {  get; set; }
        public string Invoice { get; set; }
        public string BillAddress { get; set; }
        public string CollectMoney { get; set; }
        public string Bucket { get; set; }
        public string Remain { get; set; }
        public string Area_id { get; set; }
        public string Area_id_2 { get; set; }
        public string Company { get; set; }
        public string Remark { get; set; }
        public string CustomerIDMark { get; set; }
        public string OldRemain { get; set; }
        public string OldBucket { get; set; }
        public string AddDay { get; set; }

        public Customer(string id, string name, string address, string contactperson, string phone, string telephone, string billform, string invoice, string billaddress, string collectmoney, string bucket, string remain, string area_id, string area_id_2, string company, string remark, string customerIDmark, string oldRemain, string oldBucket, string addDay)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.ContactPerson = contactperson;
            this.Phone = phone;
            this.Telephone = telephone;
            this.BillForm = billform;
            this.Invoice = invoice;
            this.BillAddress = billaddress;
            this.CollectMoney = collectmoney;
            this.Bucket = bucket;
            this.Remain = remain;
            this.Area_id = area_id;
            this.Area_id_2 = area_id_2;
            this.Company = company;
            this.Remark = remark;
            this.CustomerIDMark = customerIDmark;
            this.OldRemain = oldRemain;
            this.OldBucket = oldBucket;
            this.AddDay = addDay;
        }
    }

    public class Area
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Driver { get; set; }
        public string DeliverDay { get; set; }

        public Area(string id, string name, string driver, string deliverday)
        {
            this.Id = id;
            this.Name = name;
            this.Driver = driver;
            this.DeliverDay = deliverday;
        }
    }

    public class Driver
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string OrderNum { get; set; }
        public string OrderQuantity { get; set; }

        public Driver(string id, string name, string address, string contactperson, string telephone, string ordernum, string orderquantity)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.ContactPerson = contactperson;
            this.Telephone = telephone;
            this.OrderNum = ordernum;
            this.OrderQuantity = orderquantity;
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Cost { get; set; }
        public string Price { get; set; }
        public string Reserve { get; set; }
        public bool IsJoinReserve { get; set; }
        public bool Special {  get; set; }
        public bool IsJoinTex { get; set; }
        public bool IsJoinBucket { get; set; }
        public bool IsJoinRemain { get; set; }

        public Product(string id, string name, string unit, string cost, string price, string reserve, bool isjoinreserve, bool special, bool isjointex, bool isjoinbucket, bool isjoinremain)
        {
            this.Id = id;
            this.Name = name;
            this.Unit = unit;
            this.Cost = cost;
            this.Price = price;
            this.Reserve = reserve;
            this.IsJoinReserve = isjoinreserve;
            this.Special = special;
            this.IsJoinTex = isjointex;
            this.IsJoinBucket = isjoinbucket;
            this.IsJoinRemain = isjoinremain;
        }
    }

    public class Order
    {
        public string Id { get; set; }
        public string Day { get; set; }
        public string ProductIndex { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string GiveFree { get; set; }
        public string GiveNoFree { get; set; }
        public string Tex { get; set; }
        public string SubTotal { get; set; }
        public string Remark { get; set; }
        public string Customer { get; set; }
        public string CustomerBillForm { get; set; }
        public string Driver { get; set; }
        public string IsOK { get; set; }
        public string RecycleQuantity { get; set; }
        public string CollectMoney { get; set; }
        public string CollectOK { get; set; }
        public string Assign_OK { get; set; }
        public string DriverChange { get; set; }
        public string BillNumber { get; set; }
        public string Order_id_day {  get; set; }
        public string Maker {  get; set; }

        public Order(string id, string day, string productindex, string productid, string productname,string price, string quantity, string givefree, string givenofree,string tex, string subtotal, string remark, string customer, string customerbillform, string driver, string isOK, string recyclequantity, string collectmoney, string collectok, string assignok, string driverchange, string billnumber, string orderidday, string maker )
        {
            this.Id = id;
            this.Day = day;
            this.ProductIndex = productindex;
            this.ProductID = productid;
            this.ProductName = productname;
            this.Price = price;
            this.Quantity = quantity;
            this.GiveFree = givefree;
            this.GiveNoFree = givenofree;
            this.Tex = tex;
            this.SubTotal = subtotal;
            this.Remark = remark;
            this.Customer = customer;
            this.CustomerBillForm = customerbillform;
            this.Driver = driver;
            this.IsOK = isOK;
            this.RecycleQuantity = recyclequantity;
            this.CollectMoney = collectmoney;
            this.CollectOK = collectok;
            this.Assign_OK = assignok;
            this.DriverChange = driverchange;
            this.BillNumber = billnumber;
            this.Order_id_day = orderidday;
            this.Maker = maker;
        }
    }

    public class Announcement
    {
        public string Id { get; set; }
        public string Day { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AnnUsing { get; set; }

        public Announcement(string id, string day, string title, string content, string annusing)
        {
            this.Id = id;
            this.Day = day;
            this.Title = title;
            this.Content = content;
            this.AnnUsing = annusing;
    }
    }

    public class PrintOrder
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductQuantity { get; set; }
        public string ProductPrice { get; set; }
        public string Subtotal { get; set; }
    }

    public class PrintCustomer
    {
        public string Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_address { get; set; }
        public string Customer_remark { get; set; }
        public string Customer_invoice { get; set; }
        public string Customer_telephone { get; set; }
        public string Order_id { get; set; }
        public string Date { get; set; }
        public string Product_remark { get; set; }
        public string Total { get; set; }
        public string Announcement { get; set; }
        public string Driver_name { get; set; }
        public string Remain { get; set; }
        public string Bucket { get; set; }
        public string LastTimeQuantity { get; set; }
        public string LastTimeOrderDay { get; set; }
        public string Tex { get; set; }
    }

    public class PrintMonthOrder
    {
        public string Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_telephone { get; set; }
        public string Customer_bill_form { get; set; }
        public string Customer_invoice { get; set; }
        public string Print_date { get; set; }
        public string Order_date { get; set; }
        public string Order_id { get; set; }
        public string Subtotal { get; set; }
        public string Total { get; set; }
        public string Print_people { get; set; }
        public string Driver_name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
