using AbishkarFoundation.Model;
using FluentNHibernate.Mapping;

namespace AbishkarFoundationNhibernetMapper
{
    public class SchoolMapper: ClassMap<School>
    {
        public SchoolMapper()
        {
            Id(s => s.SchoolId);
            Map(s => s.Name).Not.Nullable();
            Map(s => s.Address).Not.Nullable();
            Map(s => s.Description).Length(5000);
            Map(t => t.Active);

        }
    }
}
