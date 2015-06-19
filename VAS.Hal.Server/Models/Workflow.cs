using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Hal;

namespace VAS.Hal.Server.Models
{
    public class Workflow : Representation
    {
        private readonly Link _link;

        public string Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string WorkflowType { get; set; }

        public string State { get; private set; }

        public DateTime? CreatedUtc { get; private set; }

        public DateTime? CompletedUtc { get; set; }

        public Workflow(string id, string name, string workflowType, string state, DateTime? createdUtc, DateTime? completedUtc)
        {
            Id = id;
            Name = name;
            WorkflowType = workflowType;
            State = state;
            CreatedUtc = createdUtc;
            CompletedUtc = completedUtc;
            _link = new Link("workflow", "~/api/workflow/{id}");
        }

        public override string Rel
        {
            get { return _link.Rel; }
        }

        public override string Href
        {
            get { return _link.CreateLink(new { id = Id }).Href; }
        }

        protected override void CreateHypermedia()
        {
            Links.Add(new Link("taskactivity", "~/api/taskactivity/{id}"));

            Links.Add(new Link("taskactivity-query", string.Format("~/api/taskactivity?workflowid={0}&pagenumber={{pageNumber}}&pagesize={{pageSize}}", Id)));

            Links.Add(new Link("taskfield-query", string.Format("~/api/taskfield?workflowid={0}&pagenumber={{pageNumber}}&pagesize={{pageSize}}", Id)));
        }
    }
}