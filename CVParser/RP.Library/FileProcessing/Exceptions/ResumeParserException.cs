using System;

namespace RP.Library.FileProcessing.Exceptions;

public class ResumeParserException : ApplicationException
{
  public ResumeParserException(string message)
      : base(message)
  {
  }

  public ResumeParserException(string message, Exception innerException)
      : base(message, innerException)
  {
  }
}
