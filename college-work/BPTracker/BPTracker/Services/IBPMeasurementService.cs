using BPTracker.Models;

namespace BPTracker.Services
{
    public interface IBPMeasurementService
    {
        List<BloodPressure> GetBPReadings();
        void AddNewBPReading(BloodPressure bp);
        void EditBPReading(BloodPressure bp);
        BloodPressure GetBPReadingById(int id);
        void UpdateBPReading(int id, BloodPressure bp);
        void DeleteBPReading(int id);
    }
}
