using CollegePortal.Entities.Models;
using System;
namespace CollegePortal.Services.Repositories
{
	public interface ILFRepository
	{

        // Get all lost and found posts
        IEnumerable<LostAndFound> GetAllLostFound();

        // Get a specific lost and found post by its ID
        LostAndFound GetLostFoundById(int postId);

        // Create a new lost and found post
        LostAndFound CreateLostFound(int studentId, string itemDescription, DateTime foundDate, string location);

        // Update an existing lost and found post
        LostAndFound UpdateLostFound(int postId, string itemDescription, DateTime foundDate, string location);

        // Delete a lost and found post
        void DeleteLostFound(int postId);
    }
}

