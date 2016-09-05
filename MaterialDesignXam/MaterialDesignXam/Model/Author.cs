using Newtonsoft.Json;

namespace MaterialDesignXam.Model
{
    public class Author
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Nome")]
        public string Name { get; set; }
    }
}