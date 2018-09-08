﻿using Dwc.Text;
using DWC_A;
using DWC_A.Factories;
using DWC_A.Meta;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests
{
    //TODO:  use a MemoryStream for testing here to allow parallelism in tests
    public class StreamEnumeratorTests
    {
        private const string fileName = "./resources/dwca-vascan-v37.5/taxon.txt";
        private readonly IRowFactory rowFactory;
        private readonly ITokenizer tokenizer;

        Mock<IFileMetaData> fileMetaDataMock = new Mock<IFileMetaData>();
        Mock<IFileAttributes> fileAttributesMock = new Mock<IFileAttributes>();

        public StreamEnumeratorTests()
        {
            fileMetaDataMock.Setup(n => n.FieldsEnclosedBy).Returns("");
            fileMetaDataMock.Setup(n => n.FieldsTerminatedBy).Returns("\t");
            fileMetaDataMock.Setup(n => n.LinesTerminatedBy).Returns("\n");
            fileMetaDataMock.Setup(n => n.Encoding).Returns(Encoding.UTF8);

            fileAttributesMock.Setup(n => n.FieldsEnclosedBy).Returns("");
            fileAttributesMock.Setup(n => n.FieldsTerminatedBy).Returns("\t");
            fileAttributesMock.Setup(n => n.LinesTerminatedBy).Returns("\n");
            fileAttributesMock.Setup(n => n.Encoding).Returns("UTF-8");

            rowFactory = new RowFactory();
            tokenizer = new Tokenizer(fileMetaDataMock.Object);
        }

        ICollection<FieldType> fieldTypes = new FieldType[]
        {


        };

        [Fact]
        public void ShouldEnumerateFile()
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                var streamEnumerator = new DWC_A.StreamReader(stream,
                    rowFactory,
                    tokenizer,
                    fileMetaDataMock.Object);
                Assert.NotEmpty(streamEnumerator.Rows.ToArray());
            }
        }

        [Fact]
        public void ShouldReturnHeaderRow()
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                var streamEnumerator = new DWC_A.StreamReader(stream,
                    rowFactory,
                    tokenizer,
                    fileMetaDataMock.Object);
                Assert.Single(streamEnumerator.HeaderRows(1));
            }
        }

        [Fact]
        public void ShouldReturnDataRows()
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                var streamEnumerator = new DWC_A.StreamReader(stream,
                    rowFactory,
                    tokenizer,
                    fileMetaDataMock.Object);
                Assert.NotEmpty(streamEnumerator.DataRows(1));
            }
        }
    }
}
