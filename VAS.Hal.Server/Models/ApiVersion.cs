using WebApi.Hal;

namespace VAS.Hal.Server.Models
{
    public class ApiVersion : Representation
    {
        private readonly Link _link;

        public ApiVersion(string versionNumber)
        {
            VersionNumber = versionNumber;
            _link = new Link("apiversion", "~/api/apiversion/{id}");
        }

        public string VersionNumber { get; private set; }

        public override string Rel
        {
            get { return _link.Rel; }
        }

        public override string Href
        {
            get { return _link.CreateLink(new { id = VersionNumber }).Href; }
        }

        protected override void CreateHypermedia()
        {
            Links.Add(new Link("workflow", "~/api/workflow/{id}"));
        }
    }
}