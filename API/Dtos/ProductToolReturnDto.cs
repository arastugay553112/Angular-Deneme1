using System;

namespace API.Dtos
{
    public class ProductToolReturnDto
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public decimal? Price { get; set; }
        public String PictureUrl { get; set; }

        public string ProductType { get; set; }

        public string ProductBrand { get; set; }

    }
}
