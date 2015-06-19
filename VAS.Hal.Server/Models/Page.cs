namespace VAS.Hal.Server.Models
{
    public class Page
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public override string ToString()
        {
            return string.Format("PageNumber={0} | PageSize={1}", PageNumber, PageSize);
        }
    }
}
