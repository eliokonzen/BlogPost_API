namespace Blog.Core.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content  { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetContent(string content)
        {
            Content = content;
        }

        public void SetUpdatedAt(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }

        public void SetCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }

        public void SetActive(bool isActivate)
        {
            IsActive = isActivate;
            UpdatedAt = DateTime.Now;
        }
    }

}