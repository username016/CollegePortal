using CollegePortal.Entities.Models;

public interface ILFRepository
{
    // Get all lost and found posts
    IEnumerable<LostAndFound> GetAllLostFound();
    // Get a lost and found post by ID
    LostAndFound GetLostFoundById(int postId);
    // Get all lost and found posts for a specific student
    IEnumerable<LostAndFound> GetLostAndFoundByStudentId(int studentId);
    // Create a new lost and found post
    LostAndFound CreateLostFound(int studentId, string itemDescription, DateTime foundDate, string location);
    // Update an existing lost and found post
    LostAndFound UpdateLostFound(int postId, string itemDescription, DateTime foundDate, string location);
    // Delete a lost and found post
    void DeleteLostFound(int postId);
}
