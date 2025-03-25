﻿using System.Globalization;
using Course.Entities.Enums;
using System.Text;

namespace Course.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus OrderStatus { get; set; }        
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() 
        {
        }
        public Order(DateTime moment, OrderStatus orderStatus, Client client)
        {
            Moment = moment;
            OrderStatus = orderStatus;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Order moment: {Moment}");
            stringBuilder.AppendLine($"Order status: {OrderStatus}");
            stringBuilder.AppendLine($"Client: {Client.Name} ({Client.BirthDate}) - {Client.Email}");
            stringBuilder.AppendLine("Order items:");
            foreach (OrderItem item in Items)
            {
                stringBuilder.AppendLine($"{item.ToString()}");
            }
            stringBuilder.AppendLine($"Total price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
            return stringBuilder.ToString();
        }
    }
}
