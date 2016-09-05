using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXam.Model
{
    public class Book
    {
       [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

       [JsonProperty(PropertyName = "Nome")]
        public string Title { get; set; }

       [JsonProperty(PropertyName = "Autor")]
        public Author AuthorLib { get; set; }
    }
}
