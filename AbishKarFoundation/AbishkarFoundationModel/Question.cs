using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.Model
{
  public  class Question
    {
        public virtual int QuestionId { get; set; }
        public virtual TestSet TestSet { get; set; }
        public virtual string Text { get; set; }
        public virtual AnwserType AnswerType { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}
