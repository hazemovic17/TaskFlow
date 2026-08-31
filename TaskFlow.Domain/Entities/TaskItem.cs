using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities
{
    
    public class TaskItem
    {
        public Guid Id { get; set; } //ID is a globaly unique identifier for the Task that lowers the chance of conflict and ID duplication

        public string Title { get; set; } = string.Empty;// title of Task is not null but will be empty text 

        public string? Description { get; set; } //Descritption of task could be nullable

        public bool IsDone { get; set; } = false; //status of the task if it is done or not

        public DateTime? DueDate { get; set; } //end date of the task and it could be nullable which means this task could be done at anytime

        public Guid AssignedUserId { get; set; } //the id of the assigned user in this task
                                                 //foregin key  of the user.Id
        public User AssignedUser { get; set; } = null!; //the user itslef the task is assigned to (navigation property)
    }
}
