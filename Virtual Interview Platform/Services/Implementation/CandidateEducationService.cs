using Microsoft.EntityFrameworkCore;
using Virtual_Interview_Platform.Data;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Virtual_Interview_Platform.Services.Implementation
{
    public class CandidateEducationService : ICandidateEducationService
    {
        private readonly ApplicationDbContext _context;

        public CandidateEducationService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create candidate education record
        public async Task CreateCandidateEducation(CandidateEducation candidateEducation)
        {
            try
            {
                // Ensure the candidate exists
                var candidateExists = await _context.Candidates
                    .FirstOrDefaultAsync(c => c.CandidateID == candidateEducation.CandidateID);

                if (candidateExists == null)
                {
                    throw new Exception("Candidate does not exist.");
                }

                // Add new candidate education record
                await _context.CandidateEducations.AddAsync(candidateEducation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating candidate education: {ex.Message}");
            }
        }

        // Delete candidate education record
        public async Task DeleteCandidateEducation(int candidateEducationId)
        {
            try
            {
                var candidateEducationExists = await _context.CandidateEducations
                    .FirstOrDefaultAsync(ce => ce.EducationID == candidateEducationId);

                if (candidateEducationExists == null)
                {
                    throw new Exception("Candidate education record does not exist.");
                }

                _context.CandidateEducations.Remove(candidateEducationExists);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting candidate education record: {ex.Message}");
            }
        }

        // Update candidate education record
        public async Task UpdateCandidateEducation(CandidateEducation candidateEducation)
        {
            try
            {
                var existingEducation = await _context.CandidateEducations
                    .FirstOrDefaultAsync(ce => ce.EducationID == candidateEducation.EducationID);

                if (existingEducation == null)
                {
                    throw new Exception("Candidate education record with this ID does not exist.");
                }

                // Update candidate education details
                existingEducation.Degree = candidateEducation.Degree;
                existingEducation.Institution = candidateEducation.Institution;
                existingEducation.StartDate = candidateEducation.StartDate;
                existingEducation.EndDate = candidateEducation.EndDate;
                existingEducation.Grade = candidateEducation.Grade;
                existingEducation.CreatedAt = candidateEducation.CreatedAt;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating candidate education record: {ex.Message}");
            }
        }

        // Get candidate education by ID
        public async Task<CandidateEducation> GetCandidateEducationById(int candidateEducationId)
        {
            try
            {
                var candidateEducation = await _context.CandidateEducations
                    .FirstOrDefaultAsync(ce => ce.EducationID == candidateEducationId);

                if (candidateEducation == null)
                {
                    throw new Exception("Candidate education record with this ID does not exist.");
                }

                return candidateEducation;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving candidate education record by ID: {ex.Message}");
            }
        }

        // Get all candidate education records by candidate ID
        public async Task<List<CandidateEducation>> GetAllCandidateEducationsByCandidateId(int candidateId)
        {
            try
            {
                return await _context.CandidateEducations
                    .Where(ce => ce.CandidateID == candidateId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving candidate education records by candidate ID: {ex.Message}");
            }
        }
    }
}
