using AbishkarFoundation.Model;
using FluentNHibernate.Mapping;

namespace AbishkarFoundationNhibernetMapper
{
    public class AnswerMapper : ClassMap<Answer>
    {
        public AnswerMapper()
        {
            Id(a => a.AnswerId);
            References(a => a.Question);
            Map(a => a.Text);
        }
    }
}
