using Microsoft.EntityFrameworkCore;
using Virtual_Interview_Platform.Data;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;
using System;

namespace Virtual_Interview_Platform.Services.Implementation
{
    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _context;

        public CandidateService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create candidate
        public async Task CreateCandidate(Candidate candidate)
        {
            try
            {
                // Check if the candidate already exists by UserID (could also check by ResumeURL if necessary)
                var candidateExists = await _context.Candidates
                    .FirstOrDefaultAsync(c => c.UserID == candidate.UserID);

                if (candidateExists != null)
                {
                    throw new Exception("Candidate with this User ID already exists.");
                }

                // Add new candidate
                await _context.Candidates.AddAsync(candidate);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating candidate: {ex.Message}");
            }
        }

        // Delete candidate
        public async Task DeleteCandidate(int candidateId)
        {
            try
            {
                var candidateExists = await _context.Candidates
                    .FirstOrDefaultAsync(c => c.CandidateID == candidateId);

                if (candidateExists == null)
                {
                    throw new Exception("Candidate does not exist.");
                }

                _context.Candidates.Remove(candidateExists);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting candidate: {ex.Message}");
            }
        }

        // Get all candidates
        public async Task<List<Candidate>> GetAllCandidates()
        {
            try
            {
                return await _context.Candidates.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving candidates: {ex.Message}");
            }
        }

        // Get candidate by ID
        public async Task<Candidate> GetCandidateById(int candidateId)
        {
            try
            {
                var candidate = await _context.Candidates
                    .FirstOrDefaultAsync(c => c.CandidateID == candidateId);

                if (candidate == null)
                {
                    throw new Exception("Candidate with this ID does not exist.");
                }

                return candidate;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving candidate by ID: {ex.Message}");
            }
        }

        // Update candidate
        public async Task UpdateCandidate(Candidate candidate)
        {
            try
            {
                var existingCandidate = await _context.Candidates
                    .FirstOrDefaultAsync(c => c.CandidateID == candidate.CandidateID);

                if (existingCandidate == null)
                {
                    throw new Exception("Candidate with this ID does not exist.");
                }

                // Ensure no other candidate has the same UserID
                var candidateExists = await _context.Candidates
                    .FirstOrDefaultAsync(c => c.UserID == candidate.UserID && c.CandidateID != candidate.CandidateID);

                if (candidateExists != null)
                {
                    throw new Exception("Candidate with this User ID already exists.");
                }

                // Update candidate details
                existingCandidate.ResumeURL = candidate.ResumeURL;
                existingCandidate.CreatedAt = candidate.CreatedAt;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating candidate: {ex.Message}");
            }
        }
    }
}
