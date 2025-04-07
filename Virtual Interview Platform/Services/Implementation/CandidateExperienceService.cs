using Microsoft.EntityFrameworkCore;
using Virtual_Interview_Platform.Data;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;
using System;

namespace Virtual_Interview_Platform.Services.Implementation
{
    public class CandidateExperienceService : ICandidateExperienceService
    {
        private readonly ApplicationDbContext _context;

        public CandidateExperienceService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create candidate experience
        public async Task CreateCandidateExperience(CandidateExperience candidateExperience)
        {
            try
            {
                // Ensure the candidate exists
                var candidateExists = await _context.Candidates
                    .FirstOrDefaultAsync(c => c.CandidateID == candidateExperience.CandidateID);

                if (candidateExists == null)
                {
                    throw new Exception("Candidate does not exist.");
                }

                // Add new candidate experience
                await _context.CandidateExperiences.AddAsync(candidateExperience);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating candidate experience: {ex.Message}");
            }
        }

        // Delete candidate experience
        public async Task DeleteCandidateExperience(int candidateExperienceId)
        {
            try
            {
                var candidateExperienceExists = await _context.CandidateExperiences
                    .FirstOrDefaultAsync(ce => ce.ExperienceID == candidateExperienceId);

                if (candidateExperienceExists == null)
                {
                    throw new Exception("Candidate experience does not exist.");
                }

                _context.CandidateExperiences.Remove(candidateExperienceExists);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting candidate experience: {ex.Message}");
            }
        }

        // Update candidate experience
        public async Task UpdateCandidateExperience(CandidateExperience candidateExperience)
        {
            try
            {
                var existingCandidateExperience = await _context.CandidateExperiences
                    .FirstOrDefaultAsync(ce => ce.ExperienceID == candidateExperience.ExperienceID);

                if (existingCandidateExperience == null)
                {
                    throw new Exception("Candidate experience with this ID does not exist.");
                }

                // Update candidate experience details
                existingCandidateExperience.CompanyName = candidateExperience.CompanyName;
                existingCandidateExperience.JobTitle = candidateExperience.JobTitle;
                existingCandidateExperience.StartDate = candidateExperience.StartDate;
                existingCandidateExperience.EndDate = candidateExperience.EndDate;
                existingCandidateExperience.Description = candidateExperience.Description;
                existingCandidateExperience.CreatedAt = candidateExperience.CreatedAt;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating candidate experience: {ex.Message}");
            }
        }

        // Get candidate experience by ID
        public async Task<CandidateExperience> GetCandidateExperienceById(int candidateExperienceId)
        {
            try
            {
                var candidateExperience = await _context.CandidateExperiences
                    .FirstOrDefaultAsync(ce => ce.ExperienceID == candidateExperienceId);

                if (candidateExperience == null)
                {
                    throw new Exception("Candidate experience with this ID does not exist.");
                }

                return candidateExperience;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving candidate experience by ID: {ex.Message}");
            }
        }

        // Get all candidate experiences by candidate ID
        public async Task<List<CandidateExperience>> GetAllCandidateExperiencesByCandidateId(int candidateId)
        {
            try
            {
                return await _context.CandidateExperiences
                    .Where(ce => ce.CandidateID == candidateId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving candidate experiences by candidate ID: {ex.Message}");
            }
        }
    }
}
