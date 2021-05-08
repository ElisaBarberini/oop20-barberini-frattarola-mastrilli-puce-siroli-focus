using System.Collections.Generic;

namespace AliceMastrilli.src
{
    public interface IToDoListManager
    {
        void AddAnnotation(ToDoAction tda);

        void RemoveAnnotation(ToDoAction tda);

        void ChangeBoxStatus(ToDoAction tda);

        ISet<ToDoAction> GetAnnotations();
    }
}
