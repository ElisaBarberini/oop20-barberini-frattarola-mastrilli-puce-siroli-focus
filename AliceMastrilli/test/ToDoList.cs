
using AliceMastrilli.src;
using System.Linq;
using Xunit;

namespace AliceMastrilli
{
    public class ToDoListTest
    {
        private readonly IToDoListManager manager = new ToDoListManager();
        [Fact]
        public void ToDoList()
        {
            ToDoAction test1 = new ToDoAction("test1", false);
            manager.AddAnnotation(test1);
            Assert.True(manager.GetAnnotations().Contains(test1));
            ToDoAction test2 = new ToDoAction("test2", false);
            manager.AddAnnotation(test2);
            Assert.True(manager.GetAnnotations().Contains(test2));
            Assert.False(manager.GetAnnotations().Where(a => a.Equals(test1)).First().Done);
            Assert.False(manager.GetAnnotations().Where(a => a.Equals(test2)).First().Done);
            manager.ChangeBoxStatus(test2);
            Assert.True(manager.GetAnnotations().Where(a => a.Equals(test2)).First().Done);
            manager.RemoveAnnotation(test1);
            Assert.Null(manager.GetAnnotations().Where(a => a.Equals(test1)).FirstOrDefault());
            manager.RemoveAnnotation(test2);
        }
    }
}




