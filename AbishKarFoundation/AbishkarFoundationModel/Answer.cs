using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.Model
{
   public class Answer
    {
        public virtual int AnswerId { get; set; }
        public virtual Question Question { get; set; }
        public virtual string Text { get; set; }
    }
}
