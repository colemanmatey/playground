using Invoicing.Entities;

namespace Tests
{
    public class TestInvoicingEntities
    {
        [Fact]
        public void TestCustomerModel()
        {
            var customer = new Customer();
            customer.Name = "John Doe";
            customer.Address1 = "123 Main St";
            customer.City = "Anytown";
            Assert.Equal("John Doe", customer.Name);
            Assert.Equal("123 Main St", customer.Address1);
            Assert.Equal("Anytown", customer.City);
        }

        [Fact]
        public void TestInvoiceModel()
        {
            var invoice = new Invoice();
            invoice.InvoiceDate = new DateTime(2020, 1, 1);
            invoice.PaymentDate = new DateTime(2020, 1, 31);
            invoice.Customer = new Customer();
            invoice.Customer.Name = "John Doe";
            invoice.Customer.Address1 = "123 Main St";
            invoice.Customer.City = "Anytown";
            Assert.Equal(new DateTime(2020, 1, 1), invoice.InvoiceDate);
            Assert.Equal(new DateTime(2020, 1, 31), invoice.PaymentDate);
        }


        [Fact]
        public void TestInvoiceItemModel()
        {
            var invoiceItem = new InvoiceLineItem();
            invoiceItem.Description = "Widget";
            Assert.Equal("Widget", invoiceItem.Description);
        }
    }
}