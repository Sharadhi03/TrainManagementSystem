using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainManagement.Data.Entities;

namespace TrainManagement.Data.Repository
{
    public class TrainRepository
    {
        TmsContext TmsDbContext { get; set; }
        public TrainRepository()
        {
            this.TmsDbContext = new TmsContext();
        }
        public List<TblTrain> GetAllTrains()
        {
            return this.TmsDbContext.TblTrains.ToList();
        }
        public void AddTrain(TblTrain train)
        {
            this.TmsDbContext.TblTrains.Add(train);
            this.TmsDbContext.SaveChanges();
        }
        public void DeleteTrain(int trainId)
        {
            var trainNeedsTobeDeleted = this.TmsDbContext.TblTrains.Where(t => t.TrainId == trainId).FirstOrDefault();
            if (trainNeedsTobeDeleted != null)
            {
                this.TmsDbContext.Remove(trainNeedsTobeDeleted);
                this.TmsDbContext.SaveChanges();
            }
        }
        public TblTrain GetTrain(int trainId)
        {
            var train = this.TmsDbContext.TblTrains.Where(t => t.TrainId == trainId).FirstOrDefault();
            return train;
        }
    }
}
