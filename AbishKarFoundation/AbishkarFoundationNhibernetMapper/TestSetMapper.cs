using AbishkarFoundation.Model;
using FluentNHibernate.Mapping;

namespace AbishkarFoundationNhibernetMapper
{
    public class TestSetMapper : ClassMap<TestSet>
    {
        public TestSetMapper()
        {
            Id(t => t.TestSetId);
            Map(t => t.TestName).Not.Nullable();
            References(t => t.Creator).Not.Nullable();
            Map(t => t.CreateDate).Not.Nullable();
            Map(t => t.AccessType).Not.Nullable();
            Map(t => t.RepeatedAccess).Not.Nullable();
            Map(t => t.Duration);
            Map(t => t.ActiveUpto);
            Map(t => t.Active).Not.Nullable();
            Map(t => t.UpdateDate);
        }
    }
}
