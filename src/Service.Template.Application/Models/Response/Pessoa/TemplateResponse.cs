using System.Collections.Generic;

namespace Service.Template.Application.Models.Response
{
    public class TemplateResponse
    {
        public List<Navigator> Navigators { get; set; }
        public List<Template> Templates { get; set; }

        public TemplateResponse()
        {
            Navigators = new List<Navigator>();
            Templates = new List<Template>();
        }

        public TemplateResponse(List<Navigator> navigators, List<Template> templates)
        {
            Navigators = navigators;
            Templates = templates;
        }
    }
}
