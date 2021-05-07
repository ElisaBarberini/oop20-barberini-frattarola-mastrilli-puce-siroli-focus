using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oop
{
    class ToDoListManager : IToDoListManager
    {
        readonly ISet<ToDoAction> set;
        public ToDoListManager() => set = new HashSet<ToDoAction>();
        public void AddAnnotation(ToDoAction tda)
        {
            if (!this.set.Contains(tda))
            {

                this.set.Add((ToDoAction)tda);
            }
        }

        public void ChangeBoxStatus(ToDoAction tda)
        {
            
                ISet<ToDoAction> actions = this.set.Where(x => x.Annotation.Equals(tda.
                Annotation)).ToHashSet();
                if (actions.Count > 0)
                {
                    actions.First<ToDoAction>().Done = !tda.Done;
                }
        }

        public ISet<ToDoAction> GetAnnotations()
        {
            return set;
        }

        public void RemoveAnnotation(ToDoAction tda)
        {
            if (set.Contains(tda)) {
                set.Remove(tda);
            }
        }
    }
 }

    

    
    





  
