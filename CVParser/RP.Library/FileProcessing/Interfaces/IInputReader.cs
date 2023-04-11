using System.Collections.Generic;

namespace RP.Library.FileProcessing.Interfaces;

  public interface IInputReader
  {
  void SetNextReader(IInputReader value);
  IList<string> ReadIntoList(string location);        
  }
