using BPTracker.Data;
using BPTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BPTracker.Services
{
    public class BPMeasurementService : IBPMeasurementService
    {
        private BPTrackerDbContext _dbContext;

        public BPMeasurementService(BPTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BloodPressure> GetBPReadings()
        {
            List<BloodPressure> readings = _dbContext.Readings.Include(r => r.Position).ToList();
            return readings;
        }

        public void AddNewBPReading(BloodPressure bp)
        {
            _dbContext.Readings.Add(bp);
            _dbContext.SaveChanges();
        }

        public void EditBPReading(BloodPressure bp)
        {
            _dbContext.Readings.Update(bp);
            _dbContext.SaveChanges();
        }

        public BloodPressure GetBPReadingById(int id)
        {
            BloodPressure bp = _dbContext.Readings.Include(r => r.Position).FirstOrDefault(r => r.Id == id);
            return bp;
        }

        public void UpdateBPReading(int id, BloodPressure bp) 
        {
            BloodPressure bpToUpdate = _dbContext.Readings.FirstOrDefault(r => r.Id == id);
            bpToUpdate.Systolic = bp.Systolic;
            bpToUpdate.Diastolic = bp.Diastolic;
            bpToUpdate.Date = bp.Date;
            bpToUpdate.PositionId = bp.PositionId;
            _dbContext.SaveChanges();

        }

        public void DeleteBPReading(int id)
        {
            BloodPressure bp = _dbContext.Readings.FirstOrDefault(r => r.Id == id);
            _dbContext.Readings.Remove(bp);
            _dbContext.SaveChanges();
        }
    }


}
