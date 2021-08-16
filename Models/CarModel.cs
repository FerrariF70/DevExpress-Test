using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Test.ViewModels
{

    /// <summary>
    /// Медель данных
    /// </summary>
    public partial class CarModel 
    {
        public CarModel(int id, string nameModel, string dateOfIssue, decimal price)
        {
            Id = id;
            NameModel = nameModel;
            DateOfIssue = dateOfIssue;
            Price = price;
        }

        public int Id { get; set; }
        public string NameModel { get; set; }

        public string DateOfIssue { get; set; }

        public decimal Price { get; set; }
        
       
    }
}
