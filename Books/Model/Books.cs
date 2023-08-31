using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Books.Model
{
    public class Books
    {
        [BsonId]
        public string id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string category { get; set; }
        public string author { get; set; }
    }
}