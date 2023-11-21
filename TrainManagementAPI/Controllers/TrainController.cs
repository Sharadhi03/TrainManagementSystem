using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainManagement.Data.Entities;
using TrainManagement.Data.Repository;
using TrainManagementAPI.Models;

namespace TrainManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        public TrainRepository TrainRepository { get; set; }

        public TrainController()
        {
            this.TrainRepository = new TrainRepository();
        }
        [HttpGet]
        public List<TblTrain> GetAllTrains()
        {
            return this.TrainRepository.GetAllTrains();
        }
        [HttpPost]
        public void AddTrain(Train train)
        {
            TblTrain tbltrain = new TblTrain();
            tbltrain.TrainId = 1;
            tbltrain.TrainName = train.TrainName;
            tbltrain.PNRNumber = train.PNRNumber;
            tbltrain.ArrivalDateTime = train.ArrivalDateTime;
            tbltrain.DepartureDateTime = train.DepartureDateTime;
            tbltrain.SourceStation = train.SourceStation;
            tbltrain.DestinationStation = train.DestinationStation;
            this.TrainRepository.AddTrain(tbltrain);
        }
        [HttpDelete]
        public void DeleteTrain(int trainId)
        {
            this.TrainRepository.DeleteTrain(trainId);
        }
        [HttpGet("{trainId:int}")]
        public TblTrain GetTrain(int trainId)
        {
            return TrainRepository.GetTrain(trainId);
        }

    }
}

