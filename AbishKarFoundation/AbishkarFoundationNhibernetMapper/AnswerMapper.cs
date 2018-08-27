using AbishkarFoundation.Model;
using FluentNHibernate.Mapping;

namespace AbishkarFoundationNhibernetMapper
{
    public class AnswerMapper : ClassMap<Answer>
    {
        public AnswerMapper()
        {
            Id(a => a.AnswerId);
            References(a => a.Question).Not.Nullable();
            Map(a => a.Text).Not.Nullable();
        }
    }
}
