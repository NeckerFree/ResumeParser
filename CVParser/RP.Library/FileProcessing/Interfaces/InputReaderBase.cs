using RP.Library.FileProcessing.Exceptions;

namespace RP.Library.FileProcessing.Interfaces;

public abstract class InputReaderBase : IInputReader
  {

  public IInputReader? nextReader { get; set; } = null;
  
  public void SetNextReader(IInputReader value)
  {
    nextReader = value;
  }

  public IList<string> ReadIntoList(string location)
      {
          if (CanHandle(location))
          {
              return Handle(location);
          }

          if (nextReader != null)
          {
      return nextReader.ReadIntoList(location);
          }

          throw new NotSupportedResumeTypeException("No reader registered for this type of resume: " + location);
      }

      protected abstract bool CanHandle(string location);
      protected abstract IList<string> Handle(string location);        
  }
