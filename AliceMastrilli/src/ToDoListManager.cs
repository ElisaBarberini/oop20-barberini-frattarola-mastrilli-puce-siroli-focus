using System.Collections.Generic;
using System.Linq;

namespace AliceMastrilli.src
{
    class ToDoListManager : IToDoListManager
    {
        private readonly ISet<ToDoAction> set;
        public ToDoListManager() => set = new HashSet<ToDoAction>();
        public void AddAnnotation(ToDoAction tda)
        {
            if (!set.Contains(tda))
            {
                set.Add(tda);
            }
        }

        public void ChangeBoxStatus(ToDoAction tda)
        {
            set.Where(a => a.Equals(tda)).First().Done = !tda.Done;
        }

        public ISet<ToDoAction> GetAnnotations()
        {
            return set;
        }

        public void RemoveAnnotation(ToDoAction tda)
        {
            if (set.Contains(tda))
            {
                set.Remove(tda);
            }
        }
    }
}











