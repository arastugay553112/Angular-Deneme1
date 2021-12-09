using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageASize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pagesize=6;
            public int PageSize
        {
            get => _pagesize;
            set => _pagesize=(value > MaxPageASize) ? MaxPageASize : value;
        }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public String Sort { get; set; }

        //TODO:Encapsulation
        private string _search;

        public string Saerch {
            get { return _search; }
            set {
                //tolower küçük harfe cevir
                _search = value.ToLower();
            } }
    }
}
