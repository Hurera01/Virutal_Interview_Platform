using Microsoft.EntityFrameworkCore;
using Virtual_Interview_Platform.Data;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;
using System;

namespace Virtual_Interview_Platform.Services.Implementation
{
    public class RecruiterServiceold : IRecruiterServiceold
    {
        private readonly ApplicationDbContext _context;

        public RecruiterServiceold(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create recruiter
        public async Task CreateRecruiter(Recruiter recruiter)
        {
            try
            {
                // Check if the recruiter already exists by user ID (you could check by CompanyName or other fields too)
                var recruiterExists = await _context.Recruiters
                    .FirstOrDefaultAsync(r => r.UserID == recruiter.UserID);

                if (recruiterExists != null)
                {
                    throw new Exception("Recruiter with this User ID already exists.");
                }

                // Add new recruiter
                await _context.Recruiters.AddAsync(recruiter);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating recruiter: {ex.Message}");
            }
        }

        // Delete recruiter
        public async Task DeleteRecruiter(int recruiterId)
        {
            try
            {
                var recruiterExists = await _context.Recruiters
                    .FirstOrDefaultAsync(r => r.RecruiterID == recruiterId);

                if (recruiterExists == null)
                {
                    throw new Exception("Recruiter does not exist.");
                }

                _context.Recruiters.Remove(recruiterExists);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting recruiter: {ex.Message}");
            }
        }

        // Get all recruiters
        public async Task<List<Recruiter>> GetAllRecruiters()
        {
            try
            {
                return await _context.Recruiters.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving recruiters: {ex.Message}");
            }
        }

        // Get recruiter by ID
        public async Task<Recruiter> GetRecruiterById(int recruiterId)
        {
            try
            {
                var recruiter = await _context.Recruiters
                    .FirstOrDefaultAsync(r => r.RecruiterID == recruiterId);

                if (recruiter == null)
                {
                    throw new Exception("Recruiter with this ID does not exist.");
                }

                return recruiter;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving recruiter by ID: {ex.Message}");
            }
        }

        // Update recruiter
        public async Task UpdateRecruiter(Recruiter recruiter)
        {
            try
            {
                var existingRecruiter = await _context.Recruiters
                    .FirstOrDefaultAsync(r => r.RecruiterID == recruiter.RecruiterID);

                if (existingRecruiter == null)
                {
                    throw new Exception("Recruiter with this ID does not exist.");
                }

                // Ensure no duplicate recruiter for the same user ID
                var recruiterExists = await _context.Recruiters
                    .FirstOrDefaultAsync(r => r.UserID == recruiter.UserID && r.RecruiterID != recruiter.RecruiterID);

                if (recruiterExists != null)
                {
                    throw new Exception("Recruiter with this User ID already exists.");
                }

                // Update recruiter details
                existingRecruiter.CompanyName = recruiter.CompanyName;
                existingRecruiter.Position = recruiter.Position;
                existingRecruiter.CreatedAt = recruiter.CreatedAt;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating recruiter: {ex.Message}");
            }
        }
    }
}
