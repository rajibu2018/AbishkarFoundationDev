using AbishkarFoundation.Model;
using FluentNHibernate.Mapping;

namespace AbishkarFoundationNhibernetMapper
{
    public class SubjectMapper:ClassMap<Subject>
    {
        public SubjectMapper()
        {
            Id(s => s.SubjectId);
            Map(s => s.Name);
        }
    }
}
