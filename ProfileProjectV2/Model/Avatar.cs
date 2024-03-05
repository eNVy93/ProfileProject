namespace ProfileProjectV2.Model
{
    public class Avatar : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; } // URL to the avatar image
        public int InteractionCount { get; set; } // Number of times the user has interacted with the avatar

        // Navigation property
        public User User { get; set; }
    }
}