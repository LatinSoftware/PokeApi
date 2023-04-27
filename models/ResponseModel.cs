using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApi.models
{
    public class ResponseModel<TModel> where TModel : class
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previouse { get; set; }
        public List<TModel> Results { get; set; }
    }
}