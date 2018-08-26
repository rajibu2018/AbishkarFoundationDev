using AbishkarFoundation.Model;
using FluentNHibernate.Mapping;

namespace AbishkarFoundationNhibernetMapper
{
    public class TestSetMapper : ClassMap<TestSet>
    {
        public TestSetMapper()
        {
            Id(t => t.TestSetId);
            Map(t => t.TestName);
            References(t => t.Creator);
            Map(t => t.CreateDate);
            Map(t => t.AccessType);
            Map(t => t.RepeatedAccess);
            Map(t => t.Duration);
            Map(t => t.ActiveUpto);
            Map(t => t.Active);

        }
    }
}
