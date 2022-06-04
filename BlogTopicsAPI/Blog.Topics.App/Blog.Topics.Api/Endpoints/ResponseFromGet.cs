namespace Blog.Topics.Api.Endpoints
{
    public class ResponseFromGet
    {
        public string Name { get; set; }
        public int AggregateCount { get; set; }
        public string? Style { get; set; }

        public ResponseFromGet()
        {
            this.Name = "";
            if(this.Style != null && this.Style.Length == 0)
                this.Style = null;
        }
    }
}
