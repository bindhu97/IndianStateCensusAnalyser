using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IndianStateCensusAnalyser.CensusAnalyser;
using static IndianStateCensusAnalyserTest.CensusAnalyserTest;

namespace IndianStateCensusAnalyserTest
{
    public class CensusAnalyserTest
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\91973\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\StateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\91973\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongHeaderIndianCensusData.csv";
        static string delimeterIndianCensusFilePath = @"C:\Users\91973\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\91973\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\91973\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";

        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}