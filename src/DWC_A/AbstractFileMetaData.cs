﻿using Dwc.Text;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DWC_A
{
    public abstract class AbstractFileMetaData
    {
        private readonly FileType fileType;

        public AbstractFileMetaData(FileType fileType)
        {
            this.fileType = fileType ?? new FileType();
        }

        public string FileName { get { return fileType.Files.FirstOrDefault(); } }

        public string RowType { get { return fileType.RowType; } }

        //public IFileAttributes Attributes { get { return fileType; } }

        public Encoding Encoding { get { return Encoding.GetEncoding(fileType.Encoding); } }

        public string LinesTerminatedBy { get { return Regex.Unescape(fileType.LinesTerminatedBy); } }

        public string FieldsTerminatedBy { get { return Regex.Unescape(fileType.FieldsTerminatedBy); } }

        public string FieldsEnclosedBy { get { return Regex.Unescape(fileType.FieldsEnclosedBy); } }

        public string DateFormat { get { return fileType.DateFormat; } }

        public int LineTerminatorLength { get { return Encoding.GetByteCount(LinesTerminatedBy); } }

        public int HeaderRowCount
        {
            get
            {
                if (!Int32.TryParse(fileType.IgnoreHeaderLines, out int headerRowCount))
                {
                    return 0;
                }
                return headerRowCount;
            }
        }
    }
}