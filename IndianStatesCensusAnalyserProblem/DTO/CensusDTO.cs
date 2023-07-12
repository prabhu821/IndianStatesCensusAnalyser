using IndianStatesCensusAnalyserProblem.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;

        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }
    }
}
