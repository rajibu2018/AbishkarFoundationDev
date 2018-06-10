using FluentNHibernate.Mapping;
using AbishkarFoundation.Model;

namespace AbishkarFoundationNhibernetMapper
{
    public  class StudentXYearMapper : ClassMap<StudentXYear>
    {
        public StudentXYearMapper()
        {
            Id(s => s.StudentXYearId);
            References(s => s.User);
            References(s => s.School);
            Map(s => s.Year).Length(20);
            Map(s => s.Standard);
            HasMany(s => s.Subjects)
            .Inverse()
            .Cascade.All()
            .KeyColumn("StudentXYearId");
        }
    }
}
