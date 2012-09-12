using TechEdDemoApi.Entities;

// ReSharper disable CheckNamespace
namespace TechEdDemoApi.Representations.Mappings
{
    public static class ConsultantRepresenationMapping
    {
        public static ConsultantRepresentation ToRepresentation(this Consultant consultant)
        {
            return new ConsultantRepresentation
            {
                Id = consultant.Id,
                Name = consultant.Name
            };
        }
    }
}
// ReSharper restore CheckNamespace
