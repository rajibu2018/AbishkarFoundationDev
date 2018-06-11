using AbishkarFoundation.Model;
using FluentNHibernate.Mapping;

namespace AbishkarFoundationNhibernetMapper
{
    public class QuestionMapper: ClassMap<Question>
    {
        public QuestionMapper()
        {
            Id(q => q.QuestionId);
            References(q => q.TestSet);
            Map(q => q.Text);
            Map(q => q.AnswerType);
            HasMany(q => q.Answers)
           .Inverse()
           .Cascade.All()
           .KeyColumn("QuestionId");
        }
    }
}
