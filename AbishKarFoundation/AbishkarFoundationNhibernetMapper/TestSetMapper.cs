using AbishkarFoundation.Model;
using FluentNHibernate.Mapping;

namespace AbishkarFoundationNhibernetMapper
{
    public class TestSetMapper : ClassMap<TestSet>
    {
        public TestSetMapper()
        {
            Id(t => t.TestSetId);
            References(t => t.Creator);
            Map(t => t.CreatreDate);
            Map(t => t.AccessType);
            Map(t => t.RepeatedAccess);
            Map(t => t.Duration);
            Map(t => t.ActiveUpto);
            Map(t => t.Active);

        }
    }
}
