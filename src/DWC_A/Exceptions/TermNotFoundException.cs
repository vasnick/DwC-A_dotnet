﻿using System;
using System.Runtime.Serialization;

namespace DWC_A.Exceptions
{
    public class TermNotFoundException : Exception
    {
        private static string BuildMessage(string term)
        {
            return $"Term {term} not found";
        }

        public TermNotFoundException(string term) :
            base(BuildMessage(term))
        {
        }

        public TermNotFoundException(string term, Exception innerException) : 
            base(BuildMessage(term), innerException)
        {
        }

        protected TermNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}