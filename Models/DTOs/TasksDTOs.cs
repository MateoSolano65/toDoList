namespace todoListApi.Models.DTOs
{

    public class TaskCreateDTO
    {
        public string Title { get; set; }
    }

    public class TaskUpdateDTO
    {
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
