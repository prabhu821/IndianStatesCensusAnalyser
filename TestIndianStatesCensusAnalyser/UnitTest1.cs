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

        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodefilePath = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\IndianStateCode.csv";
        static string wrongIndianStateCodefilePath = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\IndianCode.csv";
        static string wrongIndianStateCodefileType = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\IndianStateCode.txt";
        static string delimiterIndianCodefilePath = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndianStateCode.csv";
        static string wrongHeaderIndianCodefilePath = @"C:\Users\91789\Desktop\New folder\Bridgelabz\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserProblem\CSVFiles\WrongHeaderIndianStateCode.csv";

        IndianStatesCensusAnalyserProblem.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

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

        // TC2.1- Given indian code data file when readed should return code data count

        [Test]
        public void GivenIndianCensusDataFileWhenReadedShouldReturnCodeDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodefilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
            Console.WriteLine("Total state code => {0}", stateRecord.Count);
        }

        // TC2.2- Given state census csv file if incorrect returns a custom exception

        [Test]
        public void GivenWrongStateCodeCsvFile_WhenReaded_ShouldReturnCustomException()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodefilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateCodeException.eType);
        }

        // TC2.3- Given state code data file when correct but type incorrect return custom exception

        [Test]
        public void GivenStateCodeDataFileWhenCorrectButTypeIncorrectCustomReturnException()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodefileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.eType);
        }

        // TC2.4- Given state code data file when correct but delimiter incorrect custom return exception

        [Test]
        public void GivenStateCodeDataFileWhenCorrectButDelimiterIncorrectCustomReturnException()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCodefilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.eType);
        }

        // TC2.5- Given state code data file when correct but header incorrect return custom exception

        [Test]
        public void GivenStateCodeDataFileWhenCorrectButHeaderIncorrectCustomReturnException()
        {
            var statecodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCodefilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, statecodeException.eType);
        }
    }
}
