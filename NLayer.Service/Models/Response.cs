using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Service.Models
{
    public class Response<T>
    {

        public T Data { get; set; }

        public List<string> Errors { get; set; }

        //public int Status { get; set; } //status kodunu response da dönmek best practice bir yaklaşım değil. zaten http protocol gereği bir durum kodu dönücek

        [JsonIgnore]
        public int Status { get; set; }
    }
}
