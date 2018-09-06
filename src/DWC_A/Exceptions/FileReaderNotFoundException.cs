﻿using System;
using System.Runtime.Serialization;

namespace DWC_A.Exceptions
{
    public class FileReaderNotFoundException : Exception
    {
        private static string BuildMessage(string fileName)
        {
            return $"FileReader for file {fileName} not found";
        }

        public FileReaderNotFoundException()
        {
        }

        public FileReaderNotFoundException(string fileName) : 
            base(BuildMessage(fileName))
        {
        }

        public FileReaderNotFoundException(string fileName, Exception innerException) : 
            base(BuildMessage(fileName), innerException)
        {
        }

        protected FileReaderNotFoundException(SerializationInfo info, StreamingContext context) : 
            base(info, context)
        {
        }
    }
}