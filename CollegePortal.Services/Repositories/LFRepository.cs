using CollegePortal.Entities.Models;
using CollegePortal.Services.DataAccessLayer;
using System;
namespace CollegePortal.Services.Repositories
{
	public class LFRepository : ILFRepository
	{
        private readonly DbContextStudent _context;

        public LFRepository(DbContextStudent context)
        {
            _context = context;
        }

        // Create a new lost and found post
        public LostAndFound CreateLostFound(int studentId, string itemDescription, DateTime foundDate, string location)
        {
            var newPost = new LostAndFound
            {
                studentId = studentId,
                itemDescription = itemDescription,
                foundDate = foundDate,
                location = location
            };

            _context.LostAndFound.Add(newPost);
            _context.SaveChanges();
            return newPost;
        }

        // Update an existing lost and found post
        public LostAndFound UpdateLostFound(int postId, string itemDescription, DateTime foundDate, string location)
        {
            var post = _context.LostAndFound.Find(postId);
            if (post == null)
                throw new Exception($"Lost and Found post with ID {postId} not found.");

            post.itemDescription = itemDescription;
            post.foundDate = foundDate;
            post.location = location;

            _context.SaveChanges();
            return post;
        }

        // Delete a lost and found post
        public void DeleteLostFound(int postId)
        {
            var post = _context.LostAndFound.Find(postId);
            if (post == null)
                throw new Exception($"Lost and Found post with ID {postId} is found.");

            _context.LostAndFound.Remove(post);
            _context.SaveChanges();
        }

        public IEnumerable<LostAndFound> GetLostAndFoundByStudentId(int studentId)
        {
            return _context.LostAndFound
                        .Where(post => post.studentId == studentId)
                        .ToList();
        }
    }
}

