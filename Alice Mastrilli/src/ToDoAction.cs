using System;

namespace oop
{
    public class ToDoAction
    {
        private static readonly int MAX_LENGTH = 50;
        private readonly string annotation;
        private readonly bool done;
        public ToDoAction(string annotation, bool done)
        {
            if (HasRightLength(annotation))
            {
                this.annotation = annotation;
                this.done = done;
            }
        }
        private bool HasRightLength(string annotation)
        {
            return annotation.Length <= MAX_LENGTH;
        }
    
        public bool Done { get; set; }
       
        public string Annotation { get; set; }

    }
}
