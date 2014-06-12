using System;
using System.Runtime.Serialization;
namespace Topic.N.SupportingClasses
{
    /// <summary>
    /// The ArrayFullException class is used in some of the 
    /// array samples that allow adding to an existing array.
    /// </summary>
    [Serializable]
    public class ArrayFullException : Exception
    {
    	  // constructors...
    	  #region ArrayFullException()
    	  /// <summary>
    	  /// Constructs a new ArrayFullException.
    	  /// </summary>
    		public ArrayFullException() { }
    		#endregion
    	#region ArrayFullException(string message)
    	/// <summary>
    	/// Constructs a new ArrayFullException.
    	/// </summary>
    	/// <param name="message">The exception message</param>
    	public ArrayFullException(string message) : base(message) {}
    	#endregion
    	#region ArrayFullException(string message, Exception innerException)
    	/// <summary>
    	/// Constructs a new ArrayFullException.
    	/// </summary>
    	/// <param name="message">The exception message</param>
    	/// <param name="innerException">The inner exception</param>
    	public ArrayFullException(string message, Exception innerException) : base(message, innerException) {}
    	#endregion
    	#region ArrayFullException(SerializationInfo info, StreamingContext context)
    	/// <summary>
    	/// Serialization constructor.
    	/// </summary>
    	protected ArrayFullException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    	#endregion
    }
}