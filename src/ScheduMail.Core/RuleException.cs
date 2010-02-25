using System;
using System.Collections.Specialized;

/// <summary>
/// Rule Exception wrapper class for Mvc framework.
/// </summary>
public class RuleException : Exception
{
    /// <summary>
    /// Gets or sets the errors.
    /// </summary>
    /// <value>The errors.</value>
    public NameValueCollection Errors { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RuleException"/> class.
    /// </summary>
    /// <param name="key">The key value for exception type.</param>
    /// <param name="value">The value of excption.</param>
    public RuleException(string key, string value)
    {
        this.Errors = new NameValueCollection { { key, value } };           
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RuleException"/> class.
    /// </summary>
    /// <param name="errors">The errors.</param>
    public RuleException(NameValueCollection errors)
    {
        this.Errors = errors;
    }   
}