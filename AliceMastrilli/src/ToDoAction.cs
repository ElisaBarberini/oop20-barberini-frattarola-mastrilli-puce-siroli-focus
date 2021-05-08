using System;

namespace AliceMastrilli.src
{
    public class ToDoAction
    {
        private static readonly int MAX_LENGTH = 50;
        public ToDoAction(string annotation, bool done)
        {
            if (HasRightLength(annotation))
            {
                Annotation = annotation;
                Done = done;
            }
        }
        private bool HasRightLength(string annotation)
        {
            return annotation.Length <= MAX_LENGTH;
        }

        public override bool Equals(object obj)
        {
            return obj is ToDoAction action &&
                   Annotation == action.Annotation;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Done, Annotation);
        }

        public bool Done { get; set; }

        public string Annotation { get; set; }

    }
}
