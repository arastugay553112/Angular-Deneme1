using System;

namespace API.Core.DbModels
{
    public class Product : BaseEntity
    {
      
        public String Name { get; set; }
        public String Description { get; set; }
        public decimal? Price { get; set; }
        public String PictureUrl { get; set; }

        public ProductType ProductType { get; set; }
        public int? ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }
        //? bu işaret null olabilir demek anlamına geliuyor
        public int? ProductBrandId { get; set; }
    }
}
