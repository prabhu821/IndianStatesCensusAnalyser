using IndianStatesCensusAnalyserProblem;
using IndianStatesCensusAnalyserProblem.DTO;
using static IndianStatesCensusAnalyserProblem.CensusAnalyser;

namespace TestIndianStatesCensusAnalyser
{
    public class Tests
    {
        static string indianStateCensusHeaders = "﻿﻿State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusfilePath = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\IndianStateCensusData.csv";
        static string wrongIndianStateCensusfilePath = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\IndianCensusData.csv";
        static string wrongIndianStateCensusfileType = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\IndianStateCensusData.txt";
        static string delimiterIndianCensusfilePath = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndianCensusData.csv";
        static string wrongHeaderIndianCensusfilePath = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\WrongHeaderIndianStateCensusData.csv";

        IndianStatesCensusAnalyserProblem.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyserProblem.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// TC1.1- Given indian census data file when readed should return census data count

        [Test]
        public void GivenIndianCensusDataFileWhenReadedShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusfilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Console.WriteLine("Total state census => {0}", totalRecord.Count);
        }

        /// TC1.2- Given state census csv file if incorrect returns a custom exception

        [Test]
        public void GivenWrongStateCensusCsvFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// TC1.3- Given state census data file when correct but type incorrect return custom exception

        [Test]
        public void GivenStateCensusDataFileWhenCorrectButTypeIncorrectCustomReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }


        /// TC1.4- Given state census data file when correct but delimiter incorrect custom return exception

        [Test]
        public void GivenStateCensusDataFileWhenCorrectButDelimiterIncorrectCustomReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// TC1.5- Given state census data file when correct but header incorrect return custom exception

        [Test]
        public void GivenStateCensusDataFileWhenCorrectButHeaderIncorrectCustomReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}
